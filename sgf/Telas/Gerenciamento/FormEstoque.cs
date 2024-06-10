using MySql.Data.MySqlClient;
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

                string query = "SELECT lote_produto FROM Produto WHERE lote_produto = @lote";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@lote", cb_lote.Text);


                connection.Open();
                object result = command.ExecuteScalar();

                string lote = Convert.ToString(result);

                dgv_produto.DataSource = Controle.Estoque.ListarProdutos(lote);

                dgv_produto.Columns["id_produto"].HeaderText = "ID";
                dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
                dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
                dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
                dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
            }
        }

        private void FormEstoque_Load(object sender, EventArgs e)
        {
            List<string> Lotes = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(Entidades.DBConnection.GetConnectionString()))
            {
                string query = "SELECT DISTINCT lote_produto FROM Produto";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int lote_produto = reader.GetInt32("lote_produto");
                            string lote = lote_produto.ToString();
                            Lotes.Add(lote);
                        }
                    }
                }

            }

            cb_lote.Items.AddRange(Lotes.ToArray());

            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            
            int lote = int.Parse(cb_lote.Text);
            Controle.Estoque.ExcluirLote(lote);


            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
        }
    }
}
