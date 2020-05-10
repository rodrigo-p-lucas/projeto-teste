using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        void Update(TEntity obj);
        int SaveChanges();
    }
}
