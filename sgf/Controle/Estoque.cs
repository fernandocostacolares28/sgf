using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Controle
{
    internal class Estoque
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public float Valor { get; set; }
        public int Quantidade { get; set; }
        public string Lote { get; set; }

        public Estoque(int id, string nomeProduto, float valor, int quantidade, string lote)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

        public Estoque(string nomeProduto, float valor, int quantidade, string lote)
        {
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

        // Método para listar todos os produtos
        public static DataTable ListarProdutos(string lote)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(Entidades.DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT * FROM Produto WHERE lote_produto = @Lote";
                MySqlCommand command1 = new MySqlCommand(query, connection);
                command1.Parameters.AddWithValue("@Lote", lote);

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Cria um adaptador de dados MySQL
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command1))
                    {
                        // Preenche o DataTable com os dados da consulta
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static void ExcluirLote(int lote)
        {
            using (MySqlConnection connection = new MySqlConnection(Entidades.DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Produto WHERE lote_produto = @Lote";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Lote", lote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
