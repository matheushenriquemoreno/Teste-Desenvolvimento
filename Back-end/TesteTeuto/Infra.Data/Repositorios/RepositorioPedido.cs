using Domain.Entidades;
using Domain.Interfaces.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IRepositorioPedido
    {
        public RepositorioPedido(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Pedido> ObterPorIdAsync(int id)
        {
            return await _context.Set<Pedido>()
                .Include(x => x.Cliente)
                .ThenInclude(C => C.Endereco)
                .Include(x => x.Produtos)
                .ThenInclude(item => item.Produto)
                .Include(x => x.EnderecoEntrega)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async override Task<IEnumerable<Pedido>> ObterTodosAsync()
        {
            return await _context.Set<Pedido>()
                .Include(x => x.Cliente)
                .ThenInclude(C => C.Endereco)
                .Include(x => x.Produtos)
                .ThenInclude(item => item.Produto)
                .Include(x => x.EnderecoEntrega)
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
