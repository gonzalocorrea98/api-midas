using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidasAPI.Migrations
{
    /// <inheritdoc />
    public partial class cf7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId",
                principalTable: "TipoProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos");
        }
    }
}
