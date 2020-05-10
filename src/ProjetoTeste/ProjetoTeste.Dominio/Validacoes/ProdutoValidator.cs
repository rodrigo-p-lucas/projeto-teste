using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public abstract class ProdutoValidator<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidarId()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Para esta operação, o ID do produto deve ser informado");
        }

        protected void ValidarDescricao()
        {
            RuleFor(p => p.ProdutoDescricao)
                .NotEmpty().WithMessage("Descrição do produto não pode ser vazia")
                .Length(2, 150).WithMessage("Descrição deve conter entre 2 a 150 caracteres");
        }

        protected void ValidarValor()
        {
            RuleFor(p => p.ProdutoValor)
                .GreaterThanOrEqualTo(0).WithMessage($"Valor do produto não pode ser negativo");
        }

        protected void ValidarQtdEstoque()
        {
            

            RuleFor(p => p.ProdutoQtdEstoque)
                .GreaterThanOrEqualTo(0).WithMessage("Quantidade em estoque não pode ser negativa");
        }
    }
}
