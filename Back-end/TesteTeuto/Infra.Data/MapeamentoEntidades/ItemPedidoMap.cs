using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.MapeamentoEntidades
{
    internal class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property<int>("IdProduto");
            builder.Property<int>("IdPedido");

            builder.HasOne(itemPedido => itemPedido.Produto)
           .WithMany(p => p.PedidosDoProduto)
           .HasForeignKey("IdProduto");
        }
    }
}
