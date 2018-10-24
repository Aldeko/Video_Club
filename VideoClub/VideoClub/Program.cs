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

            int logChoice;

            //Console.WriteLine("1.-Logging");
            //Console.WriteLine("2.-Registrarse");
            //Console.WriteLine("3.-Salir");
            //logChoice = Int32.Parse(Console.ReadLine());

            Logging l1 = new Logging();
            Cliente c1 = new Cliente();
            Pelicula p1 = new Pelicula();

            p1.MostrarPeliculas();
            Console.ReadLine();


            //bool exit = false;
            //do
            //{
            //    switch (logChoice)
            //    {
            //        case 1:
            //            l1.Log();
            //            exit = true;
            //            break;

            //        case 2:
            //            c1.RegistrarCliente();
            //            exit = true;
            //            break;

            //        case 3:
            //            Console.WriteLine("Que tenga un buen día");
            //            exit = true;
            //            break;
            //    }

            //} while (exit == false);




            Console.ReadLine();

        }
    }
}
