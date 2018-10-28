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
        private DateTime fechaNac;
        private DateTime fechaNacimiento;
        int idCliente;
        String connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection conexion;
        string cadena;
        SqlCommand comando;

        public Cliente()
        {
            conexion = new SqlConnection(connectionString);

        }
        public Cliente(string nombre, DateTime fechaNac, string email, string contraseña, int idCliente)
        {
            this.fechaNac = fechaNac;
            this.email = email;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.idCliente = idCliente;
            
            conexion = new SqlConnection(connectionString);
        }
        public Cliente(string nombre, DateTime fechaNac, string email, string contraseña)
        {
            this.fechaNac = fechaNac;
            this.email = email;
            this.contraseña = contraseña;
            this.nombre = nombre;
            

            conexion = new SqlConnection(connectionString);
        }
        //constructor  loggin
        public Cliente(string email, string contraseña, DateTime fechaNacimiento)
        {
            this.email = email;
            this.contraseña = contraseña;
            this.fechaNacimiento = fechaNacimiento;
            this.idCliente = idCliente;
            
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
        public DateTime GetFechaNac()
        {
            return fechaNac;
        }
        public void SetFechaNac(DateTime fechaNac)
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
        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }
        public int GetIdCliente()
        {
            return idCliente;
        }
        public void SetIdCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }
        public  Cliente RegistrarCliente(Cliente c)
        {           
            conexion.Open();
            cadena = "INSERT INTO CLIENTE (Nombre, Fecha_nac, Email, Contraseña ) VALUES  ('" + nombre + "','" + fechaNac + "','" + email + "','" + contraseña + "')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            conexion.Close();
            return c;
        }
        public Cliente Log()
        {
            Cliente cliente = null;
            Console.WriteLine("Escribe email");
            string email = Console.ReadLine();
            Console.WriteLine("Escribe contraseña");
            string contraseña = Console.ReadLine();
            

            conexion.Open();

            //Comparar datos introducidos con Base de Datos
            cadena = "SELECT Email, Contraseña FROM Cliente WHERE (Email='" + email + "') AND (Contraseña='" + contraseña + "')";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if (registros.Read())
            {
                Console.WriteLine("BIENVENIDO");
                Console.WriteLine("**************");
                string nombre = registros["nombre"].ToString();
                int idCliente = Convert.ToInt32(registros["idCliente"].ToString());
                cliente = new Cliente(nombre, fechaNac, email, contraseña, idCliente);
            }

            conexion.Close();
            return cliente;
        }
        public int CheckAge(Cliente cliente)
        {

            DateTime dt1 = cliente.GetFechaNacimiento();
            DateTime dt2 = new DateTime();
            dt2 = DateTime.Now;
            TimeSpan ts = (dt2 - dt1);
            int dias = ts.Days;
            int years = dias / 365;
            
            return years;
        }

    }

}
