using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    public interface IRepositorioBase<T> where T : IEntidadeBase
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> expression);
        Task<T> ObterPorIdAsync(int id);
        Task<T> Adicionar(T entidade);
        Task<T> Update(T entidade);
        Task Remover(T entidade);
        Task Salvar();
    }
}
