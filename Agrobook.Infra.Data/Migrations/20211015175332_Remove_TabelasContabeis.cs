using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Remove_TabelasContabeis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Culturas_CulturaId",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "LancamentosContabeis");

            migrationBuilder.DropTable(
                name: "TiposLancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CulturaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Safras");

            migrationBuilder.DropColumn(
                name: "CulturaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Culturas");

            migrationBuilder.AddColumn<int>(
                name: "CulturaId",
                table: "Safras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Culturas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Safras_CulturaId",
                table: "Safras",
                column: "CulturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Safras_Culturas_CulturaId",
                table: "Safras",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Safras_Culturas_CulturaId",
                table: "Safras");

            migrationBuilder.DropIndex(
                name: "IX_Safras_CulturaId",
                table: "Safras");

            migrationBuilder.DropColumn(
                name: "CulturaId",
                table: "Safras");

            migrationBuilder.AddColumn<string>(
                name: "Cultura",
                table: "Safras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CulturaId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Culturas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Culturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposLancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposLancamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentosContabeis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CulturaId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TipoLancamentoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosContabeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosContabeis_Culturas_CulturaId",
                        column: x => x.CulturaId,
                        principalTable: "Culturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LancamentosContabeis_Parcelas_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentosContabeis_TiposLancamentos_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TiposLancamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CulturaId",
                table: "Despesas",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosContabeis_CulturaId",
                table: "LancamentosContabeis",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosContabeis_PagamentoId",
                table: "LancamentosContabeis",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosContabeis_TipoLancamentoId",
                table: "LancamentosContabeis",
                column: "TipoLancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Culturas_CulturaId",
                table: "Despesas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");
        }
    }
}
