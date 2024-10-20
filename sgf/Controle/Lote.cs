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
    internal class Lote
    {
        public int Id { get; set; }
        public string Code_Lote { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Vencimento { get; set; }
        public string Status { get; set; }



        public Lote(string code_Lote, DateTime vencimento, string status, string fornecedor)
        {
            Code_Lote = code_Lote;
            Fornecedor = fornecedor;
            Vencimento = vencimento;
            Status = status;
        }

        public static void PreencherComboBoxLote(ComboBox comboBox)
        {
            // Limpar os itens atuais do ComboBox
            comboBox.Items.Clear();

            // Definir a string de conexão (substitua pelos seus próprios parâmetros)
            string connectionString = DBConnection.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir a conexão com o banco de dados
                    connection.Open();

                    // Consulta SQL para buscar os códigos de lote
                    string query = "SELECT code_lote FROM lote";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Adicionar os resultados ao ComboBox
                            while (reader.Read())
                            {
                                string codeLote = reader.GetString("code_lote");
                                comboBox.Items.Add(codeLote);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher o ComboBox: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static DataTable CarregarDadosLote()
        {

            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_lote, Code_Lote, dt_validade_lote, farmaceutica_lote, status_lote FROM lote";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    dt.Columns["id_lote"].ColumnName = "ID";
                    dt.Columns["code_lote"].ColumnName = "Code";
                    dt.Columns["dt_validade_lote"].ColumnName = "Validade";
                    dt.Columns["status_lote"].ColumnName = "Status";
                    dt.Columns["farmaceutica_lote"].ColumnName = "Farmaceutica";

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar lotes: " + ex.Message);
                }
            }

            return dt;
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
