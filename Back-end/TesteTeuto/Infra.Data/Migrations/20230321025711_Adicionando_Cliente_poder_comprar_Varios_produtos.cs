using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Cliente_poder_comprar_Varios_produtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Clientes_IdCliente",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdCliente",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "QuantidadeItens",
                table: "Pedidos",
                newName: "IdEndereco");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdEndereco",
                table: "Pedidos",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_IdPedido",
                table: "ItemPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_IdProduto",
                table: "ItemPedido",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Endereco_IdEndereco",
                table: "Clientes",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Endereco_IdEndereco",
                table: "Pedidos",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Endereco_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Endereco_IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "IdEndereco",
                table: "Pedidos",
                newName: "QuantidadeItens");

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCliente",
                table: "Endereco",
                column: "IdCliente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Clientes_IdCliente",
                table: "Endereco",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
