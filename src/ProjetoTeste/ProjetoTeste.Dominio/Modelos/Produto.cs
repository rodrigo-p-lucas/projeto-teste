using System;

namespace ProjetoTeste.Dominio
{
    public class Produto : Entity
    {
        public string ProdutoDescricao { get; private set; }
        public double ProdutoValor { get; private set; }
        public int ProdutoQtdEstoque { get; private set; }

        public Produto(string produtoDescricao, double produtoValor, int produtoQtdEstoque)
        {
            Id = Guid.NewGuid();
            ProdutoDescricao = produtoDescricao;
            ProdutoValor = produtoValor;
            ProdutoQtdEstoque = produtoQtdEstoque;
        }

        public void AlterarDescricao(string novaDescricao)
        {
            ProdutoDescricao = novaDescricao;
        }

        public void AlterarValor(double novoValor)
        {
            ProdutoValor = novoValor;
        }

        public void AlterarQtdEstoque(int novaQtdEstoque)
        {
            ProdutoQtdEstoque = novaQtdEstoque;
        }
    }
}
