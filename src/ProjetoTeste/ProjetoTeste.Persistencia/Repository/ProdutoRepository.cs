using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoTeste.Persistencia
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoTesteContext context) : base(context)
        {
        }

        public Produto GetByDescricao(string descricao)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => p.ProdutoDescricao.Equals(descricao));
        }
    }
}
