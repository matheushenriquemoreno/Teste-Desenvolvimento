using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interfaces.Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios.Base
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntidadeBase
    {
        protected readonly DbContext _context;

        public RepositorioBase(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        protected DbSet<T> Entidade() => _context.Set<T>();


        public virtual async Task<T> ObterPorIdAsync(int id)
        {
            return await Entidade().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> expression)
        {
            var dados = Entidade().OrderByDescending(x => x.Id).AsNoTracking().Where(expression);
           
            return Task.FromResult<IEnumerable<T>>(dados);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await Entidade().OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }
        public async Task<T> Adicionar(T entidade)
        {
            await Entidade().AddAsync(entidade);
            await Salvar();
            return entidade;
        }

        public async Task Remover(T entidade)
        {
            _context.Remove(entidade);
            await Salvar();
        }

        public async Task<T> Update(T entidade)
        {
            Entidade().Update(entidade);
            await Salvar();
            return entidade;
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
