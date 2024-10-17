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
    public partial class FormRelatorioLote : Form
    {
        public FormRelatorioLote()
        {
            InitializeComponent();
            Controle.Lote.PreencherComboBoxLote(cb_lote);
            DataTable lotes = Controle.Lote.CarregarDadosLote();
            DGV_Lote.DataSource = lotes;
        }

        private void FormRelatorioLote_Load(object sender, EventArgs e)
        {

        }

        private void bt_gerar_Click(object sender, EventArgs e)
        {
            string lote = cb_lote.Text;
            Relatorio.RelatorioLote.GerarRelatorioLotePDF(lote);
        }
    }
}
