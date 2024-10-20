using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sgf.Controle
{
    internal class ContasReceber
    {
        public static void SalvarContasReceber(int idVenda, int parcelas, float totalVenda, float restante, DateTime dataparcela, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO ContaReceber (id_venda, parcela_contareceber, total_contareceber, restante_contareceber, dataparcela_contareceber, status_contareceber) " +
                    "VALUES (@venda, @parcela, @total, @restante, @data, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@venda", idVenda);
                command.Parameters.AddWithValue("@parcela", parcelas);
                command.Parameters.AddWithValue("@total", totalVenda);
                command.Parameters.AddWithValue("@restante", restante);
                command.Parameters.AddWithValue("@data", dataparcela);
                command.Parameters.AddWithValue("@status", status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void PagarParcela(int id_contasreceber)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Buscar as informações da conta a receber
                    string query = @"
                        SELECT total_contareceber, restante_contareceber, parcela_contareceber, dataparcela_contareceber 
                        FROM contareceber 
                        WHERE id_contareceber = @id_contasreceber";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_contasreceber", id_contasreceber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float total_contareceber = reader.GetFloat("total_contareceber");
                            float restante_contareceber = reader.GetFloat("restante_contareceber");
                            int parcelas_contareceber = reader.GetInt32("parcela_contareceber");
                            DateTime dataparcela_contareceber = reader.GetDateTime("dataparcela_contareceber");

                            // Calcular o valor da parcela
                            float valorParcela = total_contareceber / parcelas_contareceber;

                            // Subtrair o valor da parcela do restante
                            restante_contareceber -= valorParcela;

                            reader.Close();

                            // Verificar se o restante chegou a zero e atualizar a data e o status
                            string updateQuery;
                            if (restante_contareceber <= 0)
                            {
                                restante_contareceber = 0; // Certificar-se de que o restante não fique negativo
                                updateQuery = @"
                                    UPDATE contareceber 
                                    SET restante_contareceber = @restante_contareceber, status_contareceber = 'Pago', dataparcela_contareceber = NULL
                                    WHERE id_contareceber = @id_contasreceber";
                                DetalhesContaReceber.SalvarDetalhes(id_contasreceber, DateTime.Now, valorParcela, "pago");
                            }
                            else
                            {
                                // Incrementa a data em um mês
                                dataparcela_contareceber = dataparcela_contareceber.AddMonths(1);

                                updateQuery = @"
                                    UPDATE contareceber 
                                    SET restante_contareceber = @restante_contareceber, dataparcela_contareceber = @dataparcela_contareceber 
                                    WHERE id_contareceber = @id_contasreceber";
                               
                                DetalhesContaReceber.SalvarDetalhes(id_contasreceber, DateTime.Now, valorParcela, "pago");
                            }

                            // Atualizar o valor restante, a data e o status se necessário
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@restante_contareceber", restante_contareceber);
                            updateCommand.Parameters.AddWithValue("@id_contasreceber", id_contasreceber);

                            if (restante_contareceber > 0)
                            {
                                updateCommand.Parameters.AddWithValue("@dataparcela_contareceber", dataparcela_contareceber);
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

        public static DataTable CarregarContasReceber()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT cr.id_contareceber, v.id_venda, c.name_cliente, v.id_cliente, cr.parcela_contareceber, 
                           cr.total_contareceber, cr.restante_contareceber, cr.dataparcela_contareceber, 
                           cr.status_contareceber
                    FROM contareceber cr
                    JOIN venda v ON cr.id_venda = v.id_venda
                    JOIN cliente c ON v.id_cliente = c.id_cliente";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    // Definindo os nomes das colunas
                    dt.Columns["id_contareceber"].ColumnName = "ID Conta Receber";
                    dt.Columns["id_venda"].ColumnName = "ID Venda";
                    dt.Columns["name_cliente"].ColumnName = "Nome do Cliente";
                    dt.Columns["parcela_contareceber"].ColumnName = "Parcela";
                    dt.Columns["total_contareceber"].ColumnName = "Total";
                    dt.Columns["restante_contareceber"].ColumnName = "Restante";
                    dt.Columns["dataparcela_contareceber"].ColumnName = "Data da Parcela";
                    dt.Columns["status_contareceber"].ColumnName = "Status";


                    // Opcional: Ocultar a coluna id_cliente, se não for necessária
                    dt.Columns.Remove("id_cliente");
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar contas a receber: " + ex.Message);
                }
            }

            return dt;
        }
        public static DataTable FiltrarContasReceber(string filtro)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT cr.id_contareceber, v.id_venda, c.name_cliente, cr.parcela_contareceber, cr.total_contareceber, 
                           cr.restante_contareceber, cr.dataparcela_contareceber, cr.status_contareceber
                    FROM contareceber cr
                    JOIN venda v ON cr.id_venda = v.id_venda
                    JOIN cliente c ON v.id_cliente = c.id_cliente
                    WHERE c.name_cliente LIKE @filtro";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);

                        // Definir os nomes das colunas
                        dt.Columns["id_contareceber"].ColumnName = "ID Conta a Receber";
                        dt.Columns["id_venda"].ColumnName = "ID Venda";
                        dt.Columns["parcela_contareceber"].ColumnName = "Parcela";
                        dt.Columns["total_contareceber"].ColumnName = "Total";
                        dt.Columns["restante_contareceber"].ColumnName = "Restante";
                        dt.Columns["dataparcela_contareceber"].ColumnName = "Data da Parcela";
                        dt.Columns["status_contareceber"].ColumnName = "Status";
                        dt.Columns["name_cliente"].ColumnName = "Nome do Cliente";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar contas a receber: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }

    }

}


