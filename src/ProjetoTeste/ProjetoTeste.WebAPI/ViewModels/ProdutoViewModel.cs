using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebAPI
{
    public class ProdutoViewModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
