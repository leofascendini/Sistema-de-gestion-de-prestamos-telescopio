using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregueAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    AuditoriaPrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCoordinadorId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.AuditoriaPrestamoId);
                    table.ForeignKey(
                        name: "FK_Auditorias_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId");
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_UsuarioCoordinadorId",
                        column: x => x.UsuarioCoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_PrestamoId",
                table: "Auditorias",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_UsuarioCoordinadorId",
                table: "Auditorias",
                column: "UsuarioCoordinadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");
        }
    }
}
