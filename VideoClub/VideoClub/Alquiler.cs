//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.Configuration;

//namespace VideoClub
//{
//    class Alquiler
//    {
//        private string idPelicula;

//        public void RentFilm()
//        {
//            String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
//            SqlConnection conexion = new SqlConnection(connectionString);
//            string cadena;
//            SqlCommand comando;

//            //BUSCAMOS EL ID DE LA PELICULA

//            Console.WriteLine("Introduzca el ID de la pelicula que quieres alquilar");
//            idPelicula = Console.ReadLine();

//            conexion.Open();

//            cadena = "SELECT * FROM Pelicula WHERE IDpelicula LIKE '" + idPelicula + "'";
//            comando = new SqlCommand(cadena, conexion);
//            SqlDataReader registros = comando.ExecuteReader();


//            if (registros.Read())
//            {

//                conexion.Close();
//                Console.WriteLine("Tu pelicula esta disponible");

//                //HACEMOS UNA CONSULTA A LA TABLA PELICULA
//                conexion.Open();
//                cadena = "SELECT * FROM Habitacion WHERE Estado like 'libre'";
//                comando = new SqlCommand(cadena, conexion);
//                SqlDataReader habitacion = comando.ExecuteReader();

//                while (habitacion.Read())
//                {
//                    Console.WriteLine(habitacion["CodHabitacion"].ToString() + "\t" + habitacion["Estado"].ToString());

//                }
//                habitacion.Close();
//                conexion.Close();


//                Console.WriteLine("Elija su habitación");

//                //CREAR EL CÓDIGO DE RESERVA
//                conexion.Open();
//                cadena = "SELECT max(CodReserva) FROM Reserva";
//                comando = new SqlCommand(cadena, conexion);
//                SqlDataReader codReservaR = comando.ExecuteReader();
//                int codReserva = Convert.ToInt32(codReservaR.Read()) + 1;
//                conexion.Close();
//                int codHabitacion = Convert.ToInt32(Console.ReadLine());

//                conexion.Open();
//                cadena = "UPDATE Habitacion SET Estado = 'ocupado' WHERE CodHabitacion like'" + codHabitacion + "'";
//                comando = new SqlCommand(cadena, conexion);
//                comando.ExecuteNonQuery();
//                conexion.Close();

//                conexion.Open();
//                cadena = "INSERT INTO Reserva (CodReserva, CodHabitacion, DNI, Check_in ) VALUES ('" + codReserva + "','" + codHabitacion + "','" + dni + "','" + DateTime.Now + "') ";
//                comando = new SqlCommand(cadena, conexion);
//                comando.ExecuteNonQuery();

//                conexion.Close();
//                Console.WriteLine("Su habitación ha sido reservada");

//            }
//            else
//            {
//                Console.WriteLine("El cliente no está registrado, no se puede realizar la reserva");
//            }

//            conexion.Close();
//            return;
//        }
//    }
//}
