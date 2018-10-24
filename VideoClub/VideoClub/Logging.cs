using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace VideoClub
{
    class Logging
    {
        private int logChoice;

        String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection conexion; 
        string cadena;
        SqlCommand comando;

        public Logging()
        {
            conexion = new SqlConnection(connectionString);
        }
        public Logging(string nombre, string apellido, int id)
        {
            conexion = new SqlConnection(connectionString);
        }
        
        //Vamos a crear un logging para eso pedimos email y contraseña

        public Cliente Log()
        {
            Cliente cliente = null;
            Console.WriteLine("Escribe email");
            string email = Console.ReadLine();
            Console.WriteLine("Escribe contraseña");
            string contraseña = Console.ReadLine();

            conexion.Open();

            //Comparar datos introducidos con Base de Datos
            cadena = "SELECT Email, Contraseña FROM Cliente WHERE (Email='"+email+"') AND (Contraseña='"+ contraseña +"')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros= comando.ExecuteReader();

            if (registros.Read())
            {
                Console.WriteLine("BIENVENIDO");
                Console.WriteLine("**************");
                string nombre = registros["nombre"].ToString();
                cliente = new Cliente(nombre, , , );
            }

            conexion.Close();
            return cliente;
        }

        


    }
}

