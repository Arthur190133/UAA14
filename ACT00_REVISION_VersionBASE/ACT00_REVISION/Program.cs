using System;
using static ACT00_REVISION.MethodesDuProjet;

namespace ACT00_REVISION
{
    class Program
    {
        static void Main(string[] args)
        {
            // déclaration des variables.... COMPLETER AVEC CE QUI MANQUE

            string rep;
            string methode;
            string infos;

            double a = 0;
            double b = 0;
            double c = 0;
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            bool ok = false;
            // instanciation de la structure
            // ...... COMPLETER

            Console.WriteLine("Testez les polygones !");
            //On recommence tant que désiré
            do
            {
                Console.WriteLine("Entrez la valeur du coté 1");
                double.TryParse(Console.ReadLine(), out a);
                Console.WriteLine("Entrez la valeur du coté 2");
                double.TryParse(Console.ReadLine(), out b);
                Console.WriteLine("Entrez la valeur du coté 3");
                double.TryParse(Console.ReadLine(), out c);
                //lecture des 3 côtés
                // ...
                // ...
                // ...

                // ordonner les côtés => APPEL ORDONNECOTES
                MethodesDuProjet.OrdonneCotes(ref a,ref b,ref c);


                // ...
                // série de test (voir consignes)
                if (MethodesDuProjet.Triangle(a,b,c))
                {
                    // préparation et affichage du résultat du test 'triangle' avec la procédure 'Affiche'
                    MethodesDuProjet.Affiche("");
                    // ...
                    // ...

                    // vérification équilatéral
                    if (// on a un triangle équilatéral...)
                    {
                        // préparation et affichage du résultat du test 'equilateral' avec la procédure 'Affiche'
                        // ...
                        // ...
                    }
                    else
                    {
                        // vérification triangle rectangle
                        if (// on a un triangle équilatéral...)
                        {
                            // préparation et affichage du résultat positif du test 'rectangle' avec la procédure 'Affiche'
                            // ...
                            // ...
                        }
                        else
                        {
                            // préparation et affichage du résultat négatif du test 'rectangle' avec la procédure 'Affiche'
                            // ...
                            // ...
                        }
                        // vérification du cas isocèle et affichage dans le cas positif
                        //...
                        //...
                        //... A vous de voir en combien de lignes...
                    }
                }
                else // si ce n'est pas un triangle
                {
                    // préparation et affichage du résultat négataif du test 'triangle' avec la procédure 'Affiche'
                    // ...
                    // ...
                }
                // reprise ?
                Console.WriteLine("Voulez-vous tester un autre polygône ? (Tapez espace)");
                rep = Console.ReadLine();
            } while (rep == " ");
        }
        //Récupération d'une donnée fournie par l'utilisateur en 'double' : on suppose qu'il ne se trompe pas !
        static double lireDouble(int numeroCote)
        {
            double cote;
            Console.Write("Tapez la valeur du côté " + numeroCote + " : ");
            cote = double.Parse(Console.ReadLine());
            return cote;
        }
    }
}
