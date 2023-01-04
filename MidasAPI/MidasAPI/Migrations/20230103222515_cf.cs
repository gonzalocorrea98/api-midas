using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidasAPI.Migrations
{
    /// <inheritdoc />
    public partial class cf : Migration
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

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");

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
