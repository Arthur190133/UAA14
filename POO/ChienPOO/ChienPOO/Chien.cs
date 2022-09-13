using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChienPOO
{
    class Chien
    {
        private string Nom;
        private string Race;
        private int Age;

        public Chien(string NomChien, string RaceChien, int AgeChien)
        {
            Nom = NomChien;
            Race = RaceChien;
            Age = AgeChien;
        }

        public void AfficheCaracteristiques()
        {
            string Affiche = "";

            Affiche += "Nom : " + Nom;
            Affiche += " - Age : " + Age;
            Affiche += " - Race : " + Race.ToString();

            Console.WriteLine(Affiche);
        }
    }
}
