using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace VideoClub
{
    class Program
    {
        static void Main(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;

            Logging l1 = new Logging();
            l1.LogMenu();
            
            Console.ReadLine();

        }
    }
}
