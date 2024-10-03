using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Cadastros.Lote
{
    public partial class FormCadLote : Form
    {
        public FormCadLote()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (lb_pc.SelectedItem != null && !string.IsNullOrWhiteSpace(tb_Qtd.Text))
            {
                // Obter o produto selecionado na ListBox1
                string produtoSelecionado = lb_pc.SelectedItem.ToString();

                // Obter a quantidade digitada no TextBox
                string quantidade = tb_Qtd.Text;

                // Adicionar o produto e a quantidade na ListBox2
                lb_pl.Items.Add($"{produtoSelecionado} - Quantidade: {quantidade}");

                // Limpar a seleção e o campo de texto
                lb_pc.ClearSelected();
                tb_Qtd.Clear();
            }
            else
            {
                MessageBox.Show("Selecione um produto e informe a quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarProdutos()
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT name_produto FROM produto";
                try
                {
                    // Abrir a conexão com o banco
                    connection.Open();

                    // Criar o comando SQL
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Executar a leitura dos dados
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Ler os produtos e adicionar na ListBox1
                            while (reader.Read())
                            {
                                lb_pc.Items.Add(reader["name_produto"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibir mensagem de erro, se ocorrer
                    MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (lb_pl.SelectedItem != null)
            {
                // Remover o item selecionado da ListBox2
                lb_pl.Items.Remove(lb_pl.SelectedItem);
            }
            else
            {
                // Exibir mensagem de erro se nenhum item estiver selecionado
                MessageBox.Show("Selecione um item na ListBox2 para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
