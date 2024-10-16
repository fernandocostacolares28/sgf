﻿using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Controle
{
    internal class Lote
    {
        public int Id { get; set; }
        public string Code_Lote { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Vencimento { get; set; }
        public string Status { get; set; }

        public void Lote_id(int id, string code_Lote, string fornecedor, DateTime vencimento, string status)
        {
            Id = id;
            Code_Lote = code_Lote;
            Fornecedor = fornecedor;
            Vencimento = vencimento;
            Status = status;
        }

        public Lote(string code_Lote, DateTime vencimento, string status, string fornecedor)
        {
            Code_Lote = code_Lote;
            Fornecedor = fornecedor;
            Vencimento = vencimento;
            Status = status;
        }

        public static void SalvarLote(Lote Lote) 
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Lote (code_lote, dt_validade_lote, status_lote, farmaceutica_lote) VALUES (@code_lote, @vencimento, @status, @fornecedor)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@code_lote", Lote.Code_Lote);
                command.Parameters.AddWithValue("@vencimento", Lote.Vencimento);
                command.Parameters.AddWithValue("@status", Lote.Status);
                command.Parameters.AddWithValue("@fornecedor", Lote.Fornecedor);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void ExcluirLote(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Lote WHERE id_lote = @Id";
                string query_produto = "DELETE FROM produto_lote WHERE id_lote = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlCommand command2 = new MySqlCommand(query_produto, connection);
                command.Parameters.AddWithValue("@lote", id);
                command2.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        public static void DesativarLote(int idLote)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "UPDATE lote SET status_lote = 'Desativado' WHERE id_lote = @idlote";
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idLote", idLote);
                        command.ExecuteNonQuery(); // Executa a atualização
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desativar lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
