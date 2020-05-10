using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTeste.Dominio
{
    public class ProdutoCommandHandler : 
        IRequestHandler<AdicionarProdutoCommand, string>,
        IRequestHandler<AlterarProdutoCommand, string>
    {
        private readonly IProdutoRepository repository;

        public ProdutoCommandHandler(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var erroValidacao = request.ErrorMessage();
            if (erroValidacao != null)
            {
                return Task.FromResult(erroValidacao);
            }

            var produto = new Produto(request.ProdutoDescricao, request.ProdutoValor, request.ProdutoQtdEstoque);

            if(repository.GetByDescricao(produto.ProdutoDescricao) != null)
            {
                return Task.FromResult("Já existe produto com esta descrição");
            }

            repository.Add(produto);
            repository.SaveChanges();

            var novoProduto = repository.GetByDescricao(produto.ProdutoDescricao);

            return Task.FromResult(novoProduto.Id.ToString());
        }

        public Task<string> Handle(AlterarProdutoCommand request, CancellationToken cancellationToken)
        {
            var erroValidacao = request.ErrorMessage();
            if (erroValidacao != null)
            {
                return Task.FromResult(erroValidacao);
            }


            var produto = repository.GetById(request.Id);
            if (produto == null)
            {
                return Task.FromResult("Produto não encotrando para o id informado");
            }

            var outroProdutoComMesmaDescricao = repository.GetByDescricao(request.ProdutoDescricao);
            if (outroProdutoComMesmaDescricao != null && outroProdutoComMesmaDescricao != produto)
            {
                return Task.FromResult("Já existe produto com esta descrição");
            }

            produto.AlterarDescricao(request.ProdutoDescricao);
            produto.AlterarValor(request.ProdutoValor);
            produto.AlterarQtdEstoque(request.ProdutoQtdEstoque);

            repository.SaveChanges();

            return Task.FromResult(produto.Id.ToString());
        }
    }
}
