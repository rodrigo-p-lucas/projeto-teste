using ProjetoTeste.CrossCutting;
using ProjetoTeste.Negocio;
using System;
using System.Windows.Forms;

namespace ProjetoTeste.Console
{
    public partial class FormProduto : Form
    {
        Produto _produto;
        ManutencaoProduto _negocio;
        public FormProduto(Produto produto = null)
        {
            InitializeComponent();

            _produto = produto;

            if (produto == null)
            {
                _produto = new Produto();
            }

            _negocio = new ManutencaoProduto(null, null, _produto);
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = _produto.ProdutoCodigo.ToString();
            txtDescricao.Text = _produto.ProdutoDescricao;
            txtValor.Text = _produto.ProdutoValor.ToString();
            txtEstoque.Text = _produto.ProdutoQuantidadeEstoque.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AtualizarDadosProduto();
            _negocio.RealizarManutencaoProduto();
            MessageBox.Show("Manutenção realizada!");
            this.Close();
        }

        private void AtualizarDadosProduto()
        {
            _produto.ProdutoDescricao = txtDescricao.Text;
            _produto.ProdutoValor = double.Parse(txtValor.Text);
            _produto.ProdutoQuantidadeEstoque = int.Parse(txtEstoque.Text);
        }
    }
}
