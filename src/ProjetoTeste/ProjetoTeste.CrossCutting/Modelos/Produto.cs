using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.CrossCutting
{
    public class Produto
    {
        public int ProdutoCodigo { get; set; }
        public string ProdutoDescricao { get; set; }
        public double ProdutoValor { get; set; }
        public int ProdutoQuantidadeEstoque { get; set; }

        public List<ProdutoIntegracao> Integracoes { get; set; }

        public Produto()
        {
            ProdutoCodigo = 0;
            ProdutoDescricao = "";
            ProdutoValor = 0;
            ProdutoQuantidadeEstoque = 0;
            Integracoes = new List<ProdutoIntegracao>();
        }

        public bool ValidarProduto()
        {
            //TODO
            return true;
        }
    }
}
