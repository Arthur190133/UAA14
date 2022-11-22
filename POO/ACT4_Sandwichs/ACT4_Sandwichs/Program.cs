using System;

namespace ACT4_Sandwichs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans notre concepteur de sandiwch ! ");
            string value = "";
            do
            {
                SandwichMaker sandwich = new SandwichMaker();
                sandwich.composeSandwich();
                Console.WriteLine("Tapez sur espace pour générer un sandwich, n'importe quelle touhce pour quitter ! :::");
                value = Console.ReadLine();
            } while (value == " ");

            
        }
    }
}
