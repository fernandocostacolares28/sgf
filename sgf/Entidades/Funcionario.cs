﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Funcao { get; set; }

        public Funcionario(int id, string nome, string cpf, string telefone, string endereco, string funcao)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
            Funcao = funcao;   
        }

        public Funcionario(string nome, string cpf, string telefone, string endereco, string funcao)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
            Funcao = funcao;
        }

        public static DataTable ListarFuncionario()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL
                string query = "SELECT * FROM Funcionario";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Cria um adaptador de dados MySQL
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // Preenche o DataTable com os dados da consulta
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static void SalvarFuncionario(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "INSERT INTO Funcionario (name_funcionario, cpf_funcionario, telefone_funcionario, endereco_funcionario, funcao_funcionario) VALUES (@Nome, @CPF, @Telefone, @Endereco, @Funcao)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command.Parameters.AddWithValue("@CPF", funcionario.CPF);
                command.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                command.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                command.Parameters.AddWithValue("@Funcao", funcionario.Funcao);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EditarFuncionario(int id, string nome, string cpf, string telefone, string endereco, string funcao)
        {

            // Cria uma conexão com o banco de dados
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                // Abre a conexão
                connection.Open();

                // Define a consulta SQL de atualização
                string query = "UPDATE Funcionario SET name_funcionario = @Nome, cpf_funcionario = @CPF, telefone_funcionario = @Telefone, endereco_funcionario = @Endereco, funcao_funcionario = @Funcao WHERE id_funcionario = @Id";

                // Cria um comando para executar a consulta
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Define os parâmetros da consulta
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@CPF", cpf);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Funcao", funcao);
                    command.Parameters.AddWithValue("@Id", id);


                    // Executa a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirFuncionario(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = "DELETE FROM Funcionario WHERE id_funcionario = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
