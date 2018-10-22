using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;
            do
            {
                Console.WriteLine("HOTEL BOUTIQUE");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. salir");
                Console.WriteLine("4. Check-out");
                Console.WriteLine("5. Exit");

                menuChoice = Convert.ToInt32(Console.ReadLine());
                Menu(menuChoice);

            } while (menuChoice != 3);
        }
    }
}
