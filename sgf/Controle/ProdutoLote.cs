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

        public void ProdutoLoteID(int id, string nomeProduto, float valor, int quantidade, Int32 lote)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

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
                        // Executar a consulta e obter o valor
                        object resultado = command.ExecuteScalar();

                        // Verificar se um valor foi retornado
                        if (resultado != null)
                        {
                            return Convert.ToSingle(resultado); // Retorna o valor do produto
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
                    return 0; // Retorna 0 ou um valor padrão em caso de erro
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

                    // Executar a consulta e obter o ID
                    object resultado = command.ExecuteScalar();
                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado); // Retorna o ID do lote
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
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT p.id_produto, p.name_produto, p.qtd_produto, p.valor_produto, l.code_lote FROM produto_lote p INNER JOIN lote l ON p.id_Lote = l.id_lote WHERE l.status_lote = 'Ativo';";

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
    }
}
