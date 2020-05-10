using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.WebAPI
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public double QuantidadeEmEstoque { get; set; }
    }
}
