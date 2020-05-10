using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public class AlterarProdutoCommandValidator : ProdutoValidator<AlterarProdutoCommand>
    {
        public AlterarProdutoCommandValidator()
        {
            ValidarId();
            ValidarDescricao();
            ValidarValor();
            ValidarQtdEstoque();
        }
    }
}
