using ACT6_Heritages.Animaux;
using System;

namespace ACT6_Heritages
{
    class Program
    {
        static void Main(string[] args)
        {
            Chien chien = new Chien("Damien", DateTime.Now, 0000, 30, true);
            Console.WriteLine(chien);
            Chat chat = new Chat("jean", DateTime.Now, 0001, 30, false);
            Console.WriteLine(chat);
            Lapin lapin = new Lapin("L", DateTime.Now, 0002, 20, false , 2);
            Console.WriteLine(lapin);

            Console.ReadLine();

        }
    }
}
