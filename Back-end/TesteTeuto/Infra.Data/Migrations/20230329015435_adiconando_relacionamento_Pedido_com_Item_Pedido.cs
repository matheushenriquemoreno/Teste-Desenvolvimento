using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adiconando_relacionamento_Pedido_com_Item_Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Pedidos");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_IdProduto",
                table: "ItemPedido");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_IdProduto",
                table: "ItemPedido",
                column: "IdProduto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
