using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Entidades
{
    public class DBConnection
    {
        // Método para obter a string de conexão
        public static string GetConnectionString()
        {
            return "Server=F2D2;Database=sgfBD;User Id=Fernando;Password=281002;";
        }
    }
}
