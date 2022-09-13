using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChienPOO
{
    class Program
    {
        static void Main(string[] args)
        {

            Chien[] chiens = new Chien[3];

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Entrer le nom du chien");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrer la race du chien");
                string race = Console.ReadLine();
                Console.WriteLine("Entrer l'age du chien");
                int age = int.Parse(Console.ReadLine());

                chiens[i] = new Chien(nom, race, age);
            }
            for(int i = 0; i < 3; i++)
            {
                chiens[i].AfficheCaracteristiques();
            }
            

            Console.ReadLine();
        }
    }
}
