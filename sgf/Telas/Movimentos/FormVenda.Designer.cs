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
            this.nud_parcelas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_data = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_receita = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bt_desativar = new System.Windows.Forms.Button();
            this.cbx_ativo = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.DGV_Lote = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lote)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_parcelas
            // 
            this.nud_parcelas.Location = new System.Drawing.Point(35, 137);
            this.nud_parcelas.Name = "nud_parcelas";
            this.nud_parcelas.Size = new System.Drawing.Size(63, 22);
            this.nud_parcelas.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 411);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "Vendas";
            // 
            // dtp_data
            // 
            this.dtp_data.Location = new System.Drawing.Point(35, 230);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.Size = new System.Drawing.Size(282, 22);
            this.dtp_data.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 78;
            this.label3.Text = "Data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 165);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 77;
            this.label10.Text = "Receita";
            // 
            // tb_receita
            // 
            this.tb_receita.Location = new System.Drawing.Point(35, 185);
            this.tb_receita.Margin = new System.Windows.Forms.Padding(4);
            this.tb_receita.Name = "tb_receita";
            this.tb_receita.Size = new System.Drawing.Size(282, 22);
            this.tb_receita.TabIndex = 76;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pix",
            "Cartão Débito",
            "Cartão Crédito",
            "Dinheiro"});
            this.comboBox1.Location = new System.Drawing.Point(35, 88);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 75;
            // 
            // bt_desativar
            // 
            this.bt_desativar.Location = new System.Drawing.Point(646, 395);
            this.bt_desativar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_desativar.Name = "bt_desativar";
            this.bt_desativar.Size = new System.Drawing.Size(100, 28);
            this.bt_desativar.TabIndex = 74;
            this.bt_desativar.Text = "Desativar";
            this.bt_desativar.UseVisualStyleBackColor = true;
            // 
            // cbx_ativo
            // 
            this.cbx_ativo.AutoSize = true;
            this.cbx_ativo.Location = new System.Drawing.Point(39, 357);
            this.cbx_ativo.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_ativo.Name = "cbx_ativo";
            this.cbx_ativo.Size = new System.Drawing.Size(59, 20);
            this.cbx_ativo.TabIndex = 73;
            this.cbx_ativo.Text = "Ativo";
            this.cbx_ativo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 72;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 71;
            this.label8.Text = "Quantidade";
            // 
            // tb_Qtd
            // 
            this.tb_Qtd.Location = new System.Drawing.Point(612, 121);
            this.tb_Qtd.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Qtd.Name = "tb_Qtd";
            this.tb_Qtd.Size = new System.Drawing.Size(99, 22);
            this.tb_Qtd.TabIndex = 70;
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(612, 195);
            this.btRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(100, 28);
            this.btRemover.TabIndex = 69;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(612, 153);
            this.btAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(100, 28);
            this.btAdicionar.TabIndex = 68;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(720, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 67;
            this.label7.Text = "Carrinho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Produtos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "Método de Pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Parcelas";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(35, 41);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(132, 22);
            this.tb_id.TabIndex = 62;
            // 
            // lb_carrinho
            // 
            this.lb_carrinho.FormattingEnabled = true;
            this.lb_carrinho.ItemHeight = 16;
            this.lb_carrinho.Location = new System.Drawing.Point(724, 73);
            this.lb_carrinho.Margin = new System.Windows.Forms.Padding(4);
            this.lb_carrinho.Name = "lb_carrinho";
            this.lb_carrinho.Size = new System.Drawing.Size(288, 260);
            this.lb_carrinho.TabIndex = 61;
            // 
            // lb_prod
            // 
            this.lb_prod.FormattingEnabled = true;
            this.lb_prod.ItemHeight = 16;
            this.lb_prod.Location = new System.Drawing.Point(324, 73);
            this.lb_prod.Margin = new System.Windows.Forms.Padding(4);
            this.lb_prod.Name = "lb_prod";
            this.lb_prod.Size = new System.Drawing.Size(279, 260);
            this.lb_prod.TabIndex = 60;
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(862, 395);
            this.btView.Margin = new System.Windows.Forms.Padding(4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(100, 28);
            this.btView.TabIndex = 59;
            this.btView.Text = "Visualizar";
            this.btView.UseVisualStyleBackColor = true;
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(754, 395);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(100, 28);
            this.btExcluir.TabIndex = 58;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(970, 395);
            this.btSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(100, 28);
            this.btSalvar.TabIndex = 57;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            // 
            // DGV_Lote
            // 
            this.DGV_Lote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Lote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Lote.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Lote.Location = new System.Drawing.Point(35, 431);
            this.DGV_Lote.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_Lote.Name = "DGV_Lote";
            this.DGV_Lote.ReadOnly = true;
            this.DGV_Lote.RowHeadersWidth = 51;
            this.DGV_Lote.Size = new System.Drawing.Size(1035, 185);
            this.DGV_Lote.TabIndex = 56;
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 631);
            this.Controls.Add(this.nud_parcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_receita);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bt_desativar);
            this.Controls.Add(this.cbx_ativo);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.DGV_Lote);
            this.Name = "FormVenda";
            this.Text = "FormVenda";
            this.Load += new System.EventHandler(this.FormVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lote)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bt_desativar;
        private System.Windows.Forms.CheckBox cbx_ativo;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.DataGridView DGV_Lote;
    }
}