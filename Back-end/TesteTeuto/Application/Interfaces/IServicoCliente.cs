using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IServicoCliente
    {
        Task<ClienteDTO> Add(ClienteDTO ClienteDTO, string emailUsuarioLogado);
        Task<ClienteDTO> ObterClientePeloID(int id);
        Task<IEnumerable<ClienteDTO>> ObterClientes();
        Task Remove(int id);
        Task Atualizar(ClienteDTO ClienteDTO, string emailUsuarioLogado);
    }
}
