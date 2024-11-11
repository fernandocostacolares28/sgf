﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    public class DBConnection
    {

        public static string GetConnectionString()
        {
            return "Server=127.0.0.1;Database=sgfdb;User Id=root;Password=root;";
            
        }

        public static bool TestarConexao()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    Console.WriteLine("Deu BOM");
                    return true; 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                return false; 
            }
            
        }


    }
}
