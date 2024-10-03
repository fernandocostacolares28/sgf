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
            if (lb_pc.SelectedItem != null && !string.IsNullOrWhiteSpace(textBoxQuantidade.Text))
            {
                // Obter o produto selecionado na ListBox1
                string produtoSelecionado = lb_pc.SelectedItem.ToString();

                // Obter a quantidade digitada no TextBox
                string quantidade = textBoxQuantidade.Text;

                // Adicionar o produto e a quantidade na ListBox2
                listBox2.Items.Add($"{produtoSelecionado} - Quantidade: {quantidade}");

                // Limpar a seleção e o campo de texto
                lb_pc.ClearSelected();
                textBoxQuantidade.Clear();
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

                string query = "SELECT Name_Produto FROM Produto";
                try
                {
                    // Abrir a conexão com o banco
                    connection.Open();

                    // Criar o comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Executar a leitura dos dados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Ler os produtos e adicionar na ListBox1
                            while (reader.Read())
                            {
                                // Pega o valor da coluna 'NomeProduto' e adiciona à ListBox1
                                lb_pc.Items.Add(reader["NomeProduto"].ToString());
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
    }
}
