using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/Produtos")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IServicoProduto servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            this.servicoProduto = servicoProduto;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPeloID(int id)
        {
            var Produto = await servicoProduto.ObterProdutoPeloID(id);

            return Ok(Produto);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var Produto = await servicoProduto.ObterProdutos();

            return Ok(Produto);
        }

        [HttpGet("Ativos")]
        public async Task<IActionResult> ObterProdutosAtivos()
        {
            var Produto = await servicoProduto.ObterProdutosAtivos();

            return Ok(Produto);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDTO)
        {

            var produto = await servicoProduto.Add(produtoDTO, User().Email);
            
            return Created(nameof(ObterPeloID), new { id = produto.Id });
        }

        [HttpPut]
        public async Task<IActionResult> AlterarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            await servicoProduto.Atualizar(produtoDTO, User().Email);
            
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
            await servicoProduto.Remove(id);

            return Ok();
        }
    }
}
