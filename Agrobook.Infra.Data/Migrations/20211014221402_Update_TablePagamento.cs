using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Update_TablePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprovantesPagamentos_Pagamentos_PagamentosId",
                table: "ComprovantesPagamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Moeda_MoedaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Safras_SafraId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_Pagamentos_PagamentoId",
                table: "LancamentosContabeis");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_MoedaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "MoedaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "PagamentosId",
                table: "ComprovantesPagamentos",
                newName: "ParcelasId");

            migrationBuilder.RenameIndex(
                name: "IX_ComprovantesPagamentos_PagamentosId",
                table: "ComprovantesPagamentos",
                newName: "IX_ComprovantesPagamentos_ParcelasId");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Moeda",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<int>(
                name: "SafraId",
                table: "Despesas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatrimonioId",
                table: "Despesas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CredorId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CulturaId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorParcela = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(400)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DespesaId = table.Column<int>(type: "int", nullable: false),
                    IdMoedaParcela = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Despesas_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcelas_Moeda_IdMoedaParcela",
                        column: x => x.IdMoedaParcela,
                        principalTable: "Moeda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CredorId",
                table: "Despesas",
                column: "CredorId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CulturaId",
                table: "Despesas",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_DespesaId",
                table: "Parcelas",
                column: "DespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_IdMoedaParcela",
                table: "Parcelas",
                column: "IdMoedaParcela");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprovantesPagamentos_Parcelas_ParcelasId",
                table: "ComprovantesPagamentos",
                column: "ParcelasId",
                principalTable: "Parcelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Associados_CredorId",
                table: "Despesas",
                column: "CredorId",
                principalTable: "Associados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId",
                principalTable: "CategoriasDespesas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Culturas_CulturaId",
                table: "Despesas",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Safras_SafraId",
                table: "Despesas",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_Parcelas_PagamentoId",
                table: "LancamentosContabeis",
                column: "PagamentoId",
                principalTable: "Parcelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprovantesPagamentos_Parcelas_ParcelasId",
                table: "ComprovantesPagamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Associados_CredorId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Culturas_CulturaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Safras_SafraId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_Parcelas_PagamentoId",
                table: "LancamentosContabeis");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CredorId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CulturaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Moeda");

            migrationBuilder.DropColumn(
                name: "CredorId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CulturaId",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "ParcelasId",
                table: "ComprovantesPagamentos",
                newName: "PagamentosId");

            migrationBuilder.RenameIndex(
                name: "IX_ComprovantesPagamentos_ParcelasId",
                table: "ComprovantesPagamentos",
                newName: "IX_ComprovantesPagamentos_PagamentosId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SafraId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatrimonioId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoedaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoPessoa",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssociadoId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DespesaId = table.Column<int>(type: "int", nullable: false),
                    FGTS = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(400)", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Associados_AssociadoId",
                        column: x => x.AssociadoId,
                        principalTable: "Associados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Despesas_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_MoedaId",
                table: "Despesas",
                column: "MoedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_AssociadoId",
                table: "Pagamentos",
                column: "AssociadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_DespesaId",
                table: "Pagamentos",
                column: "DespesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprovantesPagamentos_Pagamentos_PagamentosId",
                table: "ComprovantesPagamentos",
                column: "PagamentosId",
                principalTable: "Pagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId",
                principalTable: "CategoriasDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Moeda_MoedaId",
                table: "Despesas",
                column: "MoedaId",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Safras_SafraId",
                table: "Despesas",
                column: "SafraId",
                principalTable: "Safras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_Pagamentos_PagamentoId",
                table: "LancamentosContabeis",
                column: "PagamentoId",
                principalTable: "Pagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
