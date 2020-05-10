using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjetoTeste.CrossCutting
{
    public static class Configuracao
    {
        public const string configFileName = "ProjetoTeste.Console.exe.config";
        public const string connectionStringName = "ConnectionStringDefault";

        public static Configuration ArquivoConfiguracao { get; set; }

        public static string ConnectionString
        {

            get
            {
                //return "Server=(localdb)\\mssqllocaldb;Database=ProjetoTesteConsole;Trusted_Connection=True;MultipleActiveResultSets=true";
                string connectionString = String.Empty;

                foreach (ConnectionStringSettings connection in ArquivoConfiguracao.ConnectionStrings.ConnectionStrings)
                {
                    if (connection.Name.Equals(connectionStringName))
                    {
                        var connectionStringBuilder = new SqlConnectionStringBuilder(connection.ConnectionString);
                        connectionString = connectionStringBuilder.ConnectionString;
                    }
                }

                return connectionString;
            }
        }

        public static string UrlWebService
        {
            get
            {
                return ArquivoConfiguracao.AppSettings.Settings["UrlWebService"].Value;
            }
        }
    }
}
