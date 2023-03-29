using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Mappeamento;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC
{
    public static class ConfigurarInfra
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(MapeamentoGeral));

            service.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return service;
        }
    }
}
