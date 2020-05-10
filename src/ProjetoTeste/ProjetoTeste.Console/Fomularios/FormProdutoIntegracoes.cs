using ProjetoTeste.CrossCutting;
using ProjetoTeste.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste.Console
{
    public partial class FormProdutoIntegracoes : Form
    {
        Produto _produto;
        List<ProdutoIntegracao> _integracoes;
        ManutencaoProduto _negocio;

        public FormProdutoIntegracoes(Produto produto)
        {
            InitializeComponent();

            _produto = produto;

            if (produto == null)
            {
                _produto = new Produto();
            }

            _negocio = new ManutencaoProduto(null, null, produto);

            CarregarIntegracoes();
        }

        private void CarregarIntegracoes()
        {
            _integracoes = _negocio.ConsultarListaIntegracoes(_produto.ProdutoCodigo);
            dgvIntegracoes.DataSource = _integracoes.OrderByDescending(i => i.IntegracaoData).ToList();
        }

        private void btnIntegrar_Click(object sender, EventArgs e)
        {
            _negocio.RealizarManutencaoProduto();
            MessageBox.Show("Integração enviada!");
            CarregarIntegracoes();
        }
    }
}
