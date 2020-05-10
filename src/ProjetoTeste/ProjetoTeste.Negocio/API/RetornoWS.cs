using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Negocio
{
    public class RetornoWS
    {
        public RetornoWS(int status, string codigoIntegracao)
        {
            Status = status;
            CodigoIntegracao = codigoIntegracao;
        }

        public int Status { get; set; }
        public string CodigoIntegracao { get; set; }

    }
}
