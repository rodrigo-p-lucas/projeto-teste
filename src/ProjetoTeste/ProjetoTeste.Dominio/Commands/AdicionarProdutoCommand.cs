using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public class AdicionarProdutoCommand : ProdutoCommand
    {
        public AdicionarProdutoCommand(string produtoDescricao, double produtoValor, int produtoQtdEstoque)
        {
            ProdutoDescricao = produtoDescricao;
            ProdutoValor = produtoValor;
            ProdutoQtdEstoque = produtoQtdEstoque;
        }

        public override string ErrorMessage()
        {
            var validator = new AdicionarProdutoCommandValidator();
            ValidationResult = validator.Validate(this);

            var failures = ValidationResult
                .Errors
                .Where(e => e != null)
                .ToList();

            if (failures.Count != 0)
            {
                var mensagensErro = failures
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return string.Join("|", mensagensErro);
            }

            return null;
        }
    }
}
