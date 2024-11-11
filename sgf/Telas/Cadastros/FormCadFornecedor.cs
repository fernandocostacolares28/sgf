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
    public partial class FormCadFornecedor : Form
    {
        public FormCadFornecedor()
        {
            InitializeComponent();
        }

        private void FormCadFornecedor_Load(object sender, EventArgs e)
        {
            dgv_fornecedor.DataSource = Fornecedor.ListarFornecedor();

            dgv_fornecedor.Columns["id_fornecedor"].HeaderText = "ID";
            dgv_fornecedor.Columns["razaosocial_fornecedor"].HeaderText = "Razão Social";
            dgv_fornecedor.Columns["cnpj_fornecedor"].HeaderText = "CNPJ";
            dgv_fornecedor.Columns["telefone_fornecedor"].HeaderText = "Telefone";
            dgv_fornecedor.Columns["endereco_fornecedor"].HeaderText = "Endereço";
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            string razaosocial = tb_razaosocial.Text;
            string cnpj = tb_cnpj.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;

            var novoFornecedor = new Fornecedor(razaosocial, cnpj, telefone, endereco);

            Fornecedor.SalvarFornecedor(novoFornecedor);

            tb_id.Clear();
            tb_razaosocial.Clear();
            tb_cnpj.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_fornecedor.DataSource = Fornecedor.ListarFornecedor();

            dgv_fornecedor.Columns["id_fornecedor"].HeaderText = "ID";
            dgv_fornecedor.Columns["razaosocial_fornecedor"].HeaderText = "Razão Social";
            dgv_fornecedor.Columns["cnpj_fornecedor"].HeaderText = "CNPJ";
            dgv_fornecedor.Columns["telefone_fornecedor"].HeaderText = "Telefone";
            dgv_fornecedor.Columns["endereco_fornecedor"].HeaderText = "Endereço";

        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            string razaosocial = tb_razaosocial.Text;
            string cnpj = tb_cnpj.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;

            Fornecedor.EditarFornecedor(id, razaosocial, cnpj, telefone, endereco);

            tb_id.Clear();
            tb_razaosocial.Clear();
            tb_cnpj.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_fornecedor.DataSource = Fornecedor.ListarFornecedor();

            dgv_fornecedor.Columns["id_fornecedor"].HeaderText = "ID";
            dgv_fornecedor.Columns["razaosocial_fornecedor"].HeaderText = "Razão Social";
            dgv_fornecedor.Columns["cnpj_fornecedor"].HeaderText = "CNPJ";
            dgv_fornecedor.Columns["telefone_fornecedor"].HeaderText = "Telefone";
            dgv_fornecedor.Columns["endereco_fornecedor"].HeaderText = "Endereço";
        }

        private void dgv_fornecedor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_fornecedor.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgv_fornecedor.SelectedRows[0];

                // Preenche os campos do formulário com os valores das células da linha selecionada
                tb_id.Text = selectedRow.Cells["id_fornecedor"].Value.ToString();
                tb_razaosocial.Text = selectedRow.Cells["razaosocial_fornecedor"].Value.ToString();
                tb_cnpj.Text = selectedRow.Cells["cnpj_fornecedor"].Value.ToString();
                tb_telefone.Text = selectedRow.Cells["telefone_fornecedor"].Value.ToString();
                tb_endereco.Text = selectedRow.Cells["endereco_fornecedor"].Value.ToString();

            }
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);

            Fornecedor.ExcluirFornecedor(id);

            tb_id.Clear();
            tb_razaosocial.Clear();
            tb_cnpj.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_fornecedor.DataSource = Fornecedor.ListarFornecedor();

            dgv_fornecedor.Columns["id_fornecedor"].HeaderText = "ID";
            dgv_fornecedor.Columns["razaosocial_fornecedor"].HeaderText = "Razão Social";
            dgv_fornecedor.Columns["cnpj_fornecedor"].HeaderText = "CNPJ";
            dgv_fornecedor.Columns["telefone_fornecedor"].HeaderText = "Telefone";
            dgv_fornecedor.Columns["endereco_fornecedor"].HeaderText = "Endereço";
        }
    }
}
