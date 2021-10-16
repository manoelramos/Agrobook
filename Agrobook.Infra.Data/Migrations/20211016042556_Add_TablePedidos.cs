using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Add_TablePedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Parcelas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPedidoFornecedor = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnidadeMedidaId = table.Column<int>(type: "int", nullable: false),
                    FazendaId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Fazendas_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Juridicas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Juridicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_UnidadesMedidas_UnidadeMedidaId",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadesMedidas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_PedidoId",
                table: "Parcelas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FazendaId",
                table: "Pedidos",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_InsumoId",
                table: "Pedidos",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UnidadeMedidaId",
                table: "Pedidos",
                column: "UnidadeMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Pedidos_PedidoId",
                table: "Parcelas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Pedidos_PedidoId",
                table: "Parcelas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Parcelas_PedidoId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Parcelas");
        }
    }
}
