using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidasAPI.Migrations
{
    /// <inheritdoc />
    public partial class cf6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoProductoID",
                table: "Productos",
                newName: "TipoProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoProductoId",
                table: "Productos",
                newName: "TipoProductoID");
        }
    }
}
