using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_DadosBancarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasBancarias");

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Contratacoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banco = table.Column<int>(type: "int", nullable: false),
                    Agencia = table.Column<int>(type: "int", nullable: false),
                    Conta = table.Column<int>(type: "int", nullable: false),
                    TipoPix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIX = table.Column<int>(type: "int", nullable: false),
                    AssociadoId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_Associados_AssociadoId",
                        column: x => x.AssociadoId,
                        principalTable: "Associados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_AssociadoId",
                table: "DadosBancarios",
                column: "AssociadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Contratacoes");

            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agencia = table.Column<int>(type: "int", nullable: false),
                    AssociadoId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Banco = table.Column<int>(type: "int", nullable: false),
                    Conta = table.Column<int>(type: "int", nullable: false),
                    Instituicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PIX = table.Column<int>(type: "int", nullable: false),
                    TipoPix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasBancarias_Associados_AssociadoId",
                        column: x => x.AssociadoId,
                        principalTable: "Associados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasBancarias_AssociadoId",
                table: "ContasBancarias",
                column: "AssociadoId");
        }
    }
}
