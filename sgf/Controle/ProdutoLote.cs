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
    internal class ProdutoLote
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public float Valor { get; set; }
        public int Quantidade { get; set; }
        public Int32 Lote { get; set; }

        public ProdutoLote(string nomeProduto, float valor, int quantidade, Int32 lote)
        {
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }
        public static void SalvarProdutoLote(ProdutoLote ProdutoLote)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO produto_lote (name_produto, valor_produto, qtd_produto, id_lote) VALUES (@nomeProduto, @valor, @quantidade, @lote)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeProduto", ProdutoLote.NomeProduto);
                command.Parameters.AddWithValue("@valor", ProdutoLote.Valor);
                command.Parameters.AddWithValue("@quantidade", ProdutoLote.Quantidade);
                command.Parameters.AddWithValue("@lote", ProdutoLote.Lote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static float ObterValorProduto(string nomeProduto)
        {
        
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT valor_produto FROM produto WHERE name_produto = @nomeProduto";
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nomeProduto", nomeProduto);

                        object resultado = command.ExecuteScalar();

                        if (resultado != null)
                        {
                            return Convert.ToSingle(resultado); 
                        }
                        else
                        {
                            throw new Exception("Produto não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter valor do produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; 
                }
            }
        }

        public static int ObterIdLote(string code_lote)
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_lote FROM lote WHERE code_Lote = @code_lote";
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@code_lote", code_lote);

                    
                    object resultado = command.ExecuteScalar();
                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado); 
                    }
                    else
                    {
                        throw new Exception("Lote não encontrado.");
                    }
                }
            }
        }

        public static void ExcluirProdutoLote(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM produto_lote WHERE id_lote = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static DataTable ListarProdutos()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                connection.Open();

                string query = "SELECT p.id_produto, p.name_produto, p.qtd_produto, p.valor_produto, l.code_lote FROM produto_lote" +
                    " p INNER JOIN lote l ON p.id_Lote = l.id_lote WHERE l.status_lote = 'Ativo';";

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

        public static DataTable ListarProdutosUnico(int id)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                connection.Open();

                string query = "SELECT p.id_produto, p.name_produto, p.qtd_produto, p.valor_produto, l.code_lote FROM produto_lote" +
                    " p INNER JOIN lote l ON p.id_Lote = l.id_lote WHERE p.id_lote = @Id;";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static DataTable FiltrarProdutos(string filtro)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT pl.name_produto 
                    FROM produto_lote pl
                    JOIN lote l ON pl.id_lote = l.id_lote
                    WHERE pl.name_produto LIKE @filtro AND l.status_lote = 'Ativo'";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao filtrar produtos: " + ex.Message);
                }
            }

            return dt;
        }
    }
}
