using Dapper;
using ProjetoTeste.CrossCutting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace ProjetoTeste.Dados
{
    public class Repositorio : IRepositorio
    {
        protected readonly string connectionString;

        protected Repositorio()
        {
            connectionString = Configuracao.ConnectionString;
        }

        public static Repositorio CriarRepositorio() => new Repositorio();

        public virtual List<Produto> ConsultarListaProdutos()
        {
            var retorno = new List<Produto>();

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "select ProdutoCodigo, ProdutoDescricao, ProdutoValor, ProdutoQuantidadeEstoque from Produto";

                retorno = cnn.Query<Produto>(sql).ToList();

                retorno.ForEach(prod =>
                {
                    prod.Integracoes = ConsultarListaIntegracoes(prod.ProdutoCodigo);
                });

            }

            return retorno;
        }

        public virtual List<ProdutoIntegracao> ConsultarListaIntegracoes(int produtoCodigo)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "select ProdutoCodigo, IntegracaoData, IntegracaoStatus, IntegracaoMensagem from ProdutoIntegracao where ProdutoCodigo = @ProdutoCodigo";

                var param = new DynamicParameters();
                param.Add("@ProdutoCodigo", produtoCodigo);

                return cnn.Query<ProdutoIntegracao>(sql, param).ToList();
            }
        }

        public virtual Produto ConsultarProduto(int produtoId)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "select ProdutoCodigo, ProdutoDescricao, ProdutoValor, ProdutoQuantidadeEstoque from Produto where ProdutoCodigo = @ProdutoCodigo";

                var param = new DynamicParameters();
                param.Add("@ProdutoCodigo", produtoId);

                return cnn.QueryFirstOrDefault<Produto>(sql, param);
            }
        }

        public virtual int CadastrarProduto(Produto novoProduto)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@ProdutoDescricao", novoProduto.ProdutoDescricao);
                param.Add("@ProdutoValor", novoProduto.ProdutoValor);
                param.Add("@ProdutoQuantidadeEstoque", novoProduto.ProdutoQuantidadeEstoque);
                param.Add("@ProdutoCodigo", 0, DbType.Int32, ParameterDirection.Output);

                string sql = "dbo.up_CadastrarProduto";

                var retorno = cnn.Execute(sql, param, commandType: CommandType.StoredProcedure);

                if (!retorno.Equals(1))
                    return 0;

                return param.Get<int>("@ProdutoCodigo");
            }
        }

        public virtual bool AtualizarProduto(Produto produtoAlterado)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@ProdutoCodigo", produtoAlterado.ProdutoCodigo);
                param.Add("@ProdutoDescricao", produtoAlterado.ProdutoDescricao);
                param.Add("@ProdutoValor", produtoAlterado.ProdutoValor);
                param.Add("@ProdutoQuantidadeEstoque", produtoAlterado.ProdutoQuantidadeEstoque);

                string sql = "dbo.up_AtualizarProduto";

                var retorno = cnn.Execute(sql, param, commandType: CommandType.StoredProcedure);

                return retorno.Equals(1);
            }
        }

        public virtual bool CadastrarIntegracao(ProdutoIntegracao novaIntegracao)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@ProdutoCodigo", novaIntegracao.ProdutoCodigo);
                param.Add("@IntegracaoData", novaIntegracao.IntegracaoData);
                param.Add("@IntegracaoStatus", novaIntegracao.IntegracaoStatus);
                param.Add("@IntegracaoMensagem", novaIntegracao.IntegracaoMensagem);

                string sql = "dbo.up_CadastrarIntegracao";

                var retorno = cnn.Execute(sql, param, commandType: CommandType.StoredProcedure);

                return retorno.Equals(1);
            }
        }
    }
}
