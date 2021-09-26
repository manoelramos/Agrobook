using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alter_RelationshipContratacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associados_Contratacoes_ContratacaoId",
                table: "Associados");

            migrationBuilder.DropIndex(
                name: "IX_Associados_ContratacaoId",
                table: "Associados");

            migrationBuilder.DropColumn(
                name: "ContratacaoId",
                table: "Associados");

            migrationBuilder.AlterColumn<int>(
                name: "InscricaoMunicipal",
                table: "PessoasJuridicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InscricaoEstadual",
                table: "PessoasJuridicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RG",
                table: "PessoasFisicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AssociadoId",
                table: "Contratacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contratacoes_AssociadoId",
                table: "Contratacoes",
                column: "AssociadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacoes_Associados_AssociadoId",
                table: "Contratacoes",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratacoes_Associados_AssociadoId",
                table: "Contratacoes");

            migrationBuilder.DropIndex(
                name: "IX_Contratacoes_AssociadoId",
                table: "Contratacoes");

            migrationBuilder.DropColumn(
                name: "AssociadoId",
                table: "Contratacoes");

            migrationBuilder.AlterColumn<int>(
                name: "InscricaoMunicipal",
                table: "PessoasJuridicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InscricaoEstadual",
                table: "PessoasJuridicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RG",
                table: "PessoasFisicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContratacaoId",
                table: "Associados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Associados_ContratacaoId",
                table: "Associados",
                column: "ContratacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associados_Contratacoes_ContratacaoId",
                table: "Associados",
                column: "ContratacaoId",
                principalTable: "Contratacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
