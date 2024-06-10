using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Lvl { get; set; }
        public int Funcionario { get; set; }

        public Usuario(int id, string user, string password, string lvl, int funcionario)
        {
            Id = id;
            User = user;
            Password = password;
            Lvl = lvl;
            Funcionario = funcionario;
        }

        public Usuario(string user, string password, string lvl, int funcionario)
        {
            User = user;
            Password = password;
            Lvl = lvl;
            Funcionario = funcionario;
        }

        public static DataTable ListarUsuario()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT u.id_usuario, u.name_usuario, u.password_usuario, u.lvl_usuario, f.name_funcionario FROM Usuario u INNER JOIN Funcionario f ON u.id_funcionario = f.id_funcionario WHERE f.id_funcionario = u.id_funcionario;";

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

        public List<string> CarregarFuncionarios()
        {
            List<string> funcionarios = new List<string>();

            // Define a consulta SQL para obter os nomes dos funcionários
            string query = "SELECT name_funcionario FROM funcionario";

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Cria um comando para executar a consulta
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Executa a consulta e obtém os resultados
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Adiciona cada nome de funcionário à lista
                            while (reader.Read())
                            {
                                string nomeFuncionario = reader.GetString("name_funcionario");
                                funcionarios.Add(nomeFuncionario);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar os dados: " + ex.Message);
                }
            }

            return funcionarios;
        }

        public static void SalvarUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"INSERT INTO Usuario (name_usuario, password_usuario, lvl_usuario, id_funcionario) VALUES (@User, @Password, @Lvl, @Funcionario)";


                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@User", usuario.User);
                command.Parameters.AddWithValue("@Password", usuario.Password);
                command.Parameters.AddWithValue("@Lvl", usuario.Lvl);
                command.Parameters.AddWithValue("@Funcionario", usuario.Funcionario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarUsuario(int id, string user, string password, string lvl, int funcionario)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Usuario SET name_usuario = @User, password_usuario = @Password, lvl_usuario = @Lvl, id_funcionario = @Funcionario WHERE id_usuario = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@User", user);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Lvl", lvl);
                    command.Parameters.AddWithValue("@Funcionario", funcionario);
                    command.Parameters.AddWithValue("@Id", id);


                    // Executa a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirUsuario(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Usuario WHERE id_usuario = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
