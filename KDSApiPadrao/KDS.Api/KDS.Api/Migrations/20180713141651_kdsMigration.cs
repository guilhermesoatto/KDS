using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KDS.Api.Migrations
{
    public partial class kdsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    idComanda = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numeroComanda = table.Column<string>(maxLength: 50, nullable: true),
                    dataHoraInclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.idComanda);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    idStatus = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.idStatus);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    idPedido = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idComanda = table.Column<int>(nullable: false),
                    canalAtendimento = table.Column<string>(maxLength: 50, nullable: true),
                    codigoPedido = table.Column<int>(nullable: false),
                    statusAtualPedido = table.Column<string>(maxLength: 50, nullable: true),
                    codigoStatusAtualPedido = table.Column<int>(nullable: false),
                    dataHoraInclusao = table.Column<DateTime>(nullable: false),
                    ComandaidComanda = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Comanda_ComandaidComanda",
                        column: x => x.ComandaidComanda,
                        principalTable: "Comanda",
                        principalColumn: "idComanda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    idItem = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idPedido = table.Column<int>(nullable: false),
                    objectId = table.Column<string>(maxLength: 50, nullable: true),
                    statusAtualItem = table.Column<string>(maxLength: 50, nullable: true),
                    codigoStatusAtualItem = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: true),
                    observacao = table.Column<string>(maxLength: 150, nullable: true),
                    dataHoraInclusao = table.Column<DateTime>(nullable: false),
                    tempoMedioPreparacaoEmMinutos = table.Column<int>(nullable: false),
                    PedidoidPedido = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.idItem);
                    table.ForeignKey(
                        name: "FK_Item_Pedido_PedidoidPedido",
                        column: x => x.PedidoidPedido,
                        principalTable: "Pedido",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemAdicional",
                columns: table => new
                {
                    idAdicional = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idItem = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: true),
                    ItemidItem = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAdicional", x => x.idAdicional);
                    table.ForeignKey(
                        name: "FK_ItemAdicional_Item_ItemidItem",
                        column: x => x.ItemidItem,
                        principalTable: "Item",
                        principalColumn: "idItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemInsumo",
                columns: table => new
                {
                    idInsumo = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idItem = table.Column<int>(nullable: false),
                    objectId = table.Column<string>(maxLength: 50, nullable: true),
                    descricao = table.Column<string>(maxLength: 250, nullable: true),
                    remover = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    ItemidItem = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInsumo", x => x.idInsumo);
                    table.ForeignKey(
                        name: "FK_ItemInsumo_Item_ItemidItem",
                        column: x => x.ItemidItem,
                        principalTable: "Item",
                        principalColumn: "idItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_PedidoidPedido",
                table: "Item",
                column: "PedidoidPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAdicional_ItemidItem",
                table: "ItemAdicional",
                column: "ItemidItem");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInsumo_ItemidItem",
                table: "ItemInsumo",
                column: "ItemidItem");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ComandaidComanda",
                table: "Pedido",
                column: "ComandaidComanda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAdicional");

            migrationBuilder.DropTable(
                name: "ItemInsumo");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Comanda");
        }
    }
}
