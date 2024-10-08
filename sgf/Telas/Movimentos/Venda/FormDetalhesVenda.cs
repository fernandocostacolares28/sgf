using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgf.Controle;

namespace sgf.Telas.Movimentos.Venda
{
    public partial class FormDetalhesVenda : Form
    {
        public FormDetalhesVenda(int idVenda)
        {
            InitializeComponent();
            CarregarVendaDetalhes(idVenda);
        }

        private void FormDetalhesVenda_Load(object sender, EventArgs e)
        {

        }

        private void CarregarVendaDetalhes(int idVenda)
        {
            var venda = sgf.Controle.Venda.CarregarDetalhesVenda(idVenda);

            if (venda != null)
            {
                tb_id.Text = venda.Id.ToString();
                tb_metodo.Text = venda.Metodopagamento_venda;
                tb_parcelas.Text = venda.Parcelas_venda.ToString();
                tb_receita.Text = venda.Receita_venda;
                tb_data.Text = venda.Data_venda.ToString("dd/MM/yyyy");
                tb_cliente.Text = venda.Cliente;
                tb_totalvenda.Text = venda.Total_venda.ToString();
                tb_desconto.Text = venda.Desconto_venda.ToString();
            }
            else
            {
                MessageBox.Show("Nenhuma venda encontrada com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DGV_carrinho.DataSource = sgf.Controle.ItemVenda.CarregarItensVenda(idVenda);
        }

        private void DGV_carrinho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
