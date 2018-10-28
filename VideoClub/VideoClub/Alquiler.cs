using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace VideoClub
{
    class Alquiler
    {
        private string idPelicula;
        private DateTime fechaAlquiler, fechaDevolucion;

        
        public DateTime GetFechaAlquiler()
        {
            return fechaAlquiler;
        }
        public DateTime GetFechaDevolucion()
        {
            return fechaDevolucion;
        }

        public void RentFilm(Cliente cliente)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;

            //BUSCAMOS EL ID DE LA PELICULA

            Console.WriteLine("Introduzca el ID de la pelicula que quieres alquilar");
            idPelicula = Console.ReadLine();

            conexion.Open();

            cadena = "SELECT * FROM Pelicula WHERE IDpelicula LIKE '" + idPelicula + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();


            if (registros.Read())
            {

                conexion.Close();
                

                //HACEMOS UNA CONSULTA A LA TABLA PELICULA
                conexion.Open();
                cadena = "SELECT * FROM PELICULA WHERE Disponibilidad like 'LIBRE'";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader pelicula = comando.ExecuteReader();

                while (pelicula.Read())
                {
                    Console.WriteLine(pelicula["IDpelicula"].ToString() + "\t" + pelicula["Disponibilidad"].ToString());

                }
                pelicula.Close();
                conexion.Close();


                

                //CAMBIAR DISPONIBILIDAD

                conexion.Open();
                cadena = "UPDATE PELICULA SET Disponibilidad = 'OCUPADO' WHERE IDpelicula like'" + idPelicula + "'";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                conexion.Open();
               
                cadena = "INSERT INTO ALQUILER (IDpelicula, Fecha_alquiler, IDcliente ) VALUES ('" + idPelicula + "','" + DateTime.Now + "','" + cliente.GetIdCliente() +"') ";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
                Console.WriteLine("Su Pelicula ha sido alquilada");

            }
            else
            {
                Console.WriteLine("Esa pelicula no existe");
            }

            conexion.Close();
            return;
        }

        public void ReturnMovie()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;

            Console.WriteLine("Introduzca el ID de la pelicula que quieres Devolver");
            idPelicula = Console.ReadLine();

            conexion.Open();

            cadena = "SELECT * FROM ALQUILER WHERE IDpelicula LIKE '" + idPelicula + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {

                conexion.Close();
                conexion.Open();
                cadena = "UPDATE ALQUILER SET Fecha_devolucion= GETDATE() WHERE IDpelicula like'" + idPelicula + "'"; ;
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                conexion.Open();
                cadena = "UPDATE PELICULA SET Disponibilidad = 'LIBRE' WHERE IDpelicula like'" + idPelicula + "'";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                

            }
        }
    }
}
