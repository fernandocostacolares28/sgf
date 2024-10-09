using MySql.Data.MySqlClient;
using sgf.Controle;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Gerenciamento
{
    public partial class FormEstoque : Form
    {
        public FormEstoque()
        {
            InitializeComponent();
        }

        private void cb_lote_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Entidades.DBConnection.GetConnectionString()))
            {

                string query = "SELECT code_lote FROM produto_lote WHERE code_lote = @lote";

                MySqlCommand command = new MySqlCommand(query, connection);



                connection.Open();
                object result = command.ExecuteScalar();

                string lote = Convert.ToString(result);

                dgv_produto.DataSource = Controle.Estoque.ListarProdutos(lote);

                dgv_produto.Columns["id_produto"].HeaderText = "ID";
                dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
                dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
                dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
                dgv_produto.Columns["id_lote"].HeaderText = "ID Lote";
            }
        }

        private void FormEstoque_Load(object sender, EventArgs e)
        {

            dgv_produto.DataSource = ProdutoLote.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["code_lote"].HeaderText = "Lote";
        }



        private void dgv_produto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
