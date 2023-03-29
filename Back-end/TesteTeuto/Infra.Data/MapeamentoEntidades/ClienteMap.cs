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
    public class ClienteMap : AuditoriaMap<Cliente>
    {
        public override void ConfigurarOutrasPropriedades(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteStatus).IsRequired();
            builder.Property<int>("IdEndereco");

            builder.HasOne(c => c.Endereco)
                .WithOne()
                .HasForeignKey<Cliente>("IdEndereco");
        }
    }
}
