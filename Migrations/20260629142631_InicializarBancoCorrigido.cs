using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityWebSelect.Migrations
{
    /// <inheritdoc />
    public partial class InicializarBancoCorrigido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNasc = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PEDIDO",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    ValorTot = table.Column<decimal>(type: "money", nullable: false),
                    DtVenda = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PEDIDO", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_TBL_PEDIDO_TBL_CLIENTE_idCliente",
                        column: x => x.idCliente,
                        principalTable: "TBL_CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ITEM_PEDIDO",
                columns: table => new
                {
                    id_Itens = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    DescIten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUni = table.Column<decimal>(type: "money", nullable: false),
                    QtdeEstoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ITEM_PEDIDO", x => x.id_Itens);
                    table.ForeignKey(
                        name: "FK_TBL_ITEM_PEDIDO_TBL_PEDIDO_idPedido",
                        column: x => x.idPedido,
                        principalTable: "TBL_PEDIDO",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TBL_CLIENTE",
                columns: new[] { "IdCliente", "CPF", "DtNasc", "Nome" },
                values: new object[] { 1, "123.456.789-00", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luiz" });

            migrationBuilder.InsertData(
                table: "TBL_PEDIDO",
                columns: new[] { "idPedido", "DtVenda", "idCliente", "ValorTot" },
                values: new object[] { 10, new DateTime(2026, 6, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 150.50m });

            migrationBuilder.InsertData(
                table: "TBL_ITEM_PEDIDO",
                columns: new[] { "id_Itens", "DescIten", "idPedido", "QtdeEstoque", "ValorUni" },
                values: new object[,]
                {
                    { 100, "Teclado Mecânico", 10, 1, 100.00m },
                    { 101, "Mouse Pad Gamer", 10, 1, 50.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CLIENTE_CPF",
                table: "TBL_CLIENTE",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ITEM_PEDIDO_idPedido",
                table: "TBL_ITEM_PEDIDO",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PEDIDO_idCliente",
                table: "TBL_PEDIDO",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ITEM_PEDIDO");

            migrationBuilder.DropTable(
                name: "TBL_PEDIDO");

            migrationBuilder.DropTable(
                name: "TBL_CLIENTE");
        }
    }
}
