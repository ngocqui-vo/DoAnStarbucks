using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks
{
    internal class Connect
    {
        private static string connectionString = "Server=Lenovo\\SQLEXPRESS03;Database=starbuck;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
