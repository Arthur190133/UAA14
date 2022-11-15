using System;

namespace ACT4_nombre_complexe
{
    class Program
    {
        static void Main(string[] args)
        {
            Complexe nbrComplexe = new Complexe();
            Complexe newNbrComplexe = new Complexe();

            Console.WriteLine("Bienvenue dans ce programme sur les complexes !");

            do
            {
                Console.WriteLine("Que vaut la partie réelle du complexe de départ ?");
                nbrComplexe.Reelle = int.Parse(Console.ReadLine());

                Console.WriteLine("Que vaut la partie imaginaire du complexe de départ ?");
                nbrComplexe.Imaginaire = int.Parse(Console.ReadLine());

                Console.WriteLine("Le premier complexe : ");
                nbrComplexe.AfficheComplexe();

                Console.WriteLine(" et a pour module : " + nbrComplexe.CalculeModule());


                
                Console.WriteLine("Encodez un second nombre imaginaire : ");

                Console.WriteLine("Que vaut la partie réelle du second complexe ?");
                newNbrComplexe.Reelle = int.Parse(Console.ReadLine());

                Console.WriteLine("Que vaut la partie imaginaire du second complexe ?");
                newNbrComplexe.Imaginaire = int.Parse(Console.ReadLine());


                Console.WriteLine("Le second module est :");
                newNbrComplexe.AfficheComplexe();


                nbrComplexe.Ajoute(newNbrComplexe.Reelle, newNbrComplexe.Imaginaire);
                Console.WriteLine("Le premier complexe devient :");
                nbrComplexe.AfficheComplexe();

                Console.WriteLine("Un autr test ? (Tapez sur espace)");


            } while (0 == 0);
        }
    }
}
