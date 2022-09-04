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
            string methode = "";
            string infos = "";

            // instanciation de la structure
            MethodesDuProjet Methodes = new MethodesDuProjet();

            double a = 0;
            double b = 0;
            double c = 0;
            bool ok = false;


            Console.WriteLine("Testez les polygones !");
            //On recommence tant que désiré
            do
            {
                //lecture des 3 côtés
                a = lireDouble(1);
                b = lireDouble(2);
                c = lireDouble(3);

                // ordonner les côtés => APPEL ORDONNECOTES
                Methodes.OrdonneCotes(ref a, ref b, ref c);
                infos = "";
                ok = false;
                methode = "";

                // série de test (voir consignes)
                if (Methodes.Triangle(a,b,c))
                {
                    // préparation et affichage du résultat du test 'triangle' avec la procédure 'Affiche'
                    methode = "triangle";
                    ok = true;
                    Methodes.Affiche(methode, ok, ref infos);

                    // vérification équilatéral
                    if (Methodes.Equi(a,b,c))
                    {
                        // préparation et affichage du résultat du test 'equilateral' avec la procédure 'Affiche'
                        methode = "equilateral";
                        ok = true;
                        infos += "\n";
                        Methodes.Affiche(methode, ok, ref infos);
                    }
                    else
                    {
                        // vérification triangle rectangle
                        if (Methodes.TriangleRectangle(a,b,c))
                        {
                            methode += " rectangle";
                            ok = true;
                            infos += "\n";
                            Methodes.Affiche(methode, ok, ref infos);
                        }
                        else
                        {
                            methode = "rectangle";
                            ok = false;
                            infos += "\n";
                            Methodes.Affiche(methode, ok, ref infos);
                        }

                        // vérification du cas isocèle et affichage dans le cas positif
                        bool IsIsocele = false;
                        Methodes.Isocele(a, b, c, ref IsIsocele);
                        if (IsIsocele)
                        {
                            infos += "\n";
                            methode = "isocele";
                            ok = true;
                            Methodes.Affiche(methode, ok, ref infos);
                        }
                    }
                }
                else // si ce n'est pas un triangle
                {
                    methode = "triangle";
                    ok = false;
                    Methodes.Affiche(methode, ok, ref infos);
                }
                Console.WriteLine(infos);
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
