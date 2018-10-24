using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace VideoClub
{
    class Pelicula
    {
        String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection conexion;
        string cadena;
        SqlCommand comando;

        private string nombre, descripcion;
        private int duracion, año, edadRecomendada;

        public Pelicula()
        {
            conexion = new SqlConnection(connectionString);

        }
        public Pelicula(string nombre, int duracion, string descripcion, int año, int edadRecomendada)
        {
            conexion = new SqlConnection(connectionString);

            this.nombre = nombre;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.año = año;
            this.edadRecomendada = edadRecomendada;
        }

        public void MostrarPeliculas()
        {
            conexion.Open();
            cadena = "SELECT * FROM PELICULA";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["Nombre"].ToString());
                Console.WriteLine("***************************");
                Console.WriteLine("Duracion: " + registros["Duracion"].ToString());
                Console.WriteLine(" ");
                Console.WriteLine("Descripcion: " + registros["Descripcion"].ToString());
                Console.WriteLine(" ");
                Console.WriteLine("Año: " + registros["Año"].ToString());
                Console.WriteLine(" ");
                Console.WriteLine("Edad Recomendad: " + registros["Edad_recomendada"].ToString());
                Console.WriteLine("***************************");
                
            }
            conexion.Close();


        }
    }
}
