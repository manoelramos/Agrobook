using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class AjusteTabelaObservacaoLancamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_Culturas_CulturaId",
                table: "LancamentosContabeis");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_TiposLancamentos_TipoLancamentoId",
                table: "LancamentosContabeis");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_Culturas_CulturaId",
                table: "LancamentosContabeis",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_TiposLancamentos_TipoLancamentoId",
                table: "LancamentosContabeis",
                column: "TipoLancamentoId",
                principalTable: "TiposLancamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_Culturas_CulturaId",
                table: "LancamentosContabeis");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosContabeis_TiposLancamentos_TipoLancamentoId",
                table: "LancamentosContabeis");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_Culturas_CulturaId",
                table: "LancamentosContabeis",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosContabeis_TiposLancamentos_TipoLancamentoId",
                table: "LancamentosContabeis",
                column: "TipoLancamentoId",
                principalTable: "TiposLancamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
