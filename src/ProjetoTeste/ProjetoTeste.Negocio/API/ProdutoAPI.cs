using ProjetoTeste.CrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Negocio
{
    public class ProdutoAPI
    {
        Guid _guidAux;
        public ProdutoAPI(string id, string produtoDescricao, double produtoValor, int produtoQtdEstoque)
        {
            Id = Guid.TryParse(id, out _guidAux) ? (Guid?)_guidAux : null;
            Descricao = produtoDescricao;
            Valor = produtoValor;
            QuantidadeEmEstoque = produtoQtdEstoque;
        }

        public ProdutoAPI(Produto produto, string codigoIntegracao = null)
        {
            Id = Guid.TryParse(codigoIntegracao, out _guidAux) ? (Guid?)_guidAux : null;
            Descricao = produto.ProdutoDescricao;
            Valor = produto.ProdutoValor;
            QuantidadeEmEstoque = produto.ProdutoQuantidadeEstoque;
        }

        public Guid? Id { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
    }
}
