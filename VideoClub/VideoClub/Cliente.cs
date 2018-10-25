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
        private string nombre, email, contraseña;
        private int fechaNac;

        String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection conexion;
        string cadena;
        SqlCommand comando;

        public Cliente()
        {
            conexion = new SqlConnection(connectionString);

        }
        public Cliente(string nombre, int fechaNac, string email, string contraseña)
        {
            this.fechaNac = fechaNac;
            this.email = email;
            this.contraseña = contraseña;
            this.nombre = nombre;
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
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public int GetFechaNac()
        {
            return fechaNac;
        }
        public void SetFechaNac(int fechaNac)
        {
            this.fechaNac = fechaNac;
        }
        public string GetContraseña()
        {
            return contraseña;
        }
        public void SetContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }

        public  Cliente RegistrarCliente()
        {

            Console.WriteLine("REGISTRARSE" + "\n*****************************");
            Console.WriteLine("Introduce tu nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu fecha de nacimiento (aaaa-mm-dd)");
            fechaNac = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Introduce tu email");
            string email = Console.ReadLine();
            Console.WriteLine("Introduce una contraseña");
            string contraseña = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, fechaNac , email, contraseña);
            conexion.Open();
            cadena = "INSERT INTO CLIENTE (Nombre, Fecha_nac, Email, Contraseña ) VALUES  ('" + nombre + "','" + fechaNac + "','" + email + "','" + contraseña + "')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            conexion.Close();
            return cliente;
        }

        public void CheckAge(Cliente cliente)
        {
            
            DateTime dt1 = new DateTime(cliente.fechaNac);
            DateTime dt2 = new DateTime.
            TimeSpan ts = (dt2 - dt1);
            int dias = ts.Days;
            int years = dias / 365;
      
        }

    }

}
