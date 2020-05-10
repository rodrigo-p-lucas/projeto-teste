using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto GetByDescricao(string descricao);
    }
}
