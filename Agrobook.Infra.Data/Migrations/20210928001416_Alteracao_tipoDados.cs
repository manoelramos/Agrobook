using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_tipoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Associados_AssociadoId",
                table: "Contatos");

            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Contatos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssociadoId",
                table: "Contatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Associados_AssociadoId",
                table: "Contatos",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Associados_AssociadoId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "AssociadoId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Associados_AssociadoId",
                table: "Contatos",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
