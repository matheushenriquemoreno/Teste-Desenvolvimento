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
    public class ProdutoMap : AuditoriaMap<Produto>
    {
        public override void ConfigurarOutrasPropriedades(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x =>x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x =>x.Quatidade).IsRequired();
            builder.Property(x =>x.Valor).IsRequired();
            builder.Property(x =>x.NomeProduto).IsRequired().HasMaxLength(50);
            builder.Property(x =>x.StatusDoProduto).IsRequired();
        }
    }
}
