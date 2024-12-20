﻿using MySql.Data.MySqlClient;
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
    internal class DetalhesContaReceber
    {
        public static void SalvarDetalhes(int contareceber, DateTime data, float valor, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO pagamentos_contareceber (id_contareceber, data_pagamento, valorparcela_pagamento, status_pagamento) " +
                    "VALUES (@contareceber, @data, @valor, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@contareceber", contareceber);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@valor", valor);
                command.Parameters.AddWithValue("@status", status);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static void CarregarPagamentosContasReceber(int idContaReceber, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            string connectionString = DBConnection.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    string query = @"
                        SELECT 
                            id_pagamento, 
                            data_pagamento, 
                            valorparcela_pagamento, 
                            status_pagamento
                        FROM pagamentos_contareceber
                        WHERE id_contareceber = @idContaReceber";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContaReceber", idContaReceber);


                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }


                    dgv.DataSource = dt;


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
