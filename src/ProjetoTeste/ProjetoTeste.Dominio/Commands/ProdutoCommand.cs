using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string ProdutoDescricao { get; protected set; }
        public double ProdutoValor { get; protected set; }
        public int ProdutoQtdEstoque { get; protected set; }
    }
}
