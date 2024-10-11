using sgf.Relatorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Relatorios
{
    public partial class FormRelatorioContasReceber : Form
    {
        public FormRelatorioContasReceber()
        {
            InitializeComponent();
            DataTable contareceber = Controle.ContasReceber.CarregarContasReceber();
            DGV_contareceber.DataSource = contareceber;
        }

        private void bt_gerar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtp_inicio.Value;
            DateTime fim = dtp_fim.Value;

            RelatorioContaReceber.GerarRelatorioContasReceberPDF(inicio, fim);

        }

        private void FormRelatorioContasReceber_Load(object sender, EventArgs e)
        {

        }
    }
}
