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

namespace sgf.Telas.Cadastros
{
    public partial class FormCadProduto : Form
    {
        public FormCadProduto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            string nomeProduto = tb_nome.Text;
            float valor = float.Parse(tb_valor.Text);
            int quantidade = int.Parse(tb_qtd.Text);
            string lote = tb_lote.Text;

            var novoProduto = new Produto(nomeProduto, valor, quantidade, lote);

            Produto.SalvarProduto(novoProduto);

            tb_nome.Clear();
            tb_valor.Clear();
            tb_qtd.Clear();
            tb_lote.Clear();

        }
    }
}
