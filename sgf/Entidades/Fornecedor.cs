using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    internal class Fornecedor
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Fornecedor(int id, string razaosocial, string cnpj, string telefone, string endereco)
        {
            Id = id;
            RazaoSocial = razaosocial;
            CNPJ = cnpj;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Fornecedor(string razaosocial, string cnpj, string telefone, string endereco)
        {
            RazaoSocial = razaosocial;
            CNPJ = cnpj;
            Telefone = telefone;
            Endereco = endereco;
        }

        public static DataTable ListarFornecedor()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT * FROM Fornecedor";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Cria um adaptador de dados MySQL
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // Preenche o DataTable com os dados da consulta
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static void SalvarFornecedor(Fornecedor Fornecedor)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Fornecedor (razaosocial_fornecedor, cnpj_fornecedor, telefone_fornecedor, endereco_fornecedor) VALUES (@RazaoSocial, @CNPJ, @Telefone, @Endereco)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RazaoSocial", Fornecedor.RazaoSocial);
                command.Parameters.AddWithValue("@CNPJ", Fornecedor.CNPJ);
                command.Parameters.AddWithValue("@Telefone", Fornecedor.Telefone);
                command.Parameters.AddWithValue("@Endereco", Fornecedor.Endereco);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarFornecedor(int id, string razaosocial, string cnpj, string telefone, string endereco)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Fornecedor SET razaosocial_fornecedor = @RazaoSocial, cnpj_fornecedor = @CNPJ, telefone_fornecedor = @Telefone, endereco_fornecedor = @Endereco WHERE id_fornecedor = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@RazaoSocial", razaosocial);
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Id", id);


                    // Executa a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirFornecedor(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Fornecedor WHERE id_fornecedor = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
