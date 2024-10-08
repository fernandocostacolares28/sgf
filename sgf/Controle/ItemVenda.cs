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
    internal class ItemVenda
    {
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }
        public float ValorTotal
        {
            get
            {
                return Quantidade * ValorUnitario;
            }
        }

        public static ItemVenda ExtrairProdutoDoCarrinho(string itemCarrinho)
        {
            // Exemplo: "NomeProduto - Quantidade: X - Valor Unitário: R$Y.YY"
            string[] partesItem = itemCarrinho.Split('-');
            string nomeProduto = partesItem[0].Trim();
            int quantidade = int.Parse(partesItem[1].Replace("Quantidade: ", "").Trim());
            float valorUnitario = float.Parse(partesItem[2].Replace("Valor Unitário: R$", "").Trim());

            return new ItemVenda
            {
                NomeProduto = nomeProduto,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario
            };
        }

        public static void SalvarItensVenda(int id_venda, List<ItemVenda> carrinho)
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string queryItemVenda = @"
                INSERT INTO item_venda (id_venda, name_produto, quantidade_produto, valor_unitario)
                VALUES (@id_venda, @nome_produto, @quantidade, @valor_unitario);";
                MySqlCommand command = new MySqlCommand(queryItemVenda, connection);

                try
                {
                    connection.Open();
                    foreach (ItemVenda item in carrinho)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id_venda", id_venda);
                        command.Parameters.AddWithValue("@nome_produto", item.NomeProduto);
                        command.Parameters.AddWithValue("@quantidade", item.Quantidade);
                        command.Parameters.AddWithValue("@valor_unitario", item.ValorUnitario);

                        // Inserindo cada item do carrinho na tabela item_venda
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar os itens da venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }

        public static void AtualizarEstoque(string nomeProduto, int quantidadeVendida)
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string queryAtualizarEstoque = @"
                UPDATE produto_lote AS pl
                JOIN lote AS l ON pl.id_lote = l.id_lote
                SET pl.qtd_produto = pl.qtd_produto - @quantidadeVendida 
                WHERE pl.name_produto = @nomeProduto 
                AND l.status_lote = 'ativo';";
                MySqlCommand command = new MySqlCommand(queryAtualizarEstoque, connection);
                command.Parameters.AddWithValue("@quantidadeVendida", quantidadeVendida);
                command.Parameters.AddWithValue("@nomeProduto", nomeProduto);

                try
                {
                    connection.Open();
                    int linhasAfetadas = command.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    {
                        MessageBox.Show("Produto não encontrado no estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar o estoque: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static DataTable CarregarItensVenda(int idVenda)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT iv.name_produto, iv.quantidade_produto, iv.valor_unitario
                    FROM item_venda iv
                    WHERE iv.id_venda = @id_venda";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_venda", idVenda);

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    // Definir os nomes das colunas (opcional)
                    dt.Columns["name_produto"].ColumnName = "Nome do Produto";
                    dt.Columns["quantidade_produto"].ColumnName = "Quantidade";
                    dt.Columns["valor_unitario"].ColumnName = "Valor Unitário";
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar itens da venda: " + ex.Message);
                }
            }

            return dt;
        }
    }
}
