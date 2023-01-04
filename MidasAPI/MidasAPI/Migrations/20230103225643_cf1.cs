using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidasAPI.Migrations
{
    /// <inheritdoc />
    public partial class cf1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoID",
                table: "Productos",
                column: "TipoProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoID",
                table: "Productos",
                column: "TipoProductoID",
                principalTable: "TipoProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoID",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoID",
                table: "Productos");
        }
    }
}
