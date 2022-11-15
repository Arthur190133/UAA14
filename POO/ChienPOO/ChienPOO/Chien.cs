using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChienPOO
{
    class Chien
    {
        private string _nom;
        private string _race;
        private int _age;


        public int Age
        {
            get
            {
                return _age;
            }
        }

        public string Race
        {
            get { return _race; }
        }

        public string Nom
        {
            get { return _nom; }
        }

        public Chien(string NomChien, string RaceChien, int AgeChien)
        {
            _nom = NomChien;
            _race = RaceChien;
            _age = AgeChien;
        }

        public void AfficheCaracteristiques()
        {
            string Affiche = "";

            Affiche += "Nom : " + _nom;
            Affiche += " - Age : " + Age;
            Affiche += " - Race : " + _race.ToString();

            Console.WriteLine(Affiche);
        }
    }
}
