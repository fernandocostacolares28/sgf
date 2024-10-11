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
    public partial class FormRelatorioContasPagar : Form
    {
        public FormRelatorioContasPagar()
        {
            InitializeComponent();
            DataTable contas = Controle.ContasPagar.CarregarContasPagar();
            DGV_contaspagar.DataSource = contas;
        }

        private void FormRelatorioContasPagar_Load(object sender, EventArgs e)
        {

        }

        private void bt_gerar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtp_inicio.Value;
            DateTime fim = dtp_fim.Value;

            RelatorioContaPagar.GerarRelatorioContasPagarPDF(inicio, fim);
        }
    }
}
