using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub
{
    class Cliente
    {
        private string nombre, apellido;
        private int id;

        public Cliente()
        {

        }
        public Cliente(string nombre, string apellido, int id)
        {
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

        public static void RegistrarCliente()
        {
            Console.WriteLine("Introduzca el nombre:");
            string Nombre = Console.ReadLine();
            Console.WriteLine("Introduzca apellidos:");
            string Apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca DNI:");
            string DNI = Console.ReadLine();
        }

    }

}
