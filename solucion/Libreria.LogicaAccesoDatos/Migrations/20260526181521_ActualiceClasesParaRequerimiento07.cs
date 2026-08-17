using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualiceClasesParaRequerimiento07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ResultadoIA",
                table: "ObservacionAstros",
                type: "int",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<string>(
                name: "ExplicacionIA",
                table: "ObservacionAstros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExplicacionIA",
                table: "ObservacionAstros");

            migrationBuilder.AlterColumn<string>(
                name: "ResultadoIA",
                table: "ObservacionAstros",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 300);
        }
    }
}
