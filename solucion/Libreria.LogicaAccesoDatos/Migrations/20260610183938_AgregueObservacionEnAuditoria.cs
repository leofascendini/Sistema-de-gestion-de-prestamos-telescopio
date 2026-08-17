using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregueObservacionEnAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Auditorias",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Auditorias");
        }
    }
}
