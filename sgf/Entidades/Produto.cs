using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sgf.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public float Valor { get; set; }


        public Produto(int id, string nomeProduto, float valor)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;

        }

        public Produto(string nomeProduto, float valor)
        {
            NomeProduto = nomeProduto;
            Valor = valor;

        }

        public static DataTable ListarProdutos()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM Produto";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }


        public static void SalvarProduto(Produto produto)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Produto (name_produto, valor_produto) VALUES (@NomeProduto, @Valor)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                command.Parameters.AddWithValue("@Valor", produto.Valor);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarProduto(int id, string nomeProduto, float valor)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Produto SET name_produto = @NomeProduto, valor_produto = @Valor WHERE id_produto = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@NomeProduto", nomeProduto);
                    command.Parameters.AddWithValue("@Valor", valor);
                    command.Parameters.AddWithValue("@Id", id);

                    // Executa a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para excluir um produto
        public static void ExcluirProduto(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Produto WHERE id_produto = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para exibir os detalhes do produto
        public void ExibirDetalhes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome do Produto: {NomeProduto}");
            Console.WriteLine($"Valor: {Valor}");
        }
    }
}


