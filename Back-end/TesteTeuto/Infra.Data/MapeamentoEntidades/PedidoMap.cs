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
    public class PedidoMap : AuditoriaMap<Pedido>
    {
        public override void ConfigurarOutrasPropriedades(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);
            builder.Property<int>("IdCliente");
            builder.Property<int>("IdEndereco");

            builder.HasMany(p => p.Produtos)
                .WithOne(ip => ip.PedidoDoProduto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("IdPedido");

            builder.HasOne(P => P.EnderecoEntrega)
                .WithOne()
                .HasForeignKey<Pedido>("IdEndereco");

            builder.HasOne(p => p.Cliente)
                  .WithMany(cliente => cliente.PedidosDoCliente)
                  .HasForeignKey("IdCliente");
        }
    }
}
