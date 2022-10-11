using System;

namespace ACT3_Elephants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Elephant[] Elephants = new Elephant[2];
            Elephants[0] = new Elephant("Zazou", 100);
            Elephants[1] = new Elephant("Titi", 120);

            Elephant[] LotElephants = new Elephant[7];
            LotElephants[0] = new Elephant("1", 100);
            LotElephants[1] = new Elephant("2", 80);
            LotElephants[2] = new Elephant("3", 30);
            LotElephants[3] = new Elephant("4", 180);
            LotElephants[4] = new Elephant("5", 900);
            LotElephants[5] = new Elephant("6", 30);
            LotElephants[6] = new Elephant("7", 1);

            Console.WriteLine("Choisissez \n 1 pour afficher les infos de zazou \n 2 pour titi \n 3 pour les echanger \n 4 pour vois le transfer d'un message de zazou à tit \n 5 pour reviser la notion de tableau et l'appliquer aux objets");
            string choix = Console.ReadLine();

            ChoixElephant(choix, Elephants, LotElephants);
            Console.ReadLine();
        }

        static Elephant GetBiggestEar(Elephant[] LotElephants)
        {
            uint BiggestEar = 0;
            int IndexElephant = 0;
            for(int i = 0; i < LotElephants.Length; i++)
            {
                if(BiggestEar < LotElephants[i].GetEar())
                {
                    BiggestEar = LotElephants[i].GetEar();
                    IndexElephant = i;
                }
            }

            return LotElephants[IndexElephant];
        }

        static void ChoixElephant(string choix, Elephant[] Elephants, Elephant[] LotElephants)
        {
            string phrase = "je suis ";
            switch (choix)
            {
                case "1":
                   phrase +=  Elephants[0].AfficherQuiJeSuis();
                    break;

                case "2":
                    phrase += Elephants[1].AfficherQuiJeSuis();
                    break;

                case "3":
                    Elephant cacheElephant = Elephants[0];
                    Elephants[0] = Elephants[1];
                    Elephants[1] = cacheElephant;
                    phrase += Elephants[0].AfficherQuiJeSuis();
                    phrase += "\n";
                    phrase += Elephants[1].AfficherQuiJeSuis();
                    break;

                case "4":
                    Elephants[1].EnvoieMessage("salut", Elephants[0]);
                    Elephants[0].EcouteMessage("salut", Elephants[1]);
                    phrase = null;
                    break;

                case "5":
                    phrase += GetBiggestEar(LotElephants).AfficherQuiJeSuis();
                    break;
            }

            Console.WriteLine(phrase);
        }
    }
}
