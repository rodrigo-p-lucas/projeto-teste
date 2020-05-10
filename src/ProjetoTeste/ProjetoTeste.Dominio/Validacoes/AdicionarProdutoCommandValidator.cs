using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public class AdicionarProdutoCommandValidator : ProdutoValidator<AdicionarProdutoCommand>
    {
        public AdicionarProdutoCommandValidator()
        {
            ValidarDescricao();
            ValidarValor();
            ValidarQtdEstoque();
        }
    }
}
