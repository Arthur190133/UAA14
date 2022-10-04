using System;

namespace I1P622_Arthur
{
    class Program
    {
        static void Main(string[] args)
        {
            Feu[] feu = new Feu[2];
            feu[1] = new Feu("67", 0, false);
            feu[0] = new Feu("89", 0, false);

            lancerFeu(feu[0]);
            lancerFeu(feu[1]);

            Console.WriteLine("Etat des feux \n----------------- \n" + getEtatFeu(feu) + "\n\n\n");
            Console.WriteLine("Changement d'état \n----------------- \n");
            for (int i = 0; i < 4; i++)
            {
                changerEtatFeu(feu[0]);
                System.Threading.Thread.Sleep(100);
            }
            changerEtatFeu(feu[0]);
            Console.WriteLine(" \n\n\nfeu clignotant \n------------\n");
            

            for(int i = 0; i < 8; i++)
            {
                swtichEtatFeu(feu[1]);
                System.Threading.Thread.Sleep(500);
            }

            
            Console.ReadLine();
            
        }

        static void lancerFeu(Feu feu)
        {
            feu.switchFeuEtat();
            feu.changerCouleur(1);
        }

        static string getEtatFeu(Feu[] feu)
        {
            string etat = null;
            for(int i = 0; i < feu.Length; i++)
            {
                etat += "Le feu de signalisation " + feu[i].getFeuId() + " est " + feu[i].getFeuCouleur() + "\n";
            }
            return etat;
        }

        static void changerEtatFeu(Feu feu)
        {
            Random random = new Random();
            feu.changerCouleur(random.Next(0, 3));

            Console.WriteLine("Le feu de signalisation " + feu.getFeuId() + " est " + feu.getFeuCouleur());
        }

        static void swtichEtatFeu(Feu feu)
        {
            string etat = feu.switchFeuEtat();
            Console.WriteLine(feu.getFeuId() + " est " + etat);
        }
    }
}
