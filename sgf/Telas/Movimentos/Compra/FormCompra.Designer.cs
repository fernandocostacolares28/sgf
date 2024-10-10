namespace sgf.Telas.Movimentos.Compra
{
    partial class FormCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompra));
            this.dtp_data = new System.Windows.Forms.DateTimePicker();
            this.cb_fornecedor = new System.Windows.Forms.ComboBox();
            this.nud_parcelas = new System.Windows.Forms.NumericUpDown();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.DGV_Compra = new System.Windows.Forms.DataGridView();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_metodo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_excluir = new System.Windows.Forms.Button();
            this.bt_entregue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Compra)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_data
            // 
            this.dtp_data.Location = new System.Drawing.Point(12, 146);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.Size = new System.Drawing.Size(200, 20);
            this.dtp_data.TabIndex = 0;
            // 
            // cb_fornecedor
            // 
            this.cb_fornecedor.FormattingEnabled = true;
            this.cb_fornecedor.Location = new System.Drawing.Point(12, 188);
            this.cb_fornecedor.Name = "cb_fornecedor";
            this.cb_fornecedor.Size = new System.Drawing.Size(121, 21);
            this.cb_fornecedor.TabIndex = 1;
            // 
            // nud_parcelas
            // 
            this.nud_parcelas.Location = new System.Drawing.Point(12, 107);
            this.nud_parcelas.Name = "nud_parcelas";
            this.nud_parcelas.Size = new System.Drawing.Size(34, 20);
            this.nud_parcelas.TabIndex = 2;
            this.nud_parcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bt_salvar
            // 
            this.bt_salvar.Location = new System.Drawing.Point(637, 232);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(140, 23);
            this.bt_salvar.TabIndex = 3;
            this.bt_salvar.Text = "Solicitar Lote";
            this.bt_salvar.UseVisualStyleBackColor = true;
            this.bt_salvar.Click += new System.EventHandler(this.bt_salvar_Click);
            // 
            // DGV_Compra
            // 
            this.DGV_Compra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Compra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Compra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Compra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Compra.Location = new System.Drawing.Point(12, 261);
            this.DGV_Compra.Name = "DGV_Compra";
            this.DGV_Compra.Size = new System.Drawing.Size(776, 191);
            this.DGV_Compra.TabIndex = 4;
            this.DGV_Compra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Compra_CellContentClick);
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(10, 28);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(100, 20);
            this.tb_id.TabIndex = 5;
            // 
            // tb_total
            // 
            this.tb_total.Location = new System.Drawing.Point(12, 235);
            this.tb_total.Name = "tb_total";
            this.tb_total.Size = new System.Drawing.Size(139, 20);
            this.tb_total.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // cb_metodo
            // 
            this.cb_metodo.FormattingEnabled = true;
            this.cb_metodo.Items.AddRange(new object[] {
            "Pix",
            "Cartão Débito",
            "Cartão Crédito",
            "Dinheiro"});
            this.cb_metodo.Location = new System.Drawing.Point(12, 67);
            this.cb_metodo.Name = "cb_metodo";
            this.cb_metodo.Size = new System.Drawing.Size(121, 21);
            this.cb_metodo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Método Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Parcelas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fornecedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total";
            // 
            // bt_excluir
            // 
            this.bt_excluir.Location = new System.Drawing.Point(491, 233);
            this.bt_excluir.Name = "bt_excluir";
            this.bt_excluir.Size = new System.Drawing.Size(140, 23);
            this.bt_excluir.TabIndex = 14;
            this.bt_excluir.Text = "Excluir";
            this.bt_excluir.UseVisualStyleBackColor = true;
            this.bt_excluir.Click += new System.EventHandler(this.bt_excluir_Click);
            // 
            // bt_entregue
            // 
            this.bt_entregue.Location = new System.Drawing.Point(345, 233);
            this.bt_entregue.Name = "bt_entregue";
            this.bt_entregue.Size = new System.Drawing.Size(140, 23);
            this.bt_entregue.TabIndex = 15;
            this.bt_entregue.Text = "Entregue";
            this.bt_entregue.UseVisualStyleBackColor = true;
            this.bt_entregue.Click += new System.EventHandler(this.bt_entregue_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(1, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 22);
            this.panel1.TabIndex = 111;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "by Fernando Costa Colares";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "V 3.0 - 2024";
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_entregue);
            this.Controls.Add(this.bt_excluir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_metodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_total);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.DGV_Compra);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.nud_parcelas);
            this.Controls.Add(this.cb_fornecedor);
            this.Controls.Add(this.dtp_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.FormCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Compra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_data;
        private System.Windows.Forms.ComboBox cb_fornecedor;
        private System.Windows.Forms.NumericUpDown nud_parcelas;
        private System.Windows.Forms.Button bt_salvar;
        private System.Windows.Forms.DataGridView DGV_Compra;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_metodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Button bt_entregue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}