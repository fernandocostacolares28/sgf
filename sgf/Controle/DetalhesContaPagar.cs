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
    internal class DetalhesContaPagar
    {
        public static void SalvarDetalhes(int contapagar, DateTime data, float valor, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO pagamentos_contapagar (id_contapagar, data_pagamento, valorparcela_pagamento, status_pagamento) " +
                    "VALUES (@contapagar, @data, @valor, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@contapagar", contapagar);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@valor", valor);
                command.Parameters.AddWithValue("@status", status);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void CarregarPagamentosContasPagar(int idContaPagar, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            string connectionString = DBConnection.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para buscar os dados da tabela pagamentos_contareceber com base no id_contareceber
                    string query = @"
                        SELECT 
                            id_pagamento, 
                            data_pagamento, 
                            valorparcela_pagamento, 
                            status_pagamento
                        FROM pagamentos_contapagar
                        WHERE id_contapagar = @idContaPagar";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContaPagar", idContaPagar);

                        // Adaptador para preencher o DataTable com os dados da consulta
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }

                    // Preencher o DataGridView com o DataTable
                    dgv.DataSource = dt;

                    // Formatando os cabeçalhos das colunas
                    dgv.Columns["id_pagamento"].HeaderText = "ID Pagamento";
                    dgv.Columns["data_pagamento"].HeaderText = "Data do Pagamento";
                    dgv.Columns["valorparcela_pagamento"].HeaderText = "Valor da Parcela";
                    dgv.Columns["status_pagamento"].HeaderText = "Status do Pagamento";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os detalhes do pagamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
