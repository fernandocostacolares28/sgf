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
    internal class ContasPagar
    {
        public static void SalvarContasPagar(int idCompra, int parcelas, float totalCompra, float restante, DateTime dataparcela, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO ContaPagar (id_compra, parcela_compra, total_contapagar, restante_contapagar, dataparcela_contapagar, status_contapagar) " +
                    "VALUES (@compra, @parcela, @total, @restante, @data, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@compra", idCompra);
                command.Parameters.AddWithValue("@parcela", parcelas);
                command.Parameters.AddWithValue("@total", totalCompra);
                command.Parameters.AddWithValue("@restante", restante);
                command.Parameters.AddWithValue("@data", dataparcela);
                command.Parameters.AddWithValue("@status", status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void PagarParcela(int id_contaspagar)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Buscar as informações da conta a pagar
                    string query = @"
                SELECT total_contapagar, restante_contapagar, parcela_compra, dataparcela_contapagar
                FROM contapagar 
                WHERE id_contapagar = @id_contaspagar";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_contaspagar", id_contaspagar);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float total_contapagar = reader.GetFloat("total_contapagar");
                            float restante_contapagar = reader.GetFloat("restante_contapagar");
                            int parcelas_contapagar = reader.GetInt32("parcela_compra");
                            DateTime dataparcela_contapagar = reader.GetDateTime("dataparcela_contapagar");

                            // Calcular o valor da parcela
                            float valorParcela = total_contapagar / parcelas_contapagar;

                            // Subtrair o valor da parcela do restante
                            restante_contapagar -= valorParcela;

                            reader.Close();

                            // Verificar se o restante chegou a zero e atualizar a data e o status
                            string updateQuery;
                            if (restante_contapagar <= 0)
                            {
                                restante_contapagar = 0; // Certificar-se de que o restante não fique negativo
                                updateQuery = @"
                            UPDATE contapagar 
                            SET restante_contapagar = @restante_contapagar, status_contapagar = 'Pago', dataparcela_contapagar = NULL
                            WHERE id_contapagar = @id_contaspagar";
                            }
                            else
                            {
                                // Incrementa a data em um mês
                                dataparcela_contapagar = dataparcela_contapagar.AddMonths(1);

                                updateQuery = @"
                            UPDATE contapagar 
                            SET restante_contapagar = @restante_contapagar, dataparcela_contapagar = @dataparcela_contapagar 
                            WHERE id_contapagar = @id_contaspagar";

                                // Salvar os detalhes do pagamento
                                DetalhesContaPagar.SalvarDetalhes(id_contaspagar, DateTime.Now, valorParcela, "pago");
                            }

                            // Atualizar o valor restante, a data e o status se necessário
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@restante_contapagar", restante_contapagar);
                            updateCommand.Parameters.AddWithValue("@id_contaspagar", id_contaspagar);

                            if (restante_contapagar > 0)
                            {
                                updateCommand.Parameters.AddWithValue("@dataparcela_contapagar", dataparcela_contapagar);
                            }

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao pagar parcela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static DataTable CarregarContasPagar()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT cp.id_contapagar, c.id_compra, f.razaosocial_fornecedor, c.id_fornecedor, cp.parcela_compra, 
                           cp.total_contapagar, cp.restante_contapagar, cp.dataparcela_contapagar, 
                           cp.status_contapagar
                    FROM contapagar cp
                    JOIN compra c ON cp.id_compra = c.id_compra
                    JOIN fornecedor f ON c.id_fornecedor = f.id_fornecedor";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    // Definindo os nomes das colunas
                    dt.Columns["id_contapagar"].ColumnName = "ID Conta Pagar";
                    dt.Columns["id_compra"].ColumnName = "ID Compra";
                    dt.Columns["razaosocial_fornecedor"].ColumnName = "Razão Social";
                    dt.Columns["parcela_compra"].ColumnName = "Parcela";
                    dt.Columns["total_contapagar"].ColumnName = "Total";
                    dt.Columns["restante_contapagar"].ColumnName = "Restante";
                    dt.Columns["dataparcela_contapagar"].ColumnName = "Data da Parcela";
                    dt.Columns["status_contapagar"].ColumnName = "Status";


                    // Opcional: Ocultar a coluna id_cliente, se não for necessária
                    dt.Columns.Remove("id_fornecedor");
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar contas a pagar: " + ex.Message);
                }
            }

            return dt;
        }

        public static DataTable FiltrarContasPagar(string filtro)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT cp.id_contapagar, c.id_Compra, f.razaosocial_fornecedor, cp.parcela_compra, cp.total_contapagar, 
                   cp.restante_contapagar, cp.dataparcela_contapagar, cp.status_contapagar
            FROM contapagar cp
            JOIN compra c ON cp.id_compra = c.id_compra
            JOIN fornecedor f ON c.id_fornecedor = f.id_fornecedor
            WHERE f.razaosocial_fornecedor LIKE @filtro";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);

                        // Definir os nomes das colunas
                        dt.Columns["id_contapagar"].ColumnName = "ID Conta a Pagar";
                        dt.Columns["id_compra"].ColumnName = "ID Compra";
                        dt.Columns["parcela_compra"].ColumnName = "Parcela";
                        dt.Columns["total_contapagar"].ColumnName = "Total";
                        dt.Columns["restante_contapagar"].ColumnName = "Restante";
                        dt.Columns["dataparcela_contapagar"].ColumnName = "Data da Parcela";
                        dt.Columns["status_contapagar"].ColumnName = "Status";
                        dt.Columns["razaosocial_fornecedor"].ColumnName = "Razão Social";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar contas a pagar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }


    }
}
