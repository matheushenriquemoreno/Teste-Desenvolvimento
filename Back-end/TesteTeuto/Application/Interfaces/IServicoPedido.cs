using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IServicoPedido
    {
        Task CriarPedido(PedidoCreateDTO pedido, string emailUsuarioLogado);
        Task<decimal> ObterValorDoPedido(int idProduto, int quantidade);
        Task CancelarPedido(int idPedido, string emailUsuarioLogado);
        Task<IEnumerable<PedidoDTO>> ObterTodosPedidos();
        Task<PedidoDTO> ObterPeloId(int id);
    }
}
