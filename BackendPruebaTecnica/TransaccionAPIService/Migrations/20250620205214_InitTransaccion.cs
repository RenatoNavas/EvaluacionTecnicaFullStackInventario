using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransaccionAPIService.Migrations
{
    /// <inheritdoc />
    public partial class InitTransaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadTransaccion = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioTransaccion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetalleTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");
        }
    }
}
