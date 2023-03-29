using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionando_auditoria_produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioCriacao",
                table: "Produtos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioEdicao",
                table: "Produtos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusDoProduto",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioCriacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioEdicao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "StatusDoProduto",
                table: "Produtos");
        }
    }
}
