using MySql.Data.MySqlClient;
using sgf.Controle;
using sgf.Entidades;
using sgf.Telas.Movimentos.Venda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Movimentos
{
    public partial class FormVenda : Form
    {
        public FormVenda()
        {
            InitializeComponent();
            CarregarProdutos();
            CarregarClientes();
            DataTable vendas = Controle.Venda.CarregarVendas();
            DGV_Venda.DataSource = vendas; // Atribui a DataTable ao DataGridView

        }

        private void FormVenda_Load(object sender, EventArgs e)
        {

        }

        private void lb_prod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarregarProdutos()
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT pl.name_produto FROM produto_lote pl INNER JOIN lote l ON pl.id_lote = l.id_lote WHERE l.status_lote = 'Ativo';";
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
                                lb_prod.Items.Add(reader["name_produto"].ToString());
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

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (lb_prod.SelectedItem != null)
            {
                if (lb_prod.SelectedItem != null)
                {
                    string nomeProduto = lb_prod.SelectedItem.ToString();

                    if (int.TryParse(tb_Qtd.Text, out int quantidade) && quantidade > 0)
                    {
                        float valorProduto = Controle.Venda.ObterValorProduto(nomeProduto); 

                        float valorTotalProduto = valorProduto * quantidade;

                        lb_carrinho.Items.Add($"{nomeProduto} - Quantidade: {quantidade} - Valor Unitário: {valorProduto:C2}");

                        if (string.IsNullOrEmpty(tb_totalvenda.Text))
                        {
                            tb_totalvenda.Text = "0";
                        }

                        float valorAtualTotal = float.Parse(tb_totalvenda.Text);

                        float novoTotal = valorAtualTotal + valorTotalProduto;

                        tb_totalvenda.Text = novoTotal.ToString("F2"); 
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            string itemSelecionado = lb_carrinho.SelectedItem.ToString();

            string[] partesItem = itemSelecionado.Split('-');
            string nomeProduto = partesItem[0].Trim();
            int quantidade = int.Parse(partesItem[1].Replace("Quantidade: ", "").Trim());
            float valorUnitario = float.Parse(partesItem[2].Replace("Valor Unitário: R$", "").Trim());

            float valorTotalRemovido = valorUnitario * quantidade;

            float valorAtualTotal = float.Parse(tb_totalvenda.Text);

            float novoTotal = valorAtualTotal - valorTotalRemovido;

            tb_totalvenda.Text = novoTotal.ToString("F2");

            lb_carrinho.Items.Remove(lb_carrinho.SelectedItem);
        }

        private void bt_desconto_Click(object sender, EventArgs e)
        {
            if (float.TryParse(tb_desconto.Text, out float desconto) && desconto > 0 && desconto <= 100)
            {
                if (float.TryParse(tb_totalvenda.Text, out float valorTotal))
                {
                    float valorDesconto = (desconto / 100) * valorTotal;

                    float novoTotal = valorTotal - valorDesconto;

                    tb_totalvenda.Text = novoTotal.ToString("F2"); 
                }
                else
                {
                    MessageBox.Show("Valor total inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor de desconto válido entre 0 e 100.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarClientes()
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT name_cliente FROM cliente";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Adiciona o nome do cliente ao ComboBox
                        cb_cliente.Items.Add(reader["name_cliente"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenha o valor selecionado da ComboBox cliente
                string nomeCliente = cb_cliente.SelectedItem.ToString();
                int id_cliente = Controle.Venda.ObterIdCliente(nomeCliente); // Método que busca o ID do cliente no banco

                // Obtenha o valor da receita do TextBox tb_receita
                string receita = tb_receita.Text;

                // Obtenha a data do DateTimePicker dtp_data
                DateTime data = dtp_data.Value;

                // Obtenha o método de pagamento da ComboBox cb_metodo
                string metodoPagamento = cb_metodo.SelectedItem.ToString();

                // Obtenha o número de parcelas do NumericUpDown nud_parcelas
                int parcelas = (int)nud_parcelas.Value;

                // Obtenha o valor total da venda do TextBox tb_totalvenda
                float totalVenda = float.Parse(tb_totalvenda.Text);

                // Obtenha o valor do desconto do TextBox tb_desconto
                float desconto = float.Parse(tb_desconto.Text);

                // Obtenha os produtos do ListBox lb_carrinho
                List<ItemVenda> carrinho = new List<ItemVenda>();
                foreach (string item in lb_carrinho.Items)
                {
                    ItemVenda produto = Controle.ItemVenda.ExtrairProdutoDoCarrinho(item); // Método que extrai informações de um item do carrinho
                    carrinho.Add(produto);
                }

                // Salva a venda e retorna o id da venda
                int idVenda = Controle.Venda.SalvarVenda(id_cliente, receita, data, metodoPagamento, parcelas, totalVenda, desconto);

                // Salva os itens do carrinho relacionados a essa venda
                Controle.ItemVenda.SalvarItensVenda(idVenda, carrinho);

                foreach (ItemVenda produto in carrinho)
                {
                    Controle.ItemVenda.AtualizarEstoque(produto.NomeProduto, produto.Quantidade);
                }

                MessageBox.Show("Venda salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable vendas = Controle.Venda.CarregarVendas();
                DGV_Venda.DataSource = vendas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (DGV_Venda.SelectedRows.Count > 0) // Verifica se alguma linha está selecionada
            {
                int idVenda = Convert.ToInt32(DGV_Venda.SelectedRows[0].Cells["ID"].Value); // Obtém o ID da venda selecionada

                // Exclui a venda
                try
                {
                    Controle.Venda.Excluir(idVenda);
                    MessageBox.Show("Venda excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable vendas = Controle.Venda.CarregarVendas();
                    DGV_Venda.DataSource = vendas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma venda para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (DGV_Venda.SelectedRows.Count > 0) // Verifica se uma linha está selecionada no DataGridView
            {
                // Obtém o ID da venda da linha selecionada
                int idVenda = Convert.ToInt32(DGV_Venda.SelectedRows[0].Cells["ID"].Value);

                // Abre o formulário de detalhes da venda
                FormDetalhesVenda detalhesVendaForm = new FormDetalhesVenda(idVenda);
                detalhesVendaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma venda para visualizar os detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
