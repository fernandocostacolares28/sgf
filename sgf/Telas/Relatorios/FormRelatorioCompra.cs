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
    public partial class FormRelatorioCompra : Form
    {
        public FormRelatorioCompra()
        {
            InitializeComponent();
            DataTable compras = Controle.Compra.CarregarCompras();
            DGV_Compra.DataSource = compras;
        }

        private void bt_gerar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtp_inicio.Value;
            DateTime fim = dtp_fim.Value;

            RelatorioCompra.GerarRelatorioComprasPDF(inicio, fim);
        }

        private void DGV_Compra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtp_fim_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_inicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
