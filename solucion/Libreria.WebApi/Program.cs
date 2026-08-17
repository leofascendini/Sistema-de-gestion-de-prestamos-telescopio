using Libreria.AccesoDatos;
using Libreria.AccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUAuditoria;
using Libreria.LogicaAplicacion.CasosUso.CUCamara;
using Libreria.LogicaAplicacion.CasosUso.CUEquipo;
using Libreria.LogicaAplicacion.CasosUso.CUMontura;
using Libreria.LogicaAplicacion.CasosUso.CUObjetoCeleste;
using Libreria.LogicaAplicacion.CasosUso.CUObservacionAstro;
using Libreria.LogicaAplicacion.CasosUso.CUOcular;
using Libreria.LogicaAplicacion.CasosUso.CUPrestamo;
using Libreria.LogicaAplicacion.CasosUso.CUTelescopio;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Libreria.LogicaAplicacion.ICasosUso.ICUCamara;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Libreria.LogicaAplicacion.ICasosUso.ICUMontura;
using Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste;
using Libreria.LogicaAplicacion.ICasosUso.ICUObservacionAstro;
using Libreria.LogicaAplicacion.ICasosUso.ICUOcular;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUTelescopio;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaAplicacion.IServicios;
using Libreria.LogicaAplicacion.Servicios;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVC", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// -------------------- SERVICES --------------------

builder.Services.AddControllers();


builder.Services.AddOpenApi();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioObservacionAstro, RepositorioObservacionAstro>();
builder.Services.AddScoped<IRepositorioOcular, RepositorioOcular>();
builder.Services.AddScoped<IRepositorioCamara, RepositorioCamara>();
builder.Services.AddScoped<IRepositorioMontura, RepositorioMontura>();
builder.Services.AddScoped<IRepositorioTelescopio, RepositorioTelescopio>();
builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCeleste>();
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();


// Casos de uso
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();
builder.Services.AddScoped<ICUGestionEquipo, CUGestionEquipo>();
builder.Services.AddScoped<ICUEquipoDisponible, CUEquipoDisponible>();


builder.Services.AddScoped<ICUAuditoria, CUAuditoria>();
builder.Services.AddScoped<ICUAltaPrestamo, CUAltaPrestamo>();
builder.Services.AddScoped<ICUCargarDatosPrestamo, CUCargarDatosPrestamo>();
builder.Services.AddScoped<ICUPrestamoListado, CUPrestamoListado>();
builder.Services.AddScoped<ICUPrestamosVigentes, CUPrestamosVigentes>();
builder.Services.AddScoped<ICUDevolucionPrestamo, CUDevolucionPrestamo>();
builder.Services.AddScoped<ICUPrestamoListadoEntreFechas, CUPrestamoListadoEntreFechas>();
builder.Services.AddScoped<ICUListadoSociosPorTelescopio, CUListadoSociosPorTelescopio>();

builder.Services.AddScoped<ICUUsuarioListado, CUUsuarioListado>();
builder.Services.AddScoped<ICUTelescopioListado, CUTelescopioListado>();
builder.Services.AddScoped<ICUMonturaListado, CUMonturaListado>();
builder.Services.AddScoped<ICUCamaraListado, CUCamaraListado>();
builder.Services.AddScoped<ICUOcularListado, CUOcularListado>();

builder.Services.AddScoped<ICUAltaObservacion, CUAltaObservacion>();
builder.Services.AddScoped<ICUEvaluarObservacion, CUEvaluarObservacion>();
builder.Services.AddScoped<ICUObjetoCelesteListado, CUObjetoCelesteListado>();
builder.Services.AddScoped<ICURankingObjetosCelestes, CURankingObjetosCelestes>();

// Servicios externos
builder.Services.AddHttpClient<IServicioGemini, ServicioGemini>();
builder.Services.AddScoped<IServicioAuth, ServicioAuth>();

// -------------------- JWT --------------------

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();

// -------------------- APP --------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowMVC");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();