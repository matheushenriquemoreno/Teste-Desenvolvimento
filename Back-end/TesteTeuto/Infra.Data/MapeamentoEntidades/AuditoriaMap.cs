using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.MapeamentoEntidades
{
    public abstract class AuditoriaMap<T> : IEntityTypeConfiguration<T> where T : Auditoria
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.DataDeCriacao);
           builder.Property(x => x.DataAtualizacao).IsRequired(false);
           builder.Property(x => x.EmailUsuarioCriacao).HasMaxLength(150);
           builder.Property(x => x.EmailUsuarioEdicao).HasMaxLength(150);

           ConfigurarOutrasPropriedades(builder);
        }

        public abstract void ConfigurarOutrasPropriedades(EntityTypeBuilder<T> builder);
    }
}
