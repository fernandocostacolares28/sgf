using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.AutenticacaoUser
{
    internal class Autenticacao
    {
        public string NomeUsuario { get; set; }
        public string NivelAcesso { get; set; }


        public static string AutenticarUsuario(string username, string password)
        {
            Autenticacao usuarioAutenticado = null;

            string connectionString = DBConnection.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name_usuario, lvl_usuario FROM usuario WHERE name_usuario = @username AND password_usuario = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioAutenticado = new Autenticacao
                            {
                                NomeUsuario = reader.GetString("name_usuario"),
                                NivelAcesso = reader.GetString("lvl_usuario")
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao autenticar: {ex.Message}");
                }
            }

            return usuarioAutenticado.NivelAcesso;
        }
    }
}
