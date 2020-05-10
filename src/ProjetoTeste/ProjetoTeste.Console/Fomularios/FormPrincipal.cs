using ProjetoTeste.CrossCutting;
using ProjetoTeste.Negocio;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste.Console
{
    public partial class FormPrincipal : Form
    {
        ManutencaoProduto _produtoHandler;

        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            string nomeAppConfig = Configuracao.configFileName;

            FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
            Directory.SetCurrentDirectory(fileInfo.DirectoryName);

            if (File.Exists(Path.Combine(fileInfo.DirectoryName, nomeAppConfig)))
            {
                CarregarArquivoConfiguracao(Path.Combine(fileInfo.DirectoryName, nomeAppConfig));
            }

            _produtoHandler = new ManutencaoProduto();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            var produtos = _produtoHandler.ConsultarListaProdutos();

            dgvProdutos.DataSource = produtos.Select(p => new ProdutoVM
            {
                Codigo = p.ProdutoCodigo,
                Descricao = p.ProdutoDescricao,
                Valor = p.ProdutoValor,
                Estoque = p.ProdutoQuantidadeEstoque,
                Integrado = p.Integracoes
                    .DefaultIfEmpty(new ProdutoIntegracao { IntegracaoStatus = Enumeradores.StatusIntegracao.NaoIntegrado })
                    .OrderByDescending(i => i.IntegracaoData)
                    .FirstOrDefault()
                    .IntegracaoStatus.ToString()
            }).ToList();
        }

        private void CarregarArquivoConfiguracao(String path)
        {
            try
            {
                ExeConfigurationFileMap fileConfig = new ExeConfigurationFileMap();

                fileConfig.ExeConfigFilename = path;
                Configuracao.ArquivoConfiguracao = ConfigurationManager.OpenMappedExeConfiguration(fileConfig, ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar arquivo de configuração!\n" + ex.Message, "ProjetoTeste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(4))
            {
                AbrirJanelaintegracao();
            }
        }
        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            AbrirJanelaProduto();
        }

        private void AbrirJanelaProduto(Produto produto = null)
        {
            FormProduto formProduto = new FormProduto(produto);
            formProduto.ShowDialog();
            formProduto.Dispose();

            CarregarProdutos();
        }

        private void AbrirJanelaintegracao()
        {
            Produto produtoSelecionado = MontarProdutoSelecionado();

            FormProdutoIntegracoes formIntegracoes = new FormProdutoIntegracoes(produtoSelecionado);
            formIntegracoes.ShowDialog();
            formIntegracoes.Dispose();

            CarregarProdutos();
        }

        private void btnAlterarProduto_Click(object sender, EventArgs e)
        {
            Produto produtoSelecionado = MontarProdutoSelecionado();
            if (produtoSelecionado != null)
            {
                AbrirJanelaProduto(produtoSelecionado);
            }
        }

        private Produto MontarProdutoSelecionado()
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Favor selecione um produto!");
                return null;
            }

            var linhaSelecionada = dgvProdutos.SelectedRows[0];
            var produtoSelecionado = new Produto
            {
                ProdutoCodigo = (int)linhaSelecionada.Cells[0].Value,
                ProdutoDescricao = linhaSelecionada.Cells[1].Value.ToString(),
                ProdutoValor = (double)linhaSelecionada.Cells[2].Value,
                ProdutoQuantidadeEstoque = (int)linhaSelecionada.Cells[3].Value
            };
            return produtoSelecionado;
        }
    }
}
