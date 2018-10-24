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

            Console.WriteLine("1.-Logging");
            Console.WriteLine("2.-Registrarse");
            Console.WriteLine("3.-Salir");
            logChoice = Int32.Parse(Console.ReadLine());

            Logging l1 = new Logging();
            Cliente c1 = new Cliente();
            Pelicula p1 = new Pelicula();
            Alquiler a1 = new Alquiler();

            //p1.MostrarPeliculas();
            Console.ReadLine();

            bool exit = false;
            do
            {
                switch (logChoice)
                {
                    case 1:
                        l1.Log();
                        Console.ReadLine();
                        MenuPrincipal();
                        exit = true;
                        break;

                    case 2:
                        c1.RegistrarCliente();
                        Console.ReadLine();
                        MenuPrincipal();
                        exit = true;
                        break;

                    case 3:
                        Console.WriteLine("Que tenga un buen día");
                        exit = true;
                        break;
                }

            } while (exit == false);

            Console.ReadLine();

        }

        public static void MenuPrincipal()
        {
            int menuChoice = 0;
            do
            {
                Console.WriteLine("1.-Ver Peliculas");
                Console.WriteLine("2.-Alquiler Peliculas");
                Console.WriteLine("3.-Mis Alquileres");
                Console.WriteLine("4.-Devolver Pelicula");
                Console.WriteLine("5.-Log out");
                menuChoice = Int32.Parse(Console.ReadLine());
                Menu(menuChoice);
                Console.ReadLine();
            } while (menuChoice != 5);


        }

        public static void MostrarPeliculas()
        {


            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;
            conexion.Open();
            cadena = "SELECT * FROM PELICULA";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                int idPelicula = Int32.Parse(registros["IDpelicula"].ToString());
                string nombre = registros["Nombre"].ToString();
                int duracion = Int32.Parse(registros["Duracion"].ToString());
                string descripcion = registros["Descripcion"].ToString();
                int año = Int32.Parse(registros["Año"].ToString());
                int edadRecomendada = Int32.Parse(registros["Edad_recomendada"].ToString());
                string disponibilidad = registros["Disponibilidad"].ToString();

                //Crear objeto clase pelicula, y añadirlo a la lista

                Pelicula p = new Pelicula(idPelicula, nombre, duracion, descripcion, año, edadRecomendada, disponibilidad);
                List<Pelicula> listaPelicula = new List<Pelicula>();
                listaPelicula.Add(p);

                Console.WriteLine("ID: " + idPelicula + " ========> " + nombre);
            }
            conexion.Close();

        }

        public static void Menu(int Choice)
        {
            bool exit = false;
            do
            {
                switch (Choice)
                {
                    case 1:
                        MostrarPeliculas();
                        exit = true;
                        break;

                    //case 2:
                    //    Alquiler();
                    //    exit = true;
                    //    break;
                    //case 3:
                    //    check_in();
                    //    exit = true;
                    //    break;

                    //case 4:
                    //    check_out();
                    //    exit = true;
                    //    break;

                    case 5:
                        Console.WriteLine("Eskerrikasko eta Edarto ibili");
                        exit = true;
                        break;

                }

            } while (exit == false);
        }
    }
}




