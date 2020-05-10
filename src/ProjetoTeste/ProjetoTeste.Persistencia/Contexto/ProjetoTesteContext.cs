using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Dominio;
using System;
using System.Reflection;

namespace ProjetoTeste.Persistencia
{
    public class ProjetoTesteContext : DbContext
    {
        public ProjetoTesteContext(DbContextOptions<ProjetoTesteContext> options) : base(options) 
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
