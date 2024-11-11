using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Entidades
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente(string nome, string cpf, string telefone, string endereco)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
        }

        public static DataTable ListarCliente()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
               
                connection.Open();

                string query = "SELECT * FROM Cliente";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {

                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static void SalvarCliente(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                connection.Open();

                string queryVerificarCPF = "SELECT COUNT(*) FROM Cliente WHERE cpf_cliente = @CPF";
                MySqlCommand commandVerificar = new MySqlCommand(queryVerificarCPF, connection);
                commandVerificar.Parameters.AddWithValue("@CPF", cliente.CPF);

                int cpfExiste = Convert.ToInt32(commandVerificar.ExecuteScalar());

                if (cpfExiste > 0)
                {
                    MessageBox.Show("Já existe um cliente com esse CPF.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }


                string queryInserir = "INSERT INTO Cliente (name_cliente, cpf_cliente, telefone_cliente, endereco_cliente) VALUES (@Nome, @CPF, @Telefone, @Endereco)";
                MySqlCommand commandInserir = new MySqlCommand(queryInserir, connection);
                commandInserir.Parameters.AddWithValue("@Nome", cliente.Nome);
                commandInserir.Parameters.AddWithValue("@CPF", cliente.CPF);
                commandInserir.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                commandInserir.Parameters.AddWithValue("@Endereco", cliente.Endereco);

                commandInserir.ExecuteNonQuery();
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void EditarCliente(int id, string nome, string cpf, string telefone, string endereco)
        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {

                connection.Open();

                string query = "UPDATE Cliente SET name_cliente = @Nome, cpf_cliente = @CPF, telefone_cliente = @Telefone, endereco_cliente = @Endereco WHERE id_cliente = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@CPF", cpf);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Id", id);


                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirCliente(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Cliente WHERE id_cliente = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
