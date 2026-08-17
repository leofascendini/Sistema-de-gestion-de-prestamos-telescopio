using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    tipoSensor = table.Column<int>(type: "int", nullable: true),
                    resolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tamañoPixel = table.Column<double>(type: "float", nullable: true),
                    tipoMontura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cargaUtil = table.Column<double>(type: "float", nullable: true),
                    esGoTo = table.Column<bool>(type: "bit", nullable: true),
                    diametro = table.Column<double>(type: "float", nullable: true),
                    anguloVision = table.Column<double>(type: "float", nullable: true),
                    apertura = table.Column<double>(type: "float", nullable: true),
                    relacionFocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distanciaFocal = table.Column<double>(type: "float", nullable: true),
                    peso = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoId);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    ObjetoCelesteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    magnitudAparente = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.ObjetoCelesteId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TelescopioId = table.Column<int>(type: "int", nullable: false),
                    MonturaId = table.Column<int>(type: "int", nullable: false),
                    CamaraId = table.Column<int>(type: "int", nullable: true),
                    OcularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_CamaraId",
                        column: x => x.CamaraId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_MonturaId",
                        column: x => x.MonturaId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_OcularId",
                        column: x => x.OcularId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_TelescopioId",
                        column: x => x.TelescopioId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObservacionAstros",
                columns: table => new
                {
                    ObservacionAstroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaObservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultadoIA = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ObjetoCelesteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservacionAstros", x => x.ObservacionAstroId);
                    table.ForeignKey(
                        name: "FK_ObservacionAstros_ObjetosCelestes_ObjetoCelesteId",
                        column: x => x.ObjetoCelesteId,
                        principalTable: "ObjetosCelestes",
                        principalColumn: "ObjetoCelesteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObservacionAstros_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObservacionAstros_ObjetoCelesteId",
                table: "ObservacionAstros",
                column: "ObjetoCelesteId");

            migrationBuilder.CreateIndex(
                name: "IX_ObservacionAstros_PrestamoId",
                table: "ObservacionAstros",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CamaraId",
                table: "Prestamos",
                column: "CamaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MonturaId",
                table: "Prestamos",
                column: "MonturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OcularId",
                table: "Prestamos",
                column: "OcularId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_TelescopioId",
                table: "Prestamos",
                column: "TelescopioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObservacionAstros");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
