using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RevisionEx2.Program;

namespace RevisionEx2
{
    struct Methodes
    {
        public double GetDouble(string phrase)
        {
            double valeur = 0;
            string valeurString;

            do
            {
                Console.WriteLine(phrase);
                valeurString = Console.ReadLine();
            } while (!double.TryParse(valeurString,out valeur));
            return valeur;
        }
        public void Changecolor()
        {
            ConsoleColor BackgroundColor = ConsoleColor.Black;
            ConsoleColor ForegroundColor = ConsoleColor.White;
            string BackgroundString;
            string ForegroundString;

            do
            {
                Console.WriteLine("Entrez la couleur de fond");
                BackgroundString = Console.ReadLine();
            } while (!Enum.TryParse(BackgroundString, out BackgroundColor));

            do
            {
                Console.WriteLine("Entrez la couleur de texte");
                ForegroundString = Console.ReadLine();
            } while (!Enum.TryParse(ForegroundString, out ForegroundColor));

            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }
    }
}
