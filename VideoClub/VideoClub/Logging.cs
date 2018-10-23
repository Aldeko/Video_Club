using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub
{
    class Logging
    {
        private int logChoice;

        public Logging()
        {

        }
        public Logging(string nombre, string apellido, int id)
        {

        }
        public void LogMenu()
        {
            Console.WriteLine("1.-Logging");
            Console.WriteLine("2.-Registrarse");
            Console.WriteLine("3.-Salir");
            logChoice = Int32.Parse(Console.ReadLine());

            bool exit = false;
            do
            {
                switch (logChoice)
                {
                    case 1:
                        Log();
                        exit = true;
                        break;

                    case 2:
                        Resgister();
                        exit = true;
                        break;

                    case 3:
                        Console.WriteLine("Que tenga un buen día");
                        exit = true;
                        break;
                }

            } while (exit == false);
        }

        private bool Log(string user, string password)
        {
            Console.WriteLine("Escribe usuario");
            user = Console.ReadLine();
            Console.WriteLine("Escribe contraseña");
            password = Console.ReadLine();

        }
    }
}

