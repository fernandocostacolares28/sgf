using sgf.Telas.Financeiro.ContasReceber;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Financeiro.ContasPagar
{
    public partial class FormContasPagar : Form
    {
        public FormContasPagar()
        {
            InitializeComponent();
            DGV_contapagar.DataSource = Controle.ContasPagar.CarregarContasPagar();

        }

        private void bt_pagar_Click(object sender, EventArgs e)
        {
            if (DGV_contapagar.SelectedRows.Count > 0)
            {
                // Obtém o ID da conta a receber da linha selecionada
                int idContasPagar = Convert.ToInt32(DGV_contapagar.SelectedRows[0].Cells["ID Conta Pagar"].Value);

                // Chama o método PagarParcela, passando o ID da conta a receber
                try
                {
                    // Você pode adicionar aqui a lógica para verificar se o pagamento foi bem-sucedido
                    Controle.ContasPagar.PagarParcela(idContasPagar);

                    // Opcional: Atualizar o DataGridView após o pagamento
                    DGV_contapagar.DataSource = Controle.ContasPagar.CarregarContasPagar();

                    MessageBox.Show("Parcela recebida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao receber a parcela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma parcela para receber.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DGV_contapagar.DataSource = Controle.ContasPagar.CarregarContasPagar();
        }

        private void bt_detalhes_Click(object sender, EventArgs e)
        {
            if (DGV_contapagar.SelectedRows.Count > 0)
            {
                int idContaPagar = Convert.ToInt32(DGV_contapagar.SelectedRows[0].Cells["ID Conta Pagar"].Value);

                FormDetalhesContaPagar detalhesForm = new FormDetalhesContaPagar(idContaPagar);

                detalhesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma conta a pagar para visualizar os detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormContasPagar_Load(object sender, EventArgs e)
        {

        }

        private void tb_filtro_TextChanged(object sender, EventArgs e)
        {
            DGV_contapagar.DataSource = Controle.ContasPagar.FiltrarContasPagar(tb_filtro.Text);
        }
    }
}
