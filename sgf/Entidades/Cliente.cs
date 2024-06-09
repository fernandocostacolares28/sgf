using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente(string nome, string cpf, string telefone, string endereco)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
        }

        public static DataTable ListarCliente()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT * FROM Cliente";

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

        public static void SalvarCliente(Cliente Cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Cliente (name_cliente, cpf_cliente, telefone_cliente, endereco_cliente) VALUES (@Nome, @CPF, @Telefone, @Endereco)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", Cliente.Nome);
                command.Parameters.AddWithValue("@CPF", Cliente.CPF);
                command.Parameters.AddWithValue("@Telefone", Cliente.Telefone);
                command.Parameters.AddWithValue("@Endereco", Cliente.Endereco);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarCliente(int id, string nome, string cpf, string telefone, string endereco)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Cliente SET name_cliente = @Nome, cpf_cliente = @CPF, telefone_cliente = @Telefone, endereco_cliente = @Endereco WHERE id_cliente = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@CPF", cpf);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Id", id);


                    // Executa a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirCliente(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Cliente WHERE id_cliente = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
