namespace sgf.Telas.Financeiro
{
    partial class FormContasReceber
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContasReceber));
            this.DGV_contareceber = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_filtro = new System.Windows.Forms.TextBox();
            this.bt_receber = new System.Windows.Forms.Button();
            this.bt_detalhes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_contareceber)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_contareceber
            // 
            this.DGV_contareceber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_contareceber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_contareceber.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_contareceber.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_contareceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_contareceber.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_contareceber.Location = new System.Drawing.Point(12, 33);
            this.DGV_contareceber.Name = "DGV_contareceber";
            this.DGV_contareceber.ReadOnly = true;
            this.DGV_contareceber.Size = new System.Drawing.Size(776, 414);
            this.DGV_contareceber.TabIndex = 0;
            this.DGV_contareceber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contas a Receber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(563, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente";
            // 
            // tb_filtro
            // 
            this.tb_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_filtro.Location = new System.Drawing.Point(624, 6);
            this.tb_filtro.Name = "tb_filtro";
            this.tb_filtro.Size = new System.Drawing.Size(164, 22);
            this.tb_filtro.TabIndex = 3;
            this.tb_filtro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // bt_receber
            // 
            this.bt_receber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_receber.Location = new System.Drawing.Point(265, 4);
            this.bt_receber.Name = "bt_receber";
            this.bt_receber.Size = new System.Drawing.Size(108, 23);
            this.bt_receber.TabIndex = 4;
            this.bt_receber.Text = "Receber Fatura";
            this.bt_receber.UseVisualStyleBackColor = true;
            this.bt_receber.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_detalhes
            // 
            this.bt_detalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_detalhes.Location = new System.Drawing.Point(379, 3);
            this.bt_detalhes.Name = "bt_detalhes";
            this.bt_detalhes.Size = new System.Drawing.Size(108, 23);
            this.bt_detalhes.TabIndex = 5;
            this.bt_detalhes.Text = "Detalhes";
            this.bt_detalhes.UseVisualStyleBackColor = true;
            this.bt_detalhes.Click += new System.EventHandler(this.bt_detalhes_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 22);
            this.panel1.TabIndex = 47;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(592, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "by Fernando Costa Colares";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "V 3.0 - 2024";
            // 
            // FormContasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_detalhes);
            this.Controls.Add(this.bt_receber);
            this.Controls.Add(this.tb_filtro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_contareceber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormContasReceber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a Receber";
            this.Load += new System.EventHandler(this.FormContasReceber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_contareceber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_contareceber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_filtro;
        private System.Windows.Forms.Button bt_receber;
        private System.Windows.Forms.Button bt_detalhes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}