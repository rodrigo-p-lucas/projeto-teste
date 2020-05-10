using ProjetoTeste.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.TestesServidor
{
    public class IntegrationTestBase
    {

        public IntegrationTestBase()
        {
            Context = ContextoBaseTeste.Create();

            ProdutoRepositorioTest = new ProdutoRepository(Context);
        }

        public ProjetoTesteContext Context { get; }

        public ProdutoRepository ProdutoRepositorioTest { get; set; }

        public void Dispose()
        {
            ContextoBaseTeste.Destroy(Context);
        }
    }
}
