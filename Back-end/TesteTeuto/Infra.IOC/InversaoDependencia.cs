using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repositorio;
using Infra.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC
{
    public static class InversaoDependencia
    {
        public static IServiceCollection AddDependencias(this IServiceCollection service)
        {
            service.AddScoped<IServicoCliente, ServicoCliente>();
            service.AddScoped<IServicoPedido, ServicoPedido>();
            service.AddScoped<IServicoProduto, ServicoProduto>();

            service.AddScoped<IRepositorioCliente, RepositorioCliente>();
            service.AddScoped<IRepositorioPedido, RepositorioPedido>();
            service.AddScoped<IRepositorioProduto, RepositoProduto>();

            return service;
        }
    }
}