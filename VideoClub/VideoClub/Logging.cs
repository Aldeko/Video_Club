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
        public void LogMenu()
        {
            Console.WriteLine("1.-Logging");
            Console.WriteLine("2.-Registrarse");
            Console.WriteLine("3.-Salir");
            logChoice = Int32.Parse(Console.ReadLine());

            bool exit = false;
            do
            {
                switch (logChoice)
                {
                    case 1:
                        Log();
                        exit = true;
                        break;

                    case 2:
                        //Register();
                        exit = true;
                        break;

                    case 3:
                        Console.WriteLine("Que tenga un buen día");
                        exit = true;
                        break;
                }

            } while (exit == false);
        }
        //Vamos a crear un logging para eso pedimos email y contraseña

        private void Log()
        {
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
                Console.WriteLine("El usuario existe");
            }
            
            conexion.Close();
            Console.ReadLine();

        }
    }
}

