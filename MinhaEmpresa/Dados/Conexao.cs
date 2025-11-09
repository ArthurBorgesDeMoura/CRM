using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MinhaEmpresa.Dados
{
    public class Conexao
    {
        private static readonly string connectionString = "Server=localhost;Database=EmpresaDB;User ID=root;Password=";

        public static MySqlConnection GetConnectionString()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
