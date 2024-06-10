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

            tb_id.Clear();
            tb_nome.Clear();
            tb_valor.Clear();
            tb_qtd.Clear();
            tb_lote.Clear();

            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
        }

        private void FormCadProduto_Load(object sender, EventArgs e)
        {
            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
        }

        private void dgv_produto_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_produto.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgv_produto.SelectedRows[0];

                // Preenche os campos do formulário com os valores das células da linha selecionada
                tb_id.Text = selectedRow.Cells["id_produto"].Value.ToString();
                tb_nome.Text = selectedRow.Cells["name_produto"].Value.ToString();
                tb_valor.Text = selectedRow.Cells["valor_produto"].Value.ToString();
                tb_qtd.Text = selectedRow.Cells["qtd_produto"].Value.ToString();
                tb_lote.Text = selectedRow.Cells["lote_produto"].Value.ToString();
            }
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            string nomeProduto = tb_nome.Text;
            float valor = float.Parse(tb_valor.Text);
            int quantidade = int.Parse(tb_qtd.Text);
            string lote = tb_lote.Text;

            Produto.EditarProduto(id, nomeProduto, valor, quantidade, lote);

            tb_id.Clear();
            tb_nome.Clear();
            tb_valor.Clear();
            tb_qtd.Clear();
            tb_lote.Clear();

            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            
            Produto.ExcluirProduto(id);

            tb_id.Clear();
            tb_nome.Clear();
            tb_valor.Clear();
            tb_qtd.Clear();
            tb_lote.Clear();

            dgv_produto.DataSource = Produto.ListarProdutos();

            dgv_produto.Columns["id_produto"].HeaderText = "ID";
            dgv_produto.Columns["name_produto"].HeaderText = "Nome do Produto";
            dgv_produto.Columns["valor_produto"].HeaderText = "Valor";
            dgv_produto.Columns["qtd_produto"].HeaderText = "Quantidade";
            dgv_produto.Columns["lote_produto"].HeaderText = "Lote";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
