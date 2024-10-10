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
    internal class Compra
    {
        public int Id { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Data_compra { get; set; }
        public string Metodopagamento_compra { get; set; }
        public float Total_compra { get; set; }
        public int Parcela_compra { get; set; }
        public string Status_compra { get; set; }


        public Compra(int id, string fornecedor, DateTime data_compra, string metodopagamento_compra, float total_compra, int parcela_compra, string status_compra) 
        {
            Id = id;
            Fornecedor = fornecedor;
            Data_compra = data_compra;
            Metodopagamento_compra = metodopagamento_compra;
            Total_compra = total_compra;
            Parcela_compra = parcela_compra;
            Status_compra = status_compra;
        }

        public static int SalvarCompra(int id_fornecedor, DateTime data, string metodoPagamento, float totalCompra, int parcela)
        {
            string status = "Aguardando Entrega";
            int idCompra = 0;
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            INSERT INTO compra (id_fornecedor, data_compra, metodopagamento_compra, total_compra, parcela_compra, status_compra)
            VALUES (@id_fornecedor, @data, @metodo_pagamento, @total_compra, @parcela, @status);
            SELECT LAST_INSERT_ID();";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@metodo_pagamento", metodoPagamento);
                command.Parameters.AddWithValue("@total_compra", totalCompra);

                // Corrigindo o nome do parâmetro para '@parcela'
                command.Parameters.AddWithValue("@parcela", parcela);

                command.Parameters.AddWithValue("@status", status);

                try
                {
                    connection.Open();
                    idCompra = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar a compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (metodoPagamento == "Cartão Crédito")
                {
                    float restante = totalCompra;
                    DateTime dataparcela = data.AddMonths(1);
                    string status_contapagar = "ativo";

                    ContasPagar.SalvarContasPagar(idCompra, parcela, totalCompra, restante, dataparcela, status_contapagar);
                }

            }
            return idCompra;
        }


        public static int ObterIdFornecedor(string nomeFornecedor)
        {
            int idFornecedor = 0;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_fornecedor FROM fornecedor WHERE razaosocial_fornecedor = @nomeFornecedor";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeFornecedor", nomeFornecedor);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        idFornecedor = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter ID do fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return idFornecedor;
        }
        public static DataTable CarregarCompras()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_compra, id_fornecedor, data_compra, metodopagamento_compra, total_compra, parcela_compra, status_compra FROM compra";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    // Definir os nomes das colunas
                    dt.Columns["id_compra"].ColumnName = "ID";
                    dt.Columns["id_fornecedor"].ColumnName = "ID Cliente";
                    dt.Columns["data_compra"].ColumnName = "Data";
                    dt.Columns["metodopagamento_compra"].ColumnName = "Método de Pagamento";
                    dt.Columns["total_compra"].ColumnName = "Total";
                    dt.Columns["parcela_compra"].ColumnName = "Parcelas";
                    dt.Columns["status_compra"].ColumnName = "Status";
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar compras: " + ex.Message);
                }
            }

            return dt;
        }


        public static void AlterarStatusCompra(int id_compra)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "UPDATE compra SET status_compra = @status WHERE id_compra = @id_compra";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", "Entregue");
                command.Parameters.AddWithValue("@id_compra", id_compra);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status da compra alterado para 'Entregue' com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma compra encontrada com o ID informado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao alterar o status da compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ExcluirCompraComAssociados(int id_compra)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Iniciando uma transação para garantir que todas as exclusões ocorram corretamente
                    MySqlTransaction transaction = connection.BeginTransaction();

                    // Excluir pagamentos_contapagar com base no id_contapagar relacionado a id_compra
                    string queryExcluirPagamentos = @"
                        DELETE FROM pagamentos_contapagar 
                        WHERE id_contapagar IN (SELECT id_contapagar FROM contapagar WHERE id_compra = @id_compra)";

                    MySqlCommand commandExcluirPagamentos = new MySqlCommand(queryExcluirPagamentos, connection, transaction);
                    commandExcluirPagamentos.Parameters.AddWithValue("@id_compra", id_compra);
                    commandExcluirPagamentos.ExecuteNonQuery();

                    // Excluir contapagar com base no id_compra
                    string queryExcluirContaPagar = "DELETE FROM contapagar WHERE id_compra = @id_compra";

                    MySqlCommand commandExcluirContaPagar = new MySqlCommand(queryExcluirContaPagar, connection, transaction);
                    commandExcluirContaPagar.Parameters.AddWithValue("@id_compra", id_compra);
                    commandExcluirContaPagar.ExecuteNonQuery();

                    // Excluir compra com base no id_compra
                    string queryExcluirCompra = "DELETE FROM compra WHERE id_compra = @id_compra";

                    MySqlCommand commandExcluirCompra = new MySqlCommand(queryExcluirCompra, connection, transaction);
                    commandExcluirCompra.Parameters.AddWithValue("@id_compra", id_compra);
                    int rowsAffected = commandExcluirCompra.ExecuteNonQuery();

                    // Confirma a transação se tudo der certo
                    transaction.Commit();

                    // Verifica se a compra foi excluída
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Compra e registros associados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma compra encontrada com o ID informado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir a compra e registros associados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }

}
