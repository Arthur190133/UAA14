using System;

namespace ACT4
{
    class Program
    {
        static void Main(string[] args)
        {
            Cercle cercle = new Cercle(); 

            Console.WriteLine("Bienvenue dans ce programme sur le cercle");
            do
            {
                Console.WriteLine("Tapez un rayon pour votre cercle");
                cercle.Rayon = double.Parse(Console.ReadLine());
                cercle.Caracteristique();
                Console.WriteLine("Un autre cercle ? (Tapez sur espace)");
                Console.ReadLine();
            } while (0 == 0);

        }   
    }
}
