using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetoTeste.CrossCutting
{
    public class ProdutoIntegracao
    {
        public ProdutoIntegracao()
        {

        }

        public ProdutoIntegracao(
            int produtoCodigo, 
            DateTime integracaoData, 
            Enumeradores.StatusIntegracao integracaoStatus, 
            string integracaoMensagem)
        {
            ProdutoCodigo = produtoCodigo;
            IntegracaoData = integracaoData;
            IntegracaoStatus = integracaoStatus;
            IntegracaoMensagem = integracaoMensagem;
        }

        public int ProdutoCodigo { get; set; }
        public DateTime IntegracaoData { get; set; }
        public Enumeradores.StatusIntegracao IntegracaoStatus { get; set; }
        public string IntegracaoMensagem { get; set; }

    }
}
