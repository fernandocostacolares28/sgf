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


        public static DataTable ListarProdutos(string lote)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(Entidades.DBConnection.GetConnectionString()))
            {
                
                connection.Open();

                
                string query = "SELECT * FROM Produto WHERE lote_produto = @Lote";
                MySqlCommand command1 = new MySqlCommand(query, connection);
                command1.Parameters.AddWithValue("@Lote", lote);

                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                   
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command1))
                    {
                     
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

    }
}
