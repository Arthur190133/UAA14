using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RevisionEx2.Methodes;

namespace RevisionEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] Tableau = new double[10];
            Methodes Methodes;
            string phrase = "";
            double total = 0;

            for(int i = 0; i < 10; i++)
            {
                phrase = "Entrez le nombre : " + (i +1)
                    ;
                Tableau[i] = Methodes.GetDouble(phrase);
            }

            total = Tableau.Average();

            Methodes.Changecolor();

            Console.WriteLine("Voici la moyenne des nombres " + total);
            Console.ReadLine();

        }
    }
}
