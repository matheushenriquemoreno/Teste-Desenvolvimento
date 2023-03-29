using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidoController : BaseController
    {
        private readonly IServicoPedido servicoPedido;

        public PedidoController(IServicoPedido servicoPedido)
        {
            this.servicoPedido = servicoPedido;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPedido(int id)
        {
            var pedidos = await servicoPedido.ObterPeloId(id);

            return Ok(pedidos);
        }

        [HttpPost("FazerPedido")]
        public async Task<IActionResult> FazerPedido([FromBody] PedidoCreateDTO pedido)
        {
            await servicoPedido.CriarPedido(pedido, User().Email);

            return Ok(new Result { message = "Pedido criado com sucesso" });
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPedidos()
        {
            var pedidos = await servicoPedido.ObterTodosPedidos();

            return Ok(pedidos);
        }
    }
}
