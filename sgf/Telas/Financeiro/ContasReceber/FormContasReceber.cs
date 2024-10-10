using sgf.Controle;
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

namespace sgf.Telas.Financeiro
{
    public partial class FormContasReceber : Form
    {
        public FormContasReceber()
        {
            InitializeComponent();
            DGV_contareceber.DataSource = Controle.ContasReceber.CarregarContasReceber();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DGV_contareceber.SelectedRows.Count > 0)
            {
                // Obtém o ID da conta a receber da linha selecionada
                int idContasReceber = Convert.ToInt32(DGV_contareceber.SelectedRows[0].Cells["ID Conta Receber"].Value);

                // Chama o método PagarParcela, passando o ID da conta a receber
                try
                {
                    // Você pode adicionar aqui a lógica para verificar se o pagamento foi bem-sucedido
                    Controle.ContasReceber.PagarParcela(idContasReceber);

                    // Opcional: Atualizar o DataGridView após o pagamento
                    DGV_contareceber.DataSource = Controle.ContasReceber.CarregarContasReceber();

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
            DGV_contareceber.DataSource = Controle.ContasReceber.CarregarContasReceber();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DGV_contareceber.DataSource = Controle.ContasReceber.FiltrarContasReceber(tb_filtro.Text);
        }

        private void bt_detalhes_Click(object sender, EventArgs e)
        {
            if (DGV_contareceber.SelectedRows.Count > 0)
            {
                int idContaReceber = Convert.ToInt32(DGV_contareceber.SelectedRows[0].Cells["ID Conta Receber"].Value);

                FormDetalhesContasReceber detalhesForm = new FormDetalhesContasReceber(idContaReceber);

                detalhesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma conta a receber para visualizar os detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormContasReceber_Load(object sender, EventArgs e)
        {

        }
    }
}
