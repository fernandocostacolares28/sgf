using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace sgf.Controle
{
    internal class Venda
    {
        public int IdVenda { get; set; }
        public string Cliente { get; set; }
        public string Receita_venda { get; set; }
        public DateTime Data_venda { get; set; }
        public string Metodopagamento_venda { get; set; }
        public int Parcelas_venda { get; set; }
        public float Total_venda { get; set; }
        public float Desconto_venda { get; set; }

        public Venda() { }
        public Venda(int idvenda, string cliente, string receita_venda, DateTime data_venda, string metodopagamento_venda, int parcelas_venda, float total_venda, float desconto_venda)
        {
            IdVenda = idvenda;
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
            SELECT LAST_INSERT_ID();";

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
                    idVenda = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(metodoPagamento == "Cartão Crédito")
                {
                    float restante = totalVenda;
                    DateTime dataparcela = data.AddMonths(1);
                    String status_contareceber = "ativo";

                    ContasReceber.SalvarContasReceber(idVenda, parcelas, totalVenda, restante, dataparcela, status_contareceber);
                }
                else 
                {
                    
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
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Seleciona todos os itens da venda
                    string selectItemsQuery = "SELECT name_produto, quantidade_produto FROM item_venda WHERE id_venda = @id_venda";
                    List<(string nomeProduto, int quantidade)> itensVenda = new List<(string, int)>();

                    using (MySqlCommand selectCommand = new MySqlCommand(selectItemsQuery, connection, transaction))
                    {
                        selectCommand.Parameters.AddWithValue("@id_venda", idVenda);
                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nomeProduto = reader.GetString("name_produto");
                                int quantidade = reader.GetInt32("quantidade_produto");
                                itensVenda.Add((nomeProduto, quantidade));
                            }
                        }
                    }

                    // Para cada item da venda, devolve a quantidade ao estoque
                    foreach (var item in itensVenda)
                    {
                        string updateEstoqueQuery = "UPDATE produto_lote pl JOIN lote l ON pl.id_lote = l.id_lote SET pl.qtd_produto = pl.qtd_produto + @quantidade WHERE pl.name_produto = @name_produto AND l.status_lote = 'Ativo'";
                        using (MySqlCommand updateCommand = new MySqlCommand(updateEstoqueQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@quantidade", item.quantidade);
                            updateCommand.Parameters.AddWithValue("@name_produto", item.nomeProduto);
                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    // Exclui os itens da venda
                    string deleteItemsQuery = "DELETE FROM item_venda WHERE id_venda = @id_venda";
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteItemsQuery, connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@id_venda", idVenda);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string queryExcluirPagamentos = @"
                        DELETE FROM pagamentos_contareceber 
                        WHERE id_contareceber IN (SELECT id_contareceber FROM contareceber WHERE id_venda = @id_venda)";

                    MySqlCommand commandExcluirPagamentos = new MySqlCommand(queryExcluirPagamentos, connection, transaction);
                    commandExcluirPagamentos.Parameters.AddWithValue("@id_venda", idVenda);
                    commandExcluirPagamentos.ExecuteNonQuery();

                    string queryExcluirContaReceber = "DELETE FROM contareceber WHERE id_venda = @id_venda";

                    MySqlCommand commandExcluirContaReceber = new MySqlCommand(queryExcluirContaReceber, connection, transaction);
                    commandExcluirContaReceber.Parameters.AddWithValue("@id_venda", idVenda);
                    commandExcluirContaReceber.ExecuteNonQuery();

                    // Exclui a venda
                    string deleteVendaQuery = "DELETE FROM venda WHERE id_venda = @id_venda";
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteVendaQuery, connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@id_venda", idVenda);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Confirma a transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao excluir a venda: " + ex.Message);
                }
            }
        }

        public static Venda CarregarDetalhesVenda(int idVenda)
        {
            Venda venda = null;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                connection.Open();

                string query = @"
                SELECT v.id_venda, v.metodopagamento_venda, v.parcelas_venda, v.receita_venda, 
                       v.data_venda, c.name_cliente, v.total_venda, v.desconto_venda
                FROM venda v
                JOIN cliente c ON v.id_cliente = c.id_cliente
                WHERE v.id_venda = @id_venda";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_venda", idVenda);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venda = new Venda
                            (
                                Convert.ToInt32(reader["id_venda"]),
                                reader["name_cliente"].ToString(),
                                reader["receita_venda"].ToString(),
                                Convert.ToDateTime(reader["data_venda"]),
                                reader["metodopagamento_venda"].ToString(),
                                Convert.ToInt32(reader["parcelas_venda"]),
                                Convert.ToSingle(reader["total_venda"]),
                                Convert.ToSingle(reader["desconto_venda"])
                            );
                        }
                    }
                }
            }

            return venda;
        }
    }
}
