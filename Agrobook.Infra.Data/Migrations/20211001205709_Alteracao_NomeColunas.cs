using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_NomeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fisicas_Associados_PessoaId",
                table: "Fisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Juridicas_Associados_PessoaId",
                table: "Juridicas");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Juridicas",
                newName: "AssociadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Juridicas_PessoaId",
                table: "Juridicas",
                newName: "IX_Juridicas_AssociadoId");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Fisicas",
                newName: "AssociadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fisicas_PessoaId",
                table: "Fisicas",
                newName: "IX_Fisicas_AssociadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fisicas_Associados_AssociadoId",
                table: "Fisicas",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Juridicas_Associados_AssociadoId",
                table: "Juridicas",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fisicas_Associados_AssociadoId",
                table: "Fisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Juridicas_Associados_AssociadoId",
                table: "Juridicas");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "Juridicas",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Juridicas_AssociadoId",
                table: "Juridicas",
                newName: "IX_Juridicas_PessoaId");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "Fisicas",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fisicas_AssociadoId",
                table: "Fisicas",
                newName: "IX_Fisicas_PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fisicas_Associados_PessoaId",
                table: "Fisicas",
                column: "PessoaId",
                principalTable: "Associados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Juridicas_Associados_PessoaId",
                table: "Juridicas",
                column: "PessoaId",
                principalTable: "Associados",
                principalColumn: "Id");
        }
    }
}
