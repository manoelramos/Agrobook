using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alter_RelationshipAssociados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associados_PessoasFisicas_PessoaFisicaId",
                table: "Associados");

            migrationBuilder.DropForeignKey(
                name: "FK_Associados_PessoasJuridicas_PessoaJuridicaId",
                table: "Associados");

            migrationBuilder.DropIndex(
                name: "IX_Associados_PessoaFisicaId",
                table: "Associados");

            migrationBuilder.DropIndex(
                name: "IX_Associados_PessoaJuridicaId",
                table: "Associados");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "Associados");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                table: "Associados");

            migrationBuilder.RenameColumn(
                name: "CascadeMode",
                table: "PessoasJuridicas",
                newName: "AssociadoId");

            migrationBuilder.RenameColumn(
                name: "CascadeMode",
                table: "PessoasFisicas",
                newName: "AssociadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_AssociadoId",
                table: "PessoasJuridicas",
                column: "AssociadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_AssociadoId",
                table: "PessoasFisicas",
                column: "AssociadoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_Associados_AssociadoId",
                table: "PessoasFisicas",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasJuridicas_Associados_AssociadoId",
                table: "PessoasJuridicas",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_Associados_AssociadoId",
                table: "PessoasFisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoasJuridicas_Associados_AssociadoId",
                table: "PessoasJuridicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasJuridicas_AssociadoId",
                table: "PessoasJuridicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasFisicas_AssociadoId",
                table: "PessoasFisicas");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "PessoasJuridicas",
                newName: "CascadeMode");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "PessoasFisicas",
                newName: "CascadeMode");

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "Associados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaJuridicaId",
                table: "Associados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Associados_PessoaFisicaId",
                table: "Associados",
                column: "PessoaFisicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Associados_PessoaJuridicaId",
                table: "Associados",
                column: "PessoaJuridicaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Associados_PessoasFisicas_PessoaFisicaId",
                table: "Associados",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Associados_PessoasJuridicas_PessoaJuridicaId",
                table: "Associados",
                column: "PessoaJuridicaId",
                principalTable: "PessoasJuridicas",
                principalColumn: "Id");
        }
    }
}
