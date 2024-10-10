using MySql.Data.MySqlClient;
using sgf.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Controle
{
    internal class ContasPagar
    {
        public static void SalvarContasPagar(int idCompra, int parcelas, float totalCompra, float restante, DateTime dataparcela, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO ContaPagar (id_compra, parcela_compra, total_contapagar, restante_contapagar, dataparcela_contapagar, status_contapagar) " +
                    "VALUES (@compra, @parcela, @total, @restante, @data, @status)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@compra", idCompra);
                command.Parameters.AddWithValue("@parcela", parcelas);
                command.Parameters.AddWithValue("@total", totalCompra);
                command.Parameters.AddWithValue("@restante", restante);
                command.Parameters.AddWithValue("@data", dataparcela);
                command.Parameters.AddWithValue("@status", status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
