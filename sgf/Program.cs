using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgf.Telas;
using sgf.Telas.Login;

namespace sgf
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Entidades.DBConnection.TestarConexao();
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();

            
        }
    }
}
