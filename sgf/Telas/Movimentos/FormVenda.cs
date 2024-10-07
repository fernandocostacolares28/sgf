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

namespace sgf.Telas.Movimentos
{
    public partial class FormVenda : Form
    {
        public FormVenda()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void FormVenda_Load(object sender, EventArgs e)
        {

        }

        private void lb_prod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarregarProdutos()
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT pl.name_produto FROM produto_lote pl INNER JOIN lote l ON pl.id_lote = l.id_lote WHERE l.status_lote = 'Ativo';";
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
                                lb_prod.Items.Add(reader["name_produto"].ToString());
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

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (lb_prod.SelectedItem != null)
            {
                if (lb_prod.SelectedItem != null)
                {
                    string nomeProduto = lb_prod.SelectedItem.ToString();

                    if (int.TryParse(tb_Qtd.Text, out int quantidade) && quantidade > 0)
                    {
                        float valorProduto = Controle.Venda.ObterValorProduto(nomeProduto); 

                        float valorTotalProduto = valorProduto * quantidade;

                        lb_carrinho.Items.Add($"{nomeProduto} - Quantidade: {quantidade} - Valor Unitário: {valorProduto:C2}");

                        if (string.IsNullOrEmpty(tb_totalvenda.Text))
                        {
                            tb_totalvenda.Text = "0";
                        }

                        float valorAtualTotal = float.Parse(tb_totalvenda.Text);

                        float novoTotal = valorAtualTotal + valorTotalProduto;

                        tb_totalvenda.Text = novoTotal.ToString("F2"); 
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            string itemSelecionado = lb_carrinho.SelectedItem.ToString();

            string[] partesItem = itemSelecionado.Split('-');
            string nomeProduto = partesItem[0].Trim();
            int quantidade = int.Parse(partesItem[1].Replace("Quantidade: ", "").Trim());
            float valorUnitario = float.Parse(partesItem[2].Replace("Valor Unitário: R$", "").Trim());

            float valorTotalRemovido = valorUnitario * quantidade;

            float valorAtualTotal = float.Parse(tb_totalvenda.Text);

            float novoTotal = valorAtualTotal - valorTotalRemovido;

            tb_totalvenda.Text = novoTotal.ToString("F2");

            lb_carrinho.Items.Remove(lb_carrinho.SelectedItem);
        }

        private void bt_desconto_Click(object sender, EventArgs e)
        {
            if (float.TryParse(tb_desconto.Text, out float desconto) && desconto > 0 && desconto <= 100)
            {
                if (float.TryParse(tb_totalvenda.Text, out float valorTotal))
                {
                    float valorDesconto = (desconto / 100) * valorTotal;

                    float novoTotal = valorTotal - valorDesconto;

                    tb_totalvenda.Text = novoTotal.ToString("F2"); 
                }
                else
                {
                    MessageBox.Show("Valor total inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor de desconto válido entre 0 e 100.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
