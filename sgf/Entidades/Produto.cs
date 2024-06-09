using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }

        // Construtor
        public Produto(string nomeProduto, string lote, int quantidade, float valor)
        {
            NomeProduto = nomeProduto;
            Lote = lote;
            Quantidade = quantidade;
            Valor = valor;
        }


        // Método para listar todos os produtos
        public static List<Produto> ListarProdutos()
        {
            var produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT Id, NomeProduto, Lote, Quantidade, Valor FROM Produtos";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Produto produto = new Produto(
                        (string)reader["NomeProduto"],
                        (string)reader["Lote"],
                        (int)reader["Quantidade"],
                        (float)reader["Valor"]
                    );
                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        // Método para salvar um novo produto
        public static void SalvarProduto(Produto produto)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Produtos (NomeProduto, Lote, Quantidade, Valor) VALUES (@NomeProduto, @Lote, @Quantidade, @Valor)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                command.Parameters.AddWithValue("@Lote", produto.Lote);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Valor", produto.Valor);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para editar um produto
        public static void EditarProduto(Produto produto)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "UPDATE Produtos SET NomeProduto = @NomeProduto, Lote = @Lote, Quantidade = @Quantidade, Valor = @Valor WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", produto.Id);
                command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                command.Parameters.AddWithValue("@Lote", produto.Lote);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Valor", produto.Valor);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para excluir um produto
        public static void ExcluirProduto(int id)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Produtos WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
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
            Console.WriteLine($"Lote: {Lote}");
            Console.WriteLine($"Quantidade: {Quantidade}");
            Console.WriteLine($"Valor: {Valor:C}");
        }
    }
}

