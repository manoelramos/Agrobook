using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class RemocaoPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Paises_PaisId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_PaisId",
                table: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Estados_PaisId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PaisId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Estados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Iso = table.Column<string>(type: "varchar(2)", nullable: false),
                    Iso3 = table.Column<string>(type: "varchar(3)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PaisId",
                table: "Enderecos",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Paises_PaisId",
                table: "Enderecos",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_PaisId",
                table: "Estados",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id");
        }
    }
}
