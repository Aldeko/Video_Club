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
            static String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            static SqlConnection conexion = new SqlConnection(connectionString);
            static string cadena;
            static SqlCommand comando;
        static void Main(string[] args)
        {
            

            int logChoice;

            Console.WriteLine("1.-Logging");
            Console.WriteLine("2.-Registrarse");
            Console.WriteLine("3.-Salir");
            logChoice = Int32.Parse(Console.ReadLine());

            Logging l1 = new Logging();
            Cliente c1 = new Cliente();
            Pelicula p1 = new Pelicula();
            //Alquiler a1 = new Alquiler();

            
            Console.ReadLine();

            bool exit = false;
            Cliente cliente = null;
            do
            {
                switch (logChoice)
                {
                    case 1:
                        Loguear();
                        
                        
                        exit = true;
                        break;

                    case 2:
                        RegistroCliente();
                        Console.ReadLine();
                        MenuPrincipal(cliente);
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
        public static void RegistroCliente()
        {
            Console.WriteLine("REGISTRARSE" + "\n*****************************");
            Console.WriteLine("Introduce tu nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu fecha de nacimiento (aaaa-mm-dd)");
            DateTime fechaNac = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Introduce tu email");
            string email = Console.ReadLine();
            Console.WriteLine("Introduce una contraseña");
            string contraseña = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, fechaNac, email, contraseña);
            cliente.RegistrarCliente(cliente);
        }
        public static void Loguear()
        {
            Console.WriteLine("Escribe email");
            string email = Console.ReadLine();
            Console.WriteLine("Escribe contraseña");
            string contraseña = Console.ReadLine();
            conexion.Open();
            cadena = "SELECT Fecha_nac, Nombre, idCliente FROM Cliente WHERE (Email='" + email + "') AND (Contraseña='" + contraseña + "')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            
            DateTime fecha;
            Cliente cliente=new Cliente();
            if (registros.Read())
            {
                Console.WriteLine("BIENVENIDO");
                Console.WriteLine("**************");

                string nombre = registros["Nombre"].ToString();
                fecha = Convert.ToDateTime(registros["Fecha_nac"].ToString());
                int idCliente = Convert.ToInt32(registros["idCliente"].ToString());
                cliente = new Cliente(nombre, fecha, email, contraseña, idCliente);
                MenuPrincipal(cliente);
            }
            registros.Close();
            conexion.Close();
            
        }
        public static void MenuPrincipal(Cliente cliente)
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
                Menu(menuChoice, cliente);
                Console.ReadLine();
            } while (menuChoice != 5);


        }

        public static void MostrarPeliculas(Cliente cliente)
        {

            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;
            conexion.Open();
            cadena = "SELECT * FROM PELICULA where edad_recomendada<=" + cliente.CheckAge(cliente);
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

                foreach (Pelicula x in listaPelicula)
                {
                    Console.WriteLine(" ID Pelicula: " + x.GetIdPelicula() + "   Nombre pelicula==>  " + nombre + "   " + disponibilidad);
                    
                }
                //else if (c.CheckAge(cliente) > 16 && c.CheckAge(cliente) < 16)
                //{

                //}
                //else if(c.CheckAge(cliente)>18)
                //{

                //}
            }
            conexion.Close();

        }

        public static void Menu(int Choice, Cliente cliente)
        {
            bool exit = false;
            do
            {
                switch (Choice)
                {
                    case 1:
                        MostrarPeliculas(cliente);
                        exit = true;
                        break;

                    case 2:
                        Alquiler a1 = new Alquiler();
                        a1.RentFilm(cliente);
                        exit = true;
                        break;
                    case 3:
                        MisAlquileres(cliente);
                        exit = true;
                        break;

                    case 4:
                        Alquiler a2 = new Alquiler();
                        a2.ReturnMovie();
                        exit = true;
                        break;

                    case 5:
                        Console.WriteLine("Eskerrikasko eta Edarto ibili");
                        exit = true;
                        break;

                }

            } while (exit == false);
        }

        public static void MisAlquileres(Cliente cliente)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;
            conexion.Open();
            cadena= "SELECT Fecha_alquiler, Fecha_devolucion, idCliente FROM ALQUILER WHERE idCliente=" + cliente.GetIdCliente() ;
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            
            while (registro.Read())
            {
                Console.WriteLine(registro["Fecha_alquiler"].ToString() + "\t" + registro["Fecha_devolucion"].ToString() + "\t" + registro["idCliente"].ToString());
            }
            conexion.Close();
            
        }
    }
}




