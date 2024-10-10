using MySql.Data.MySqlClient;
using sgf.Controle;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Movimentos.Compra
{
    public partial class FormCompra : Form
    {
        public FormCompra()
        {
            InitializeComponent();
            CarregarFornecedor();
            DataTable compras = Controle.Compra.CarregarCompras();
            DGV_Compra.DataSource = compras;
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            try
            {

                string nomeFornecedor = cb_fornecedor.SelectedItem.ToString();
                int id_fornecedor = Controle.Compra.ObterIdFornecedor(nomeFornecedor); 

                DateTime data = dtp_data.Value;

                string metodoPagamento = cb_metodo.SelectedItem.ToString();

                int parcelas = (int)nud_parcelas.Value;

                float totalCompra = float.Parse(tb_total.Text);

                int idCompra = Controle.Compra.SalvarCompra(id_fornecedor, data, metodoPagamento, totalCompra, parcelas);


                MessageBox.Show("Compra salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable compras = Controle.Compra.CarregarCompras();
                DGV_Compra.DataSource = compras;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarFornecedor()
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT razaosocial_fornecedor FROM fornecedor";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cb_fornecedor.Items.Add(reader["razaosocial_fornecedor"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FormCompra_Load(object sender, EventArgs e)
        {

        }

        private void bt_entregue_Click(object sender, EventArgs e)
        {
            if (DGV_Compra.SelectedRows.Count > 0) // Verifica se alguma linha está selecionada
            {
                int idCompra = Convert.ToInt32(DGV_Compra.SelectedRows[0].Cells["ID"].Value); // Obtém o ID da venda selecionada

                try
                {
                    Controle.Compra.AlterarStatusCompra(idCompra);
                    MessageBox.Show("Status alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable compra = Controle.Compra.CarregarCompras();
                    DGV_Compra.DataSource = compra;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma compra para alterar o status.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            if (DGV_Compra.SelectedRows.Count > 0)
            {
                int idCompra = Convert.ToInt32(DGV_Compra.SelectedRows[0].Cells["ID"].Value); // Obtém o ID da venda selecionada

                try
                {
                    Controle.Compra.ExcluirCompraComAssociados(idCompra);
                    MessageBox.Show("Compra excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable compra = Controle.Compra.CarregarCompras();
                    DGV_Compra.DataSource = compra;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma compra para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGV_Compra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


