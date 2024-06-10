using MySql.Data.MySqlClient;
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
    public partial class FormCadUsuario : Form
    {
        public FormCadUsuario()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormCadUsuario_Load(object sender, EventArgs e)
        {
            List<string> funcionarios = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "SELECT name_funcionario FROM funcionario";

                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomeFuncionario = reader.GetString("name_funcionario");
                            funcionarios.Add(nomeFuncionario);
                        }
                    }
                }

            }

            lb_usuario.Items.AddRange(funcionarios.ToArray());

            dgv_usuario.DataSource = Usuario.ListarUsuario();

            dgv_usuario.Columns["id_usuario"].HeaderText = "ID";
            dgv_usuario.Columns["name_usuario"].HeaderText = "User";
            dgv_usuario.Columns["password_usuario"].HeaderText = "Password";
            dgv_usuario.Columns["lvl_usuario"].HeaderText = "Level";
            dgv_usuario.Columns["name_funcionario"].HeaderText = "Funcionario";

        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            string user = tb_nome.Text;
            string password = tb_senha.Text;
            string lvl = cb_lvl.Text;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT id_funcionario FROM funcionario WHERE name_funcionario = @funcionarionome";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@funcionarionome", tb_funcionario.Text);


                connection.Open();
                object result = command.ExecuteScalar();

                int funcionario = Convert.ToInt32(result);

                var novoUsuario = new Usuario(user, password, lvl, funcionario);

                Usuario.SalvarUsuario(novoUsuario);
            }

            tb_id.Clear();
            tb_nome.Clear();
            tb_senha.Clear();
            cb_lvl.Text = "";
            tb_funcionario.Clear();

            dgv_usuario.DataSource = Usuario.ListarUsuario();

            dgv_usuario.Columns["id_usuario"].HeaderText = "ID";
            dgv_usuario.Columns["name_usuario"].HeaderText = "User";
            dgv_usuario.Columns["password_usuario"].HeaderText = "Password";
            dgv_usuario.Columns["lvl_usuario"].HeaderText = "Level";
            dgv_usuario.Columns["name_funcionario"].HeaderText = "Funcionario";

        }

        private void lb_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado no ListBox
            if (lb_usuario.SelectedIndex != -1)
            {
                // Obtém o texto do item selecionado no ListBox e atribui ao TextBox
                tb_funcionario.Text = lb_usuario.SelectedItem.ToString();
            }
            else
            {
                // Limpa o TextBox se nenhum item estiver selecionado
                tb_funcionario.Text = "";
            }
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);

            Funcionario.ExcluirFuncionario(id);

            tb_id.Clear();
            tb_nome.Clear();
            tb_senha.Clear();
            cb_lvl.Text = "";
            tb_funcionario.Clear();

            dgv_usuario.DataSource = Usuario.ListarUsuario();

            dgv_usuario.Columns["id_usuario"].HeaderText = "ID";
            dgv_usuario.Columns["name_usuario"].HeaderText = "User";
            dgv_usuario.Columns["password_usuario"].HeaderText = "Password";
            dgv_usuario.Columns["lvl_usuario"].HeaderText = "Level";
            dgv_usuario.Columns["name_funcionario"].HeaderText = "Funcionario";

        }

        private void dgv_usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_usuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_usuario.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgv_usuario.SelectedRows[0];

                // Preenche os campos do formulário com os valores das células da linha selecionada
                tb_id.Text = selectedRow.Cells["id_usuario"].Value.ToString();
                tb_nome.Text = selectedRow.Cells["name_usuario"].Value.ToString();
                tb_senha.Text = selectedRow.Cells["password_usuario"].Value.ToString();
                cb_lvl.Text = selectedRow.Cells["lvl_usuario"].Value.ToString();
                tb_funcionario.Text = selectedRow.Cells["name_funcionario"].Value.ToString();
 
            }
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_id.Text);
            string user = tb_nome.Text;
            string password = tb_senha.Text;
            string lvl = cb_lvl.Text;

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                string query = "SELECT id_funcionario FROM funcionario WHERE name_funcionario = @funcionarionome";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@funcionarionome", tb_funcionario.Text);


                connection.Open();
                object result = command.ExecuteScalar();

                int funcionario = Convert.ToInt32(result);

                

                Usuario.EditarUsuario(id, user, password, lvl, funcionario);
            }

            tb_id.Clear();
            tb_nome.Clear();
            tb_senha.Clear();
            cb_lvl.Text = "";
            tb_funcionario.Clear();

            dgv_usuario.DataSource = Usuario.ListarUsuario();

            dgv_usuario.Columns["id_usuario"].HeaderText = "ID";
            dgv_usuario.Columns["name_usuario"].HeaderText = "User";
            dgv_usuario.Columns["password_usuario"].HeaderText = "Password";
            dgv_usuario.Columns["lvl_usuario"].HeaderText = "Level";
            dgv_usuario.Columns["name_funcionario"].HeaderText = "Funcionario";
        }
    }
}
