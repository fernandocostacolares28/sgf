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
        public int Quantidade { get; set; }
        public string Lote { get; set; }

        // Construtor 
        public Produto(int id, string nomeProduto, float valor, int quantidade, string lote)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

        public Produto(string nomeProduto, float valor, int quantidade, string lote)
        {
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

        // Método para listar todos os produtos
        public static DataTable ListarProdutos()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT * FROM Produto";

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

        // Método para salvar um novo produto
        public static void SalvarProduto(Produto produto)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Produto (name_produto, valor_produto, qtd_produto, lote_produto) VALUES (@NomeProduto, @Valor, @Quantidade, @Lote)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                command.Parameters.AddWithValue("@Valor", produto.Valor);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Lote", produto.Lote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarProduto(int id, string nomeProduto, float valor, int quantidade, string lote)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Produto SET name_produto = @NomeProduto, valor_produto = @Valor, qtd_produto = @Quantidade, lote_produto = @lote WHERE id_produto = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@NomeProduto", nomeProduto);
                    command.Parameters.AddWithValue("@Lote", lote);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
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
            Console.WriteLine($"Quantidade: {Quantidade}");
            Console.WriteLine($"Lote: {Lote}");
        }
    }
}


