﻿namespace sgf.Telas.Cadastros.Lote
{
    partial class FormCadLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadLote));
            this.DGV_Lote = new System.Windows.Forms.DataGridView();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.lb_pc = new System.Windows.Forms.ListBox();
            this.lb_pl = new System.Windows.Forms.ListBox();
            this.cb_fornecedor = new System.Windows.Forms.ComboBox();
            this.tb_vencimento = new System.Windows.Forms.TextBox();
            this.tb_codelote = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.tb_Qtd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbx_ativo = new System.Windows.Forms.CheckBox();
            this.bt_desativar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lote)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Lote
            // 
            this.DGV_Lote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Lote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Lote.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Lote.Location = new System.Drawing.Point(16, 427);
            this.DGV_Lote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_Lote.Name = "DGV_Lote";
            this.DGV_Lote.ReadOnly = true;
            this.DGV_Lote.RowHeadersWidth = 51;
            this.DGV_Lote.Size = new System.Drawing.Size(1035, 185);
            this.DGV_Lote.TabIndex = 0;
            this.DGV_Lote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Lote_CellContentClick);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(951, 391);
            this.btSalvar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(100, 28);
            this.btSalvar.TabIndex = 1;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(735, 391);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(100, 28);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(843, 391);
            this.btView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(100, 28);
            this.btView.TabIndex = 3;
            this.btView.Text = "Visualizar";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // lb_pc
            // 
            this.lb_pc.FormattingEnabled = true;
            this.lb_pc.ItemHeight = 16;
            this.lb_pc.Location = new System.Drawing.Point(305, 69);
            this.lb_pc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_pc.Name = "lb_pc";
            this.lb_pc.Size = new System.Drawing.Size(279, 260);
            this.lb_pc.TabIndex = 4;
            this.lb_pc.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lb_pl
            // 
            this.lb_pl.FormattingEnabled = true;
            this.lb_pl.ItemHeight = 16;
            this.lb_pl.Location = new System.Drawing.Point(705, 69);
            this.lb_pl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_pl.Name = "lb_pl";
            this.lb_pl.Size = new System.Drawing.Size(288, 260);
            this.lb_pl.TabIndex = 5;
            // 
            // cb_fornecedor
            // 
            this.cb_fornecedor.FormattingEnabled = true;
            this.cb_fornecedor.Location = new System.Drawing.Point(16, 230);
            this.cb_fornecedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_fornecedor.Name = "cb_fornecedor";
            this.cb_fornecedor.Size = new System.Drawing.Size(160, 24);
            this.cb_fornecedor.TabIndex = 6;
            // 
            // tb_vencimento
            // 
            this.tb_vencimento.Location = new System.Drawing.Point(19, 133);
            this.tb_vencimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_vencimento.Name = "tb_vencimento";
            this.tb_vencimento.Size = new System.Drawing.Size(132, 22);
            this.tb_vencimento.TabIndex = 7;
            // 
            // tb_codelote
            // 
            this.tb_codelote.Location = new System.Drawing.Point(16, 85);
            this.tb_codelote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_codelote.Name = "tb_codelote";
            this.tb_codelote.Size = new System.Drawing.Size(132, 22);
            this.tb_codelote.TabIndex = 8;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(16, 37);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(132, 22);
            this.tb_id.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 404);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lotes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vencimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fornecedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "ID";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Código Lote";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Produtos Cadastrados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(701, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Produtos Lotes";
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(593, 149);
            this.btAdicionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(100, 28);
            this.btAdicionar.TabIndex = 17;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(593, 191);
            this.btRemover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(100, 28);
            this.btRemover.TabIndex = 18;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // tb_Qtd
            // 
            this.tb_Qtd.Location = new System.Drawing.Point(593, 117);
            this.tb_Qtd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Qtd.Name = "tb_Qtd";
            this.tb_Qtd.Size = new System.Drawing.Size(99, 22);
            this.tb_Qtd.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(589, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Quantidade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 334);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Status";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // cbx_ativo
            // 
            this.cbx_ativo.AutoSize = true;
            this.cbx_ativo.Location = new System.Drawing.Point(20, 353);
            this.cbx_ativo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_ativo.Name = "cbx_ativo";
            this.cbx_ativo.Size = new System.Drawing.Size(59, 20);
            this.cbx_ativo.TabIndex = 22;
            this.cbx_ativo.Text = "Ativo";
            this.cbx_ativo.UseVisualStyleBackColor = true;
            // 
            // bt_desativar
            // 
            this.bt_desativar.Location = new System.Drawing.Point(627, 391);
            this.bt_desativar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_desativar.Name = "bt_desativar";
            this.bt_desativar.Size = new System.Drawing.Size(100, 28);
            this.bt_desativar.TabIndex = 23;
            this.bt_desativar.Text = "Desativar";
            this.bt_desativar.UseVisualStyleBackColor = true;
            this.bt_desativar.Click += new System.EventHandler(this.bt_desativar_Click);
            // 
            // FormCadLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 626);
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_codelote);
            this.Controls.Add(this.tb_vencimento);
            this.Controls.Add(this.cb_fornecedor);
            this.Controls.Add(this.lb_pl);
            this.Controls.Add(this.lb_pc);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.DGV_Lote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormCadLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadLote";
            this.Load += new System.EventHandler(this.FormCadLote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Lote;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.ListBox lb_pc;
        private System.Windows.Forms.ListBox lb_pl;
        private System.Windows.Forms.ComboBox cb_fornecedor;
        private System.Windows.Forms.TextBox tb_vencimento;
        private System.Windows.Forms.TextBox tb_codelote;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.TextBox tb_Qtd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbx_ativo;
        private System.Windows.Forms.Button bt_desativar;
    }
}