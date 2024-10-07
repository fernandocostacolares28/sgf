using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static int SalvarVenda(int id_cliente, string receita, DateTime data, string metodoPagamento, int parcelas, float totalVenda, float desconto_venda)
        {
            int idVenda = 0;
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            INSERT INTO venda (id_cliente, receita_venda, data_venda, metodopagamento_venda, parcelas_venda, total_venda, desconto_venda)
            VALUES (@id_cliente, @receita, @data, @metodo_pagamento, @parcelas, @total_venda, @desconto);
            SELECT LAST_INSERT_ID();";  // O ID da última inserção será retornado aqui.

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_cliente", id_cliente);
                command.Parameters.AddWithValue("@receita", receita);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@metodo_pagamento", metodoPagamento);
                command.Parameters.AddWithValue("@parcelas", parcelas);
                command.Parameters.AddWithValue("@total_venda", totalVenda);
                command.Parameters.AddWithValue("@desconto", desconto_venda);

                try
                {
                    connection.Open();
                    // ExecuteScalar() retorna o ID da última inserção
                    idVenda = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return idVenda;  // Retorna o ID da venda recém-inserida
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

        public static DataTable CarregarVendas()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_venda, id_cliente, receita_venda, data_venda, metodopagamento_venda, parcelas_venda, total_venda, desconto_venda FROM venda";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    // Definir os nomes das colunas
                    dt.Columns["id_venda"].ColumnName = "ID";
                    dt.Columns["id_cliente"].ColumnName = "ID Cliente";
                    dt.Columns["receita_venda"].ColumnName = "Receita";
                    dt.Columns["data_venda"].ColumnName = "Data";
                    dt.Columns["metodopagamento_venda"].ColumnName = "Método de Pagamento";
                    dt.Columns["parcelas_venda"].ColumnName = "Parcelas";
                    dt.Columns["total_venda"].ColumnName = "Total";
                    dt.Columns["desconto_venda"].ColumnName = "Desconto";
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar vendas: " + ex.Message);
                }
            }

            return dt;
        }
        public static void Excluir(int idVenda)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Inicia uma transação para garantir a integridade dos dados
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Primeiro, exclui os itens da venda
                    string deleteItemsQuery = "DELETE FROM item_venda WHERE id_venda = @id_venda";
                    using (MySqlCommand command = new MySqlCommand(deleteItemsQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@id_venda", idVenda);
                        command.ExecuteNonQuery();
                    }

                    // Em seguida, exclui a venda
                    string deleteVendaQuery = "DELETE FROM venda WHERE id_venda = @id_venda";
                    using (MySqlCommand command = new MySqlCommand(deleteVendaQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@id_venda", idVenda);
                        command.ExecuteNonQuery();
                    }

                    // Confirma a transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Desfaz a transação em caso de erro
                    transaction.Rollback();
                    throw new Exception("Erro ao excluir a venda: " + ex.Message);
                }
            }
        }
    }
}
