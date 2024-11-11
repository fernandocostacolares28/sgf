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
    public partial class FormCadCliente : Form
    {
        public FormCadCliente()
        {
            InitializeComponent();
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            string nome = tb_nome.Text;
            string cpf = tb_cpf.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;

            var novoCliente = new Cliente(nome, cpf, telefone, endereco);

            Cliente.SalvarCliente(novoCliente);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_cliente.DataSource = Cliente.ListarCliente();

            dgv_cliente.Columns["id_cliente"].HeaderText = "ID";
            dgv_cliente.Columns["name_cliente"].HeaderText = "Nome";
            dgv_cliente.Columns["cpf_cliente"].HeaderText = "CPF";
            dgv_cliente.Columns["telefone_cliente"].HeaderText = "Telefone";
            dgv_cliente.Columns["endereco_cliente"].HeaderText = "Endereço";
        }

        private void FormCadCliente_Load(object sender, EventArgs e)
        {
            dgv_cliente.DataSource = Cliente.ListarCliente();

            dgv_cliente.Columns["id_cliente"].HeaderText = "ID";
            dgv_cliente.Columns["name_cliente"].HeaderText = "Nome";
            dgv_cliente.Columns["cpf_cliente"].HeaderText = "CPF";
            dgv_cliente.Columns["telefone_cliente"].HeaderText = "Telefone";
            dgv_cliente.Columns["endereco_cliente"].HeaderText = "Endereço";
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            string nome = tb_nome.Text;
            string cpf = tb_cpf.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;

            Cliente.EditarCliente(id, nome, cpf, telefone, endereco);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_cliente.DataSource = Cliente.ListarCliente();

            dgv_cliente.Columns["id_cliente"].HeaderText = "ID";
            dgv_cliente.Columns["name_cliente"].HeaderText = "Nome";
            dgv_cliente.Columns["cpf_cliente"].HeaderText = "CPF";
            dgv_cliente.Columns["telefone_cliente"].HeaderText = "Telefone";
            dgv_cliente.Columns["endereco_cliente"].HeaderText = "Endereço";
        }

        private void dgv_cliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_cliente.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgv_cliente.SelectedRows[0];

                // Preenche os campos do formulário com os valores das células da linha selecionada
                tb_id.Text = selectedRow.Cells["id_cliente"].Value.ToString();
                tb_nome.Text = selectedRow.Cells["name_cliente"].Value.ToString();
                tb_cpf.Text = selectedRow.Cells["cpf_cliente"].Value.ToString();
                tb_telefone.Text = selectedRow.Cells["telefone_cliente"].Value.ToString();
                tb_endereco.Text = selectedRow.Cells["endereco_cliente"].Value.ToString();

            }
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);

            Cliente.ExcluirCliente(id);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();

            dgv_cliente.DataSource = Cliente.ListarCliente();

            dgv_cliente.Columns["id_cliente"].HeaderText = "ID";
            dgv_cliente.Columns["name_cliente"].HeaderText = "Nome";
            dgv_cliente.Columns["cpf_cliente"].HeaderText = "CPF";
            dgv_cliente.Columns["telefone_cliente"].HeaderText = "Telefone";
            dgv_cliente.Columns["endereco_cliente"].HeaderText = "Endereço";
        }

        private void tb_cpf_TextChanged(object sender, EventArgs e)
        {


            string cpf = tb_cpf.Text.Replace(".", "").Replace("-", "");


            if (cpf.Length > 11)
            {
                cpf = cpf.Substring(0, 11);
            }


            if (cpf.Length >= 3)
            {
                cpf = cpf.Insert(3, ".");
            }
            if (cpf.Length >= 7)
            {
                cpf = cpf.Insert(7, ".");
            }
            if (cpf.Length >= 11)
            {
                cpf = cpf.Insert(11, "-");
            }

            tb_cpf.Text = cpf;


            tb_cpf.SelectionStart = tb_cpf.Text.Length;
        }
    }
}
