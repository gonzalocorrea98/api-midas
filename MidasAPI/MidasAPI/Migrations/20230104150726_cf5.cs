using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidasAPI.Migrations
{
    /// <inheritdoc />
    public partial class cf5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoID",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoID",
                table: "Productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
