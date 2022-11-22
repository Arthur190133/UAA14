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
                string nom = null;      
                int cash = 0;

                GeneratedPersonne(out cash, out nom);
                Personne1 = new Personne(nom, cash);

                GeneratedPersonne(out cash, out nom);
                Personne2 = new Personne(nom, cash);

                DonnerArgent(Personne1, Personne2);
                DonnerArgent(Personne2, Personne1);

                Personne1.Cash += AjouterArgent(Personne1);
                Personne1.Afficher();

                Personne2.Cash += AjouterArgent(Personne2);
                Personne2.Afficher();

                Console.WriteLine("Tapez sur espace pour recommencer avec deux autres personnes");
                Console.ReadLine();


            } while (0 == 0);
        }

        private static int AjouterArgent(Personne personne)
        {
            Console.WriteLine("voulez vous ajouter de l'argent à " + personne.Nom + "Taper sur espace pour oui");
            string value = Console.ReadLine();

            if (value == " ")
            {
                Console.WriteLine("combien voulez vous ajouter ?");
                string Cash;
                int CashValue;
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    Cash = Console.ReadLine();
                } while (!int.TryParse(Cash, out CashValue));

                return CashValue;
            }

            return 0;
        }

        private static void GeneratedPersonne(out int cash , out string nom)
        {
            Console.WriteLine("Premiere personne, quel est votre nom ?");
            nom = Console.ReadLine();


            cash = 0;
            string Cash;
            do
            {
                Console.WriteLine("Tapez une somme d'argent en euros");
                Cash = Console.ReadLine();
            } while (!int.TryParse(Cash, out cash));
        }

        private static void DonnerArgent(Personne Personne1, Personne Personne2)
        {
            int euros;
            string value;

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
        }
    }
}
