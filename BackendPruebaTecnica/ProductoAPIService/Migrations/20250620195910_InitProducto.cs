using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductoAPIService.Migrations
{
    /// <inheritdoc />
    public partial class InitProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
