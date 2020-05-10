namespace ProjetoTeste.Console
{
    partial class FormProdutoIntegracoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnIntegrar = new System.Windows.Forms.Button();
            this.dgvIntegracoes = new System.Windows.Forms.DataGridView();
            this.integracaoDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integracaoStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integracaoMensagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoIntegracaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegracoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoIntegracaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIntegrar
            // 
            this.btnIntegrar.Location = new System.Drawing.Point(366, 212);
            this.btnIntegrar.Name = "btnIntegrar";
            this.btnIntegrar.Size = new System.Drawing.Size(75, 23);
            this.btnIntegrar.TabIndex = 0;
            this.btnIntegrar.Text = "Integrar";
            this.btnIntegrar.UseVisualStyleBackColor = true;
            this.btnIntegrar.Click += new System.EventHandler(this.btnIntegrar_Click);
            // 
            // dgvIntegracoes
            // 
            this.dgvIntegracoes.AllowUserToAddRows = false;
            this.dgvIntegracoes.AllowUserToDeleteRows = false;
            this.dgvIntegracoes.AutoGenerateColumns = false;
            this.dgvIntegracoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntegracoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.integracaoDataDataGridViewTextBoxColumn,
            this.integracaoStatusDataGridViewTextBoxColumn,
            this.integracaoMensagemDataGridViewTextBoxColumn});
            this.dgvIntegracoes.DataSource = this.produtoIntegracaoBindingSource;
            this.dgvIntegracoes.Location = new System.Drawing.Point(12, 31);
            this.dgvIntegracoes.Name = "dgvIntegracoes";
            this.dgvIntegracoes.ReadOnly = true;
            this.dgvIntegracoes.Size = new System.Drawing.Size(429, 175);
            this.dgvIntegracoes.TabIndex = 1;
            // 
            // integracaoDataDataGridViewTextBoxColumn
            // 
            this.integracaoDataDataGridViewTextBoxColumn.DataPropertyName = "IntegracaoData";
            this.integracaoDataDataGridViewTextBoxColumn.HeaderText = "Data Integração";
            this.integracaoDataDataGridViewTextBoxColumn.Name = "integracaoDataDataGridViewTextBoxColumn";
            this.integracaoDataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // integracaoStatusDataGridViewTextBoxColumn
            // 
            this.integracaoStatusDataGridViewTextBoxColumn.DataPropertyName = "IntegracaoStatus";
            this.integracaoStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.integracaoStatusDataGridViewTextBoxColumn.Name = "integracaoStatusDataGridViewTextBoxColumn";
            this.integracaoStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.integracaoStatusDataGridViewTextBoxColumn.Width = 70;
            // 
            // integracaoMensagemDataGridViewTextBoxColumn
            // 
            this.integracaoMensagemDataGridViewTextBoxColumn.DataPropertyName = "IntegracaoMensagem";
            this.integracaoMensagemDataGridViewTextBoxColumn.HeaderText = "Mensagem";
            this.integracaoMensagemDataGridViewTextBoxColumn.Name = "integracaoMensagemDataGridViewTextBoxColumn";
            this.integracaoMensagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.integracaoMensagemDataGridViewTextBoxColumn.Width = 200;
            // 
            // produtoIntegracaoBindingSource
            // 
            this.produtoIntegracaoBindingSource.DataSource = typeof(ProjetoTeste.CrossCutting.ProdutoIntegracao);
            // 
            // FormProdutoIntegracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 247);
            this.Controls.Add(this.dgvIntegracoes);
            this.Controls.Add(this.btnIntegrar);
            this.Name = "FormProdutoIntegracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Integrações";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegracoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoIntegracaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntegrar;
        private System.Windows.Forms.DataGridView dgvIntegracoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn integracaoDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn integracaoStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn integracaoMensagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource produtoIntegracaoBindingSource;
    }
}