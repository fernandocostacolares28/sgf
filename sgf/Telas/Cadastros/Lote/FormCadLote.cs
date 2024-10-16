using MySql.Data.MySqlClient;
using sgf.Controle;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Cadastros.Lote
{
    public partial class FormCadLote : Form
    {
        public FormCadLote()
        {
            InitializeComponent();
            CarregarProdutos();
            CarregarFornecedores();
            CarregarDadosLote();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (lb_pc.SelectedItem != null && !string.IsNullOrWhiteSpace(tb_Qtd.Text))
            {
                // Obter o produto selecionado na ListBox1
                string produtoSelecionado = lb_pc.SelectedItem.ToString();

                // Obter a quantidade digitada no TextBox
                string quantidade = tb_Qtd.Text;

                // Adicionar o produto e a quantidade na ListBox2
                lb_pl.Items.Add($"{produtoSelecionado} - Quantidade: {quantidade}");

                // Limpar a seleção e o campo de texto
                lb_pc.ClearSelected();
                tb_Qtd.Clear();
            }
            else
            {
                MessageBox.Show("Selecione um produto e informe a quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarProdutos()
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT name_produto FROM produto";
                try
                {
                    // Abrir a conexão com o banco
                    connection.Open();

                    // Criar o comando SQL
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Executar a leitura dos dados
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Ler os produtos e adicionar na ListBox1
                            while (reader.Read())
                            {
                                lb_pc.Items.Add(reader["name_produto"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibir mensagem de erro, se ocorrer
                    MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (lb_pl.SelectedItem != null)
            {
                // Remover o item selecionado da ListBox2
                lb_pl.Items.Remove(lb_pl.SelectedItem);
            }
            else
            {
                // Exibir mensagem de erro se nenhum item estiver selecionado
                MessageBox.Show("Selecione um item na ListBox2 para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            // Pegar os valores dos controles
            string code_lote = tb_codelote.Text;
            DateTime vencimento = dtp_vencimento.Value;
            string fornecedor = cb_fornecedor.SelectedItem.ToString();

            // Verificar o status do checkbox (Ativo ou Inativo)
            string status = cbx_ativo.Checked ? "Ativo" : "Inativo";

            var lote = new Controle.Lote(code_lote, vencimento, status, fornecedor);

            // Chamar o método Salvar com os valores capturados
            Controle.Lote.SalvarLote(lote);

            try
            {
                // Iterar sobre os itens da ListBox2 (onde estão os produtos a serem salvos)
                foreach (string item in lb_pl.Items)
                {
                    // Supondo que o item esteja no formato "Produto - Quantidade: X"
                    string[] partes = item.Split(new[] { " - Quantidade: " }, StringSplitOptions.None);
                    string nomeProduto = partes[0]; // Nome do produto
                    int quantidade = int.Parse(partes[1]); // Quantidade
                    
                    float valor = Controle.ProdutoLote.ObterValorProduto(nomeProduto);
                    int id_lote = Controle.ProdutoLote.ObterIdLote(code_lote);

                    var ProdutoLote = new ProdutoLote(nomeProduto, valor, quantidade, id_lote);
                    // Chamar o método existente SalvarProduto
                    Controle.ProdutoLote.SalvarProdutoLote(ProdutoLote);

                }

                MessageBox.Show("Produtos cadastrados com sucesso na tabela produto_lote!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CarregarDadosLote();
        }

        private void CarregarFornecedores()
        {

            // Usar SqlConnection e SqlCommand para conectar ao banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT razaosocial_fornecedor FROM Fornecedor";
                try
                {
                    // Abrir a conexão com o banco
                    connection.Open();

                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Executar a leitura dos dados
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Limpar o ComboBox antes de adicionar os novos itens
                            cb_fornecedor.Items.Clear();

                            // Adicionar os fornecedores no ComboBox
                            while (reader.Read())
                            {
                                // Pegar o valor da coluna 'NomeFornecedor' e adicionar ao ComboBox
                                cb_fornecedor.Items.Add(reader["razaosocial_fornecedor"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibir mensagem de erro, se ocorrer
                    MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CarregarDadosLote()
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT id_lote, Code_Lote, dt_validade_lote, farmaceutica_lote, status_lote FROM lote";
                try
                {
                    connection.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable); // Preencher o DataTable com os dados

                    // Definir a fonte de dados do DataGridView
                    DGV_Lote.DataSource = dataTable;

                    DGV_Lote.Columns[0].HeaderText = "ID";                // ID
                    DGV_Lote.Columns[1].HeaderText = "Código Lote";      // Código Lote
                    DGV_Lote.Columns[2].HeaderText = "Vencimento";       // Vencimento
                    DGV_Lote.Columns[3].HeaderText = "Farmaceutica";     // Farmacêutica
                    DGV_Lote.Columns[4].HeaderText = "Status Lote";      // Status Lote
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (DGV_Lote.SelectedRows.Count > 0)
            {
                
                int idLote = Convert.ToInt32(DGV_Lote.SelectedRows[0].Cells["id_lote"].Value); 

                
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este lote?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Excluir o lote
                    Controle.Lote.ExcluirLote(idLote);

                    // Recarregar os dados do DataGridView
                    CarregarDadosLote();

                    MessageBox.Show("Lote excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um lote para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGV_Lote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_desativar_Click(object sender, EventArgs e)
        {
            if (DGV_Lote.SelectedRows.Count > 0)
            {
                // Obter o ID do lote selecionado
                int idLote = Convert.ToInt32(DGV_Lote.SelectedRows[0].Cells["id_lote"].Value); // Assumindo que a coluna ID é nomeada "ID"

                // Confirmar a desativação
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja desativar este lote?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Desativar o lote
                    Controle.Lote.DesativarLote(idLote);

                    // Recarregar os dados do DataGridView
                    CarregarDadosLote();

                    MessageBox.Show("Lote desativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um lote para desativar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (DGV_Lote.SelectedRows.Count > 0)
            {
                // Obter o ID do lote selecionado
                int idLote = Convert.ToInt32(DGV_Lote.SelectedRows[0].Cells["id_lote"].Value); // Assumindo que a coluna ID é nomeada "ID"

                // Criar e mostrar o formulário de detalhes
                FormDetalhesLote formDetalhes = new FormDetalhesLote(idLote);
                formDetalhes.ShowDialog(); // Ou Show() se você não quiser que o formulário seja modal
            }
            else
            {
                MessageBox.Show("Selecione um lote para visualizar os detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCadLote_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
