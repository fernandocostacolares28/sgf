using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Controle
{
    internal class Venda
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Receita_venda { get; set; }
        public DateTime Data_venda { get; set; }
        public string Metodopagamento_venda { get; set; }
        public int Parcelas_venda { get; set; }
        public float Total_venda { get; set; }
        public float Desconto_venda { get; set; }

        public void VendaID(int id, int cliente, string receita_venda, DateTime data_venda, string metodopagamento_venda, int parcelas_venda, float total_venda, float desconto_venda)
        {
            Id = id;
            Cliente = cliente;
            Receita_venda = receita_venda;
            Data_venda = data_venda;
            Metodopagamento_venda = metodopagamento_venda;
            Parcelas_venda = parcelas_venda;
            Total_venda = total_venda;
            Desconto_venda = desconto_venda;
        }

        public Venda(int cliente, string receita_venda, DateTime data_venda, string metodopagamento_venda, int parcelas_venda, float total_venda, float desconto_venda)
        {
            Cliente = cliente;
            Receita_venda = receita_venda;
            Data_venda = data_venda;
            Metodopagamento_venda = metodopagamento_venda;
            Parcelas_venda = parcelas_venda;
            Total_venda = total_venda;
            Desconto_venda = desconto_venda;
        }


        public static float ObterValorProduto(string nomeProduto)
        {
            float valorProduto = 0;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT valor_produto FROM produto_lote WHERE name_produto = @nomeProduto";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeProduto", nomeProduto);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        valorProduto = Convert.ToSingle(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter valor do produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return valorProduto;
        }

        public static int SalvarVenda(Venda Venda)
        {
            int idVenda = 0;
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO venda (id_cliente, receita_venda, data_venda, metodopagamento_venda, parcelas_venda, total_venda, desconto_venda, carrinho_venda) " +
                    "VALUES (@cliente, @receita_venda, @data_venda, @metodopagamento_venda, @parcelas_venda, @total_venda, @desconto_venda, @carrinho_venda)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente", Venda.Cliente);
                command.Parameters.AddWithValue("@receita_venda", Venda.Receita_venda);
                command.Parameters.AddWithValue("@data_venda", Venda.Data_venda);
                command.Parameters.AddWithValue("@metodopagamento_venda", Venda.Metodopagamento_venda);
                command.Parameters.AddWithValue("@parcelas_venda", Venda.Parcelas_venda);
                command.Parameters.AddWithValue("@total_venda", Venda.Total_venda);
                command.Parameters.AddWithValue("@desconto_venda", Venda.Desconto_venda);


                connection.Open();
                command.ExecuteNonQuery();

                try
                {
                    connection.Open();
                    // Executa a query e captura o ID da venda recém-inserida
                    idVenda = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return idVenda;
        }

        public static int ObterIdCliente(string nomeCliente)
        {
            int idCliente = 0;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_cliente FROM cliente WHERE name_cliente = @nomeCliente";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeCliente", nomeCliente);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        idCliente = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter ID do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return idCliente;
        }
    }
}
