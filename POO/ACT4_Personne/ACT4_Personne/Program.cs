using System;

namespace ACT4_Personne
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne Personne1;
            Personne Personne2;

            Console.WriteLine("Bienvenue dans notre gestionnaire de porte monnaie !");

            do
            {
                Console.WriteLine("Premiere personne, quel est votre nom ?");
                string nom = Console.ReadLine();

                
                int cash = 0;
                string Cash;
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    Cash = Console.ReadLine();
                } while (!int.TryParse(Cash, out cash));

                Personne1 = new Personne(nom, cash);

                Console.WriteLine("deuxieme personne, quel est votre nom ?");
                nom = Console.ReadLine();

                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    Cash = Console.ReadLine();
                } while (!int.TryParse(Cash, out cash));

                Personne2 = new Personne(nom, cash);

                Console.WriteLine(Personne1.Nom + " combien voulez vous donner à " + Personne2.Nom);
                int euros;
                string value;
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    value = Console.ReadLine();
                } while (!int.TryParse(value, out euros));

                if(Personne1.ALaThune(euros))
                {
                    Personne1.Cash -= euros;
                    Personne2.Cash += euros;
                    Console.WriteLine("Ajout effectué !");
                }
                else
                {
                    Console.WriteLine(Personne1.Nom + " vous n'avez pas asser d'argent pour cettre transaction !");
                }

                Personne1.Afficher();
                Personne2.Afficher();




                Console.WriteLine(Personne2.Nom + " combien voulez vous donner à " + Personne1.Nom);
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    value = Console.ReadLine();
                } while (!int.TryParse(value, out euros));

                if (Personne2.ALaThune(euros))
                {
                    Personne2.Cash -= euros;
                    Personne1.Cash += euros;
                    Console.WriteLine("Ajout effectué !");
                }
                else
                {
                    Console.WriteLine(Personne2.Nom + " vous n'avez pas asser d'argent pour cettre transaction !");
                }

                Personne1.Afficher();
                Personne2.Afficher();

                Console.WriteLine("Tapez sur espace pour recommencer avec deux autres personnes");
                Console.ReadLine();


            } while (0 == 0);
        }
    }
}
