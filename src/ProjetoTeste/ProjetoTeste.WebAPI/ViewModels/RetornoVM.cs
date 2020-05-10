using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebAPI.ViewModels
{
    public class RetornoVM
    {
        public RetornoVM(int status, string mensagem)
        {
            Status = status;
            Mensagem = mensagem;
        }

        public int Status { get; set; }
        public string Mensagem { get; set; }
    }
}
