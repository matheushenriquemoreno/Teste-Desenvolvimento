using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionando_auditoria_Endereco_Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioCriacao",
                table: "Pedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioEdicao",
                table: "Pedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioCriacao",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioEdicao",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioCriacao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioEdicao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioCriacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmailUsuarioEdicao",
                table: "Clientes");
        }
    }
}
