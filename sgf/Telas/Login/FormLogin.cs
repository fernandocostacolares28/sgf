using sgf.AutenticacaoUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            string username = tb_user.Text;
            string password = tb_senha.Text;

            string usuario = AutenticacaoUser.Autenticacao.AutenticarUsuario(username, password);

            if (usuario != null)
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 formPrincipal = new Form1(usuario);
                formPrincipal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
