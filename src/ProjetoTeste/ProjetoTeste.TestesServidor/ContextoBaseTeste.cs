using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Dominio;
using ProjetoTeste.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.TestesServidor
{
    public class ContextoBaseTeste
    {
        public static ProjetoTesteContext Create()
        {
            var options = new DbContextOptionsBuilder<ProjetoTesteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ProjetoTesteContext(options);

            context.Database.EnsureCreated();

            InserirDadosTeste(context);

            return context;
        }

        public static void InserirDadosTeste(ProjetoTesteContext context)
        {
            context.Produtos.AddRange(
                new Produto ("Produto1",10,100),
                new Produto ("Produto2",19,101),
                new Produto ("Produto3",18,102)
            );

            context.SaveChanges();
        }

        public static void Destroy(ProjetoTesteContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
