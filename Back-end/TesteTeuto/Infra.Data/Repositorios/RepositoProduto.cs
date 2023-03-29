using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interfaces.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class RepositoProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        public RepositoProduto(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Produto> ObterPorIdAsync(int id)
        {
            return await _context.Set<Produto>()
                .Include(x => x.PedidosDoProduto)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
