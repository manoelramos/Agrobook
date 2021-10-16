using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Add_TableFinanciamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Moeda_IdMoedaParcela",
                table: "Parcelas");

            migrationBuilder.DropTable(
                name: "Moeda");

            migrationBuilder.AddColumn<int>(
                name: "FinanciamentoId",
                table: "Parcelas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Moedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financiamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorFinanciado = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdquiridoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CredorId = table.Column<int>(type: "int", nullable: true),
                    PatrimonioId = table.Column<int>(type: "int", nullable: true),
                    IdMoedaParcela = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financiamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiamentos_Associados_CredorId",
                        column: x => x.CredorId,
                        principalTable: "Associados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Financiamentos_Moedas_IdMoedaParcela",
                        column: x => x.IdMoedaParcela,
                        principalTable: "Moedas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Financiamentos_Patrimonios_PatrimonioId",
                        column: x => x.PatrimonioId,
                        principalTable: "Patrimonios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_FinanciamentoId",
                table: "Parcelas",
                column: "FinanciamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_CredorId",
                table: "Financiamentos",
                column: "CredorId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_IdMoedaParcela",
                table: "Financiamentos",
                column: "IdMoedaParcela");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_PatrimonioId",
                table: "Financiamentos",
                column: "PatrimonioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Financiamentos_FinanciamentoId",
                table: "Parcelas",
                column: "FinanciamentoId",
                principalTable: "Financiamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Moedas_IdMoedaParcela",
                table: "Parcelas",
                column: "IdMoedaParcela",
                principalTable: "Moedas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Financiamentos_FinanciamentoId",
                table: "Parcelas");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Moedas_IdMoedaParcela",
                table: "Parcelas");

            migrationBuilder.DropTable(
                name: "Financiamentos");

            migrationBuilder.DropTable(
                name: "Moedas");

            migrationBuilder.DropIndex(
                name: "IX_Parcelas_FinanciamentoId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "FinanciamentoId",
                table: "Parcelas");

            migrationBuilder.CreateTable(
                name: "Moeda",
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
                    table.PrimaryKey("PK_Moeda", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Moeda_IdMoedaParcela",
                table: "Parcelas",
                column: "IdMoedaParcela",
                principalTable: "Moeda",
                principalColumn: "Id");
        }
    }
}
