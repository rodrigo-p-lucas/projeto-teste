using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Persistencia
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProjetoTesteContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ProjetoTesteContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
