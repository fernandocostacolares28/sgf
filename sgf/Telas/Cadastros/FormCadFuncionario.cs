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
    public partial class FormCadFuncionario : Form
    {
        public FormCadFuncionario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormCadFuncionario_Load(object sender, EventArgs e)
        {
            dgv_funcionario.DataSource = Funcionario.ListarFuncionario();

            dgv_funcionario.Columns["id_funcionario"].HeaderText = "ID";
            dgv_funcionario.Columns["name_funcionario"].HeaderText = "Nome";
            dgv_funcionario.Columns["cpf_funcionario"].HeaderText = "CPF";
            dgv_funcionario.Columns["telefone_funcionario"].HeaderText = "Telefone";
            dgv_funcionario.Columns["funcao_funcionario"].HeaderText = "Função";
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            string nome = tb_nome.Text;
            string cpf = tb_cpf.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;
            string funcao = cb_funcao.Text;

            var novoFuncionario = new Funcionario(nome, cpf, telefone, endereco, funcao);

            Funcionario.SalvarFuncionario(novoFuncionario);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();
            cb_funcao.Text = "";

            dgv_funcionario.DataSource = Funcionario.ListarFuncionario();

            dgv_funcionario.Columns["id_funcionario"].HeaderText = "ID";
            dgv_funcionario.Columns["name_funcionario"].HeaderText = "Nome";
            dgv_funcionario.Columns["cpf_funcionario"].HeaderText = "CPF";
            dgv_funcionario.Columns["telefone_funcionario"].HeaderText = "Telefone";
            dgv_funcionario.Columns["funcao_funcionario"].HeaderText = "Função";
        }

        private void dgv_funcionario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_funcionario.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgv_funcionario.SelectedRows[0];

                // Preenche os campos do formulário com os valores das células da linha selecionada
                tb_id.Text = selectedRow.Cells["id_funcionario"].Value.ToString();
                tb_nome.Text = selectedRow.Cells["name_funcionario"].Value.ToString();
                tb_cpf.Text = selectedRow.Cells["cpf_funcionario"].Value.ToString();
                tb_telefone.Text = selectedRow.Cells["telefone_funcionario"].Value.ToString();
                tb_endereco.Text = selectedRow.Cells["endereco_funcionario"].Value.ToString();
                cb_funcao.Text = selectedRow.Cells["funcao_funcionario"].Value.ToString();
            }
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            string nome = tb_nome.Text;
            string cpf = tb_cpf.Text;
            string telefone = tb_telefone.Text;
            string endereco = tb_endereco.Text;
            string funcao = cb_funcao.Text;

            Funcionario.EditarFuncionario(id, nome, cpf, telefone, endereco, funcao);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();
            cb_funcao.Text = "";

            dgv_funcionario.DataSource = Funcionario.ListarFuncionario();

            dgv_funcionario.Columns["id_funcionario"].HeaderText = "ID";
            dgv_funcionario.Columns["name_funcionario"].HeaderText = "Nome";
            dgv_funcionario.Columns["cpf_funcionario"].HeaderText = "CPF";
            dgv_funcionario.Columns["telefone_funcionario"].HeaderText = "Telefone";
            dgv_funcionario.Columns["funcao_funcionario"].HeaderText = "Função";
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);

            Funcionario.ExcluirFuncionario(id);

            tb_id.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            tb_telefone.Clear();
            tb_endereco.Clear();
            cb_funcao.Text = "";

            dgv_funcionario.DataSource = Funcionario.ListarFuncionario();

            dgv_funcionario.Columns["id_funcionario"].HeaderText = "ID";
            dgv_funcionario.Columns["name_funcionario"].HeaderText = "Nome";
            dgv_funcionario.Columns["cpf_funcionario"].HeaderText = "CPF";
            dgv_funcionario.Columns["telefone_funcionario"].HeaderText = "Telefone";
            dgv_funcionario.Columns["funcao_funcionario"].HeaderText = "Função";
        }
    }
}

