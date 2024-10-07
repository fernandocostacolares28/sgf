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
        public string Data_venda { get; set; }
        public string Metodopagamento_venda { get; set; }
        public string Parcelas_venda { get; set; }
        public string Total_venda { get; set; }
        public string Desconto_venda { get; set; }

        public void VendaID(int id, int cliente, string receita_venda, string data_venda, string metodopagamento_venda, string parcelas_venda, string total_venda, string desconto_venda)
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

        public Venda(int id_itemvenda, int cliente, string receita_venda, string data_venda, string metodopagamento_venda, string parcelas_venda, string total_venda, string desconto_venda)
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
    }
}
