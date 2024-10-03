using sgf.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Cadastros.Lote
{
    public partial class FormDetalhesLote : Form
    {
        public FormDetalhesLote(int id)
        {
            InitializeComponent();
        }

        private void FormDetalhesLote_Load(object sender, EventArgs e)
        {
            DGV_produtos.DataSource = ProdutoLote.ListarProdutos();

            DGV_produtos.Columns["id_produto"].HeaderText = "ID";
            DGV_produtos.Columns["name_produto"].HeaderText = "Nome do Produto";
            DGV_produtos.Columns["valor_produto"].HeaderText = "Valor";
            DGV_produtos.Columns["qtd_produto"].HeaderText = "Quantidade";
            DGV_produtos.Columns["code_lote"].HeaderText = "Lote";
        }


    }
}
