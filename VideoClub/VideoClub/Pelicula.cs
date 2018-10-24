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

        private string nombre, descripcion, disponibilidad;
        private int duracion, año, edadRecomendada, idPelicula;

        public Pelicula()
        {
            conexion = new SqlConnection(connectionString);

        }
        public Pelicula(int idPelicula, string nombre, int duracion, string descripcion, int año, int edadRecomendada, string disponibilidad)
        {
            conexion = new SqlConnection(connectionString);

            this.nombre = nombre;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.año = año;
            this.edadRecomendada = edadRecomendada;
            this.disponibilidad = disponibilidad;
            this.idPelicula = idPelicula;
        }
        //GETTERS AND SETTERS
        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public int GetDuracion()
        {
            return duracion;
        }
        public void SetDuracion(int duracion)
        {
            this.duracion = duracion;
        }
        public string GetDescripcion()
        {
            return descripcion;
        }
        public void SetDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public int GetAño()
        {
            return año;
        }
        public void SetAño(int año)
        {
            this.año = año;
        }
        public int GetEdadRecomendada()
        {
            return edadRecomendada;
        }
        public void SetEdadRecomendada(int edadRecomendada)
        {
            this.edadRecomendada = edadRecomendada;
        }
        public string GetDisponibilidad()
        {
            return disponibilidad;
        }
        public void SetDisponibilidad(string disponibilidad)
        {
            this.disponibilidad = disponibilidad;
        }
        public int GetIdPelicula()
        {
            return idPelicula;
        }
        public void SetIdPelicula(int idPelicula)
        {
            this.idPelicula = idPelicula;
        }

        
    }
}
