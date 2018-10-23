using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace VideoClub
{
    class Cliente
    {
        private string nombre, apellido;
        private int id;

        String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection conexion;
        string cadena;
        SqlCommand comando;

        public Cliente()
        {
            conexion = new SqlConnection(connectionString);

        }
        public Cliente(string nombre, string apellido, int id)
        {
            conexion = new SqlConnection(connectionString);

            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
        }
        
        //GET & SET

        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetApellido()
        {
            return apellido;
        }
        public void SetApellido(string apellido)
        {
            this.apellido = apellido;
        }
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public  void RegistrarCliente()
        {

            Console.WriteLine("REGISTRARSE" + "\n*****************************");
            Console.WriteLine("Introduce tu nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu fecha de nacimiento (aaaa-mm-dd)");
            string fechaNac = Console.ReadLine();
            Console.WriteLine("Introduce tu email");
            string email = Console.ReadLine();
            Console.WriteLine("Introduce una contraseña");
            string contraseña = Console.ReadLine();

            conexion.Open();
            cadena = "INSERT INTO CLIENTE (Nombre, Fecha_nac, Email, Contraseña ) VALUES  ('" + nombre + "','" + fechaNac + "','" + email + "','" + contraseña + "')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            conexion.Close();

           


        }

    }

}
