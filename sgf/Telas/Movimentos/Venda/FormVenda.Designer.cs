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
            this.nud_parcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_parcelas.Location = new System.Drawing.Point(39, 137);
            this.nud_parcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_parcelas.Name = "nud_parcelas";
            this.nud_parcelas.Size = new System.Drawing.Size(70, 22);
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
            this.label1.Location = new System.Drawing.Point(14, 411);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "Vendas";
            // 
            // dtp_data
            // 
            this.dtp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_data.Location = new System.Drawing.Point(39, 230);
            this.dtp_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.Size = new System.Drawing.Size(316, 22);
            this.dtp_data.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 78;
            this.label3.Text = "Data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 165);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 77;
            this.label10.Text = "Receita";
            // 
            // tb_receita
            // 
            this.tb_receita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_receita.Location = new System.Drawing.Point(39, 185);
            this.tb_receita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_receita.Name = "tb_receita";
            this.tb_receita.Size = new System.Drawing.Size(316, 22);
            this.tb_receita.TabIndex = 76;
            // 
            // cb_metodo
            // 
            this.cb_metodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_metodo.FormattingEnabled = true;
            this.cb_metodo.Items.AddRange(new object[] {
            "Pix",
            "Cartão Débito",
            "Cartão Crédito",
            "Dinheiro"});
            this.cb_metodo.Location = new System.Drawing.Point(39, 89);
            this.cb_metodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_metodo.Name = "cb_metodo";
            this.cb_metodo.Size = new System.Drawing.Size(180, 24);
            this.cb_metodo.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(752, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 71;
            this.label8.Text = "Quantidade";
            // 
            // tb_Qtd
            // 
            this.tb_Qtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Qtd.Location = new System.Drawing.Point(756, 126);
            this.tb_Qtd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Qtd.Name = "tb_Qtd";
            this.tb_Qtd.Size = new System.Drawing.Size(110, 22);
            this.tb_Qtd.TabIndex = 70;
            // 
            // btRemover
            // 
            this.btRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemover.Location = new System.Drawing.Point(756, 199);
            this.btRemover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(112, 28);
            this.btRemover.TabIndex = 69;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // btAdicionar
            // 
            this.btAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdicionar.Location = new System.Drawing.Point(756, 158);
            this.btAdicionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(112, 28);
            this.btAdicionar.TabIndex = 68;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(878, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 67;
            this.label7.Text = "Carrinho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(428, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Produtos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "Método de Pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Parcelas";
            // 
            // tb_id
            // 
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_id.Location = new System.Drawing.Point(39, 41);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(148, 22);
            this.tb_id.TabIndex = 62;
            // 
            // lb_carrinho
            // 
            this.lb_carrinho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_carrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_carrinho.FormattingEnabled = true;
            this.lb_carrinho.ItemHeight = 16;
            this.lb_carrinho.Location = new System.Drawing.Point(882, 78);
            this.lb_carrinho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_carrinho.Name = "lb_carrinho";
            this.lb_carrinho.Size = new System.Drawing.Size(376, 260);
            this.lb_carrinho.TabIndex = 61;
            // 
            // lb_prod
            // 
            this.lb_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prod.FormattingEnabled = true;
            this.lb_prod.ItemHeight = 16;
            this.lb_prod.Location = new System.Drawing.Point(432, 78);
            this.lb_prod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_prod.Name = "lb_prod";
            this.lb_prod.Size = new System.Drawing.Size(313, 260);
            this.lb_prod.TabIndex = 60;
            this.lb_prod.SelectedIndexChanged += new System.EventHandler(this.lb_prod_SelectedIndexChanged);
            // 
            // btView
            // 
            this.btView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btView.Location = new System.Drawing.Point(969, 395);
            this.btView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(112, 28);
            this.btView.TabIndex = 59;
            this.btView.Text = "Visualizar";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.Location = new System.Drawing.Point(849, 395);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(112, 28);
            this.btExcluir.TabIndex = 58;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.Location = new System.Drawing.Point(1092, 395);
            this.btSalvar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(112, 28);
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
            this.DGV_Venda.Location = new System.Drawing.Point(18, 431);
            this.DGV_Venda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_Venda.Name = "DGV_Venda";
            this.DGV_Venda.ReadOnly = true;
            this.DGV_Venda.RowHeadersWidth = 51;
            this.DGV_Venda.Size = new System.Drawing.Size(1242, 207);
            this.DGV_Venda.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(33, 345);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 83;
            this.label12.Text = "Total";
            // 
            // tb_totalvenda
            // 
            this.tb_totalvenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_totalvenda.Location = new System.Drawing.Point(38, 364);
            this.tb_totalvenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_totalvenda.Name = "tb_totalvenda";
            this.tb_totalvenda.ReadOnly = true;
            this.tb_totalvenda.Size = new System.Drawing.Size(316, 22);
            this.tb_totalvenda.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(366, 345);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 85;
            this.label11.Text = "Desconto";
            // 
            // tb_desconto
            // 
            this.tb_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_desconto.Location = new System.Drawing.Point(369, 364);
            this.tb_desconto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_desconto.Name = "tb_desconto";
            this.tb_desconto.Size = new System.Drawing.Size(106, 22);
            this.tb_desconto.TabIndex = 84;
            // 
            // bt_desconto
            // 
            this.bt_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_desconto.Location = new System.Drawing.Point(531, 361);
            this.bt_desconto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_desconto.Name = "bt_desconto";
            this.bt_desconto.Size = new System.Drawing.Size(184, 28);
            this.bt_desconto.TabIndex = 86;
            this.bt_desconto.Text = "Aplicar Desconto";
            this.bt_desconto.UseVisualStyleBackColor = true;
            this.bt_desconto.Click += new System.EventHandler(this.bt_desconto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(486, 373);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 16);
            this.label13.TabIndex = 87;
            this.label13.Text = "%";
            // 
            // cb_cliente
            // 
            this.cb_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cliente.FormattingEnabled = true;
            this.cb_cliente.Location = new System.Drawing.Point(38, 277);
            this.cb_cliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_cliente.Name = "cb_cliente";
            this.cb_cliente.Size = new System.Drawing.Size(180, 24);
            this.cb_cliente.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(34, 257);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 88;
            this.label14.Text = "Cliente";
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pesquisa.Location = new System.Drawing.Point(510, 49);
            this.tb_pesquisa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(235, 22);
            this.tb_pesquisa.TabIndex = 90;
            this.tb_pesquisa.TextChanged += new System.EventHandler(this.tb_pesquisa_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 661);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 27);
            this.panel1.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1072, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "by Fernando Costa Colares";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "V 3.0 - 2024";
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 686);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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