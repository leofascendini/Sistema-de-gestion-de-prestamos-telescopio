using Libreria.AccesoDatos;
using Libreria.AccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUCamara;
using Libreria.LogicaAplicacion.CasosUso.CUEquipo;
using Libreria.LogicaAplicacion.CasosUso.CUMontura;
using Libreria.LogicaAplicacion.CasosUso.CUOcular;
using Libreria.LogicaAplicacion.CasosUso.CUPrestamo;
using Libreria.LogicaAplicacion.CasosUso.CUTelescopio;



//using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUCamara;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Libreria.LogicaAplicacion.ICasosUso.ICUMontura;
using Libreria.LogicaAplicacion.ICasosUso.ICUOcular;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUTelescopio;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;


namespace Libreria.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //conexion para bd sql
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //Login
            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //ID - REPOS
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

            //ID - CU
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<ICUGestionEquipo, CUGestionEquipo>();

            builder.Services.AddScoped<ICUAltaPrestamo, CUAltaPrestamo>();
            builder.Services.AddScoped<ICUCargarDatosPrestamo, CUCargarDatosPrestamo>();
            builder.Services.AddScoped<ICUPrestamoListado, CUPrestamoListado>();

            builder.Services.AddScoped<ICUUsuarioListado, CUUsuarioListado>();
            builder.Services.AddScoped<ICUTelescopioListado, CUTelescopioListado>();
            builder.Services.AddScoped<ICUMonturaListado, CUMonturaListado>();
            builder.Services.AddScoped<ICUCamaraListado, CUCamaraListado>();
            builder.Services.AddScoped<ICUOcularListado, CUOcularListado>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //Login
            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
