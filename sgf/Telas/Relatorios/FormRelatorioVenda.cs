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
    public partial class FormRelatorioVenda : Form
    {
        public FormRelatorioVenda()
        {
            InitializeComponent();
            DataTable vendas = Controle.Venda.CarregarVendas();
            DGV_Venda.DataSource = vendas;
        }

        private void FormRelatorioVenda_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtp_inicio.Value;
            DateTime fim = dtp_fim.Value;

            RelatorioVenda.GerarRelatorioVendasPDF(inicio, fim);

        }
    }
}
