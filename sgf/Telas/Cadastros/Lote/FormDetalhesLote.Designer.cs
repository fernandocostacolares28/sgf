namespace sgf.Telas.Cadastros.Lote
{
    partial class FormDetalhesLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalhesLote));
            this.DGV_produtos = new System.Windows.Forms.DataGridView();
            this.Produtos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_produtos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_produtos
            // 
            this.DGV_produtos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_produtos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_produtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_produtos.Location = new System.Drawing.Point(12, 29);
            this.DGV_produtos.Name = "DGV_produtos";
            this.DGV_produtos.ReadOnly = true;
            this.DGV_produtos.Size = new System.Drawing.Size(768, 379);
            this.DGV_produtos.TabIndex = 0;
            // 
            // Produtos
            // 
            this.Produtos.AutoSize = true;
            this.Produtos.Location = new System.Drawing.Point(12, 13);
            this.Produtos.Name = "Produtos";
            this.Produtos.Size = new System.Drawing.Size(49, 13);
            this.Produtos.TabIndex = 1;
            this.Produtos.Text = "Produtos";
            // 
            // FormDetalhesLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 430);
            this.Controls.Add(this.Produtos);
            this.Controls.Add(this.DGV_produtos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDetalhesLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes";
            this.Load += new System.EventHandler(this.FormDetalhesLote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_produtos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_produtos;
        private System.Windows.Forms.Label Produtos;
    }
}