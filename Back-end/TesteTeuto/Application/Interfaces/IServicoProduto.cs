using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IServicoProduto
    {
        Task<ProdutoDTO> Add(ProdutoDTO ProdutoDTO, string emailUsuarioLogado);
        Task<ProdutoDTO> ObterProdutoPeloID(int id);
   
        Task<IEnumerable<ProdutoDTO>> ObterProdutos();
        Task<IEnumerable<ProdutoDTO>> ObterProdutosAtivos();
        Task Remove(int id);
        Task Atualizar(ProdutoDTO ProdutoDTO, string emailUsuarioLogado);
    }
}
