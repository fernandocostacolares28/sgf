namespace sgf.Telas.Movimentos
{
    partial class FormVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVenda));
            this.nud_parcelas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_data = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_receita = new System.Windows.Forms.TextBox();
            this.cb_metodo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Qtd = new System.Windows.Forms.TextBox();
            this.btRemover = new System.Windows.Forms.Button();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_carrinho = new System.Windows.Forms.ListBox();
            this.lb_prod = new System.Windows.Forms.ListBox();
            this.btView = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.DGV_Venda = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_totalvenda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_desconto = new System.Windows.Forms.TextBox();
            this.bt_desconto = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_cliente = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Venda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nud_parcelas
            // 
            this.nud_parcelas.Location = new System.Drawing.Point(26, 111);
            this.nud_parcelas.Margin = new System.Windows.Forms.Padding(2);
            this.nud_parcelas.Name = "nud_parcelas";
            this.nud_parcelas.Size = new System.Drawing.Size(47, 20);
            this.nud_parcelas.TabIndex = 81;
            this.nud_parcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Vendas";
            // 
            // dtp_data
            // 
            this.dtp_data.Location = new System.Drawing.Point(26, 187);
            this.dtp_data.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.Size = new System.Drawing.Size(212, 20);
            this.dtp_data.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Receita";
            // 
            // tb_receita
            // 
            this.tb_receita.Location = new System.Drawing.Point(26, 150);
            this.tb_receita.Name = "tb_receita";
            this.tb_receita.Size = new System.Drawing.Size(212, 20);
            this.tb_receita.TabIndex = 76;
            // 
            // cb_metodo
            // 
            this.cb_metodo.FormattingEnabled = true;
            this.cb_metodo.Items.AddRange(new object[] {
            "Pix",
            "Cartão Débito",
            "Cartão Crédito",
            "Dinheiro"});
            this.cb_metodo.Location = new System.Drawing.Point(26, 72);
            this.cb_metodo.Name = "cb_metodo";
            this.cb_metodo.Size = new System.Drawing.Size(121, 21);
            this.cb_metodo.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Quantidade";
            // 
            // tb_Qtd
            // 
            this.tb_Qtd.Location = new System.Drawing.Point(504, 102);
            this.tb_Qtd.Name = "tb_Qtd";
            this.tb_Qtd.Size = new System.Drawing.Size(75, 20);
            this.tb_Qtd.TabIndex = 70;
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(504, 162);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(75, 23);
            this.btRemover.TabIndex = 69;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(504, 128);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btAdicionar.TabIndex = 68;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(585, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Carrinho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Produtos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Método de Pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Parcelas";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(26, 33);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(100, 20);
            this.tb_id.TabIndex = 62;
            // 
            // lb_carrinho
            // 
            this.lb_carrinho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_carrinho.FormattingEnabled = true;
            this.lb_carrinho.Location = new System.Drawing.Point(588, 63);
            this.lb_carrinho.Name = "lb_carrinho";
            this.lb_carrinho.Size = new System.Drawing.Size(252, 212);
            this.lb_carrinho.TabIndex = 61;
            // 
            // lb_prod
            // 
            this.lb_prod.FormattingEnabled = true;
            this.lb_prod.Location = new System.Drawing.Point(288, 63);
            this.lb_prod.Name = "lb_prod";
            this.lb_prod.Size = new System.Drawing.Size(210, 212);
            this.lb_prod.TabIndex = 60;
            this.lb_prod.SelectedIndexChanged += new System.EventHandler(this.lb_prod_SelectedIndexChanged);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(646, 321);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(75, 23);
            this.btView.TabIndex = 59;
            this.btView.Text = "Visualizar";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(566, 321);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 58;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(728, 321);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 23);
            this.btSalvar.TabIndex = 57;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // DGV_Venda
            // 
            this.DGV_Venda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Venda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Venda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Venda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Venda.Location = new System.Drawing.Point(12, 350);
            this.DGV_Venda.Name = "DGV_Venda";
            this.DGV_Venda.ReadOnly = true;
            this.DGV_Venda.RowHeadersWidth = 51;
            this.DGV_Venda.Size = new System.Drawing.Size(828, 168);
            this.DGV_Venda.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 83;
            this.label12.Text = "Total";
            // 
            // tb_totalvenda
            // 
            this.tb_totalvenda.Location = new System.Drawing.Point(25, 296);
            this.tb_totalvenda.Name = "tb_totalvenda";
            this.tb_totalvenda.ReadOnly = true;
            this.tb_totalvenda.Size = new System.Drawing.Size(212, 20);
            this.tb_totalvenda.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "Desconto";
            // 
            // tb_desconto
            // 
            this.tb_desconto.Location = new System.Drawing.Point(246, 296);
            this.tb_desconto.Name = "tb_desconto";
            this.tb_desconto.Size = new System.Drawing.Size(72, 20);
            this.tb_desconto.TabIndex = 84;
            // 
            // bt_desconto
            // 
            this.bt_desconto.Location = new System.Drawing.Point(354, 293);
            this.bt_desconto.Name = "bt_desconto";
            this.bt_desconto.Size = new System.Drawing.Size(123, 23);
            this.bt_desconto.TabIndex = 86;
            this.bt_desconto.Text = "Aplicar Desconto";
            this.bt_desconto.UseVisualStyleBackColor = true;
            this.bt_desconto.Click += new System.EventHandler(this.bt_desconto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(324, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "%";
            // 
            // cb_cliente
            // 
            this.cb_cliente.FormattingEnabled = true;
            this.cb_cliente.Location = new System.Drawing.Point(25, 225);
            this.cb_cliente.Name = "cb_cliente";
            this.cb_cliente.Size = new System.Drawing.Size(121, 21);
            this.cb_cliente.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 88;
            this.label14.Text = "Cliente";
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Location = new System.Drawing.Point(340, 40);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(158, 20);
            this.tb_pesquisa.TabIndex = 90;
            this.tb_pesquisa.TextChanged += new System.EventHandler(this.tb_pesquisa_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 22);
            this.panel1.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(715, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "by Fernando Costa Colares";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "V 3.0 - 2024";
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_pesquisa);
            this.Controls.Add(this.cb_cliente);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bt_desconto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_desconto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tb_totalvenda);
            this.Controls.Add(this.nud_parcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_receita);
            this.Controls.Add(this.cb_metodo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_Qtd);
            this.Controls.Add(this.btRemover);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.lb_carrinho);
            this.Controls.Add(this.lb_prod);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.DGV_Venda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVenda";
            this.Load += new System.EventHandler(this.FormVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Venda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_parcelas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_receita;
        private System.Windows.Forms.ComboBox cb_metodo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Qtd;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.ListBox lb_carrinho;
        private System.Windows.Forms.ListBox lb_prod;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.DataGridView DGV_Venda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_totalvenda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_desconto;
        private System.Windows.Forms.Button bt_desconto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_cliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
    }
}