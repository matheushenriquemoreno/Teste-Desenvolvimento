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
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Complemento).IsRequired().HasMaxLength(maxLength: 50);
        }
    }
}
