using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interfaces.Base;
using Domain.Interfaces.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _context.Set<Cliente>()
                .Include(x => x.Endereco)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Cliente> ObterPorIdAsync(int id)
        {
            return await _context.Set<Cliente>()
                .Include(x => x.Endereco)
                .Include(x => x.PedidosDoCliente)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
