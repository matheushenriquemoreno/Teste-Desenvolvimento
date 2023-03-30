using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IServicoCliente servicoCliente;

        public ClienteController(IServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPeloID(int id)
        {
            var cliente = await servicoCliente.ObterClientePeloID(id);

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var cliente = await servicoCliente.ObterClientes();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteDTO clienteDTO)
        {
            var cliente = await servicoCliente.Add(clienteDTO, User.Email);

            return Created(nameof(ObterPeloID), new { id = cliente.Id });
        }

        [HttpPut]
        public async Task<IActionResult> AlterarCliente([FromBody] ClienteDTO clienteDTO)
        {
            await servicoCliente.Atualizar(clienteDTO, User.Email);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
            await servicoCliente.Remove(id);

            return Ok();
        }
    }
}
