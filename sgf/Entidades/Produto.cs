using System;
using System.Collections.Generic;
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
        public static List<Produto> ListarProdutos()
        {
            var produtos = new List<Produto>();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_produto, name_produto, valor_produto, qtd_produto, lote_produto FROM PRODUTO";

                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Produto produto = new Produto(
                        (int)reader["id"],
                        (string)reader["Nome Produto"],
                        (float)reader["Valor"],
                        (int)reader["Quantidade"],
                        (string)reader["Lote"]
                    );
                    produtos.Add(produto);
                }
            }

            return produtos;
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

        // Método para editar um produto
        public static void EditarProduto(Produto produto)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "UPDATE Produtos SET name_produto = @NomeProduto, valor_produto = @Valor, qtd_produto = @Quantidade, lote_produto = @Lote WHERE id = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", produto.Id);
                command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                command.Parameters.AddWithValue("@Valor", produto.Valor);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Lote", produto.Lote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para excluir um produto
        public static void ExcluirProduto(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Produtos WHERE id = @Id";

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


