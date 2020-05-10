using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Dominio;
using ProjetoTeste.WebAPI.ViewModels;

namespace ProjetoTeste.WebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<RetornoVM>> Adicionar([FromBody]ProdutoViewModel produto)
        {
            var command = new AdicionarProdutoCommand(produto.Descricao, produto.Valor, produto.QuantidadeEmEstoque);
            var retorno = await Mediator.Send(command);

            if (!Guid.TryParse(retorno, out Guid guidAux)) { return BadRequest(retorno); }

            return Ok(guidAux.ToString());
        }

        [HttpPut()]
        public async Task<ActionResult> Alterar([FromBody] ProdutoViewModel produto)
        {
            Guid guidAux;

            if (Guid.TryParse(produto.Id, out guidAux))
            {
                var command = new AlterarProdutoCommand(guidAux, produto.Descricao, produto.Valor, produto.QuantidadeEmEstoque);
                var retorno = await Mediator.Send(command);

                if (!Guid.TryParse(retorno, out guidAux)) { return BadRequest(retorno); }
                return NoContent();
            }

            return BadRequest("Não foi possível converter o id em GUID");
        }
    }
}
