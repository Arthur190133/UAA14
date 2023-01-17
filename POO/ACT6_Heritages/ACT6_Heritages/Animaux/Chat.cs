using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_Heritages.Animaux
{
    class Chat : Animal
    {
        public Chat(string nom, DateTime date, int numPuce, float taille, bool concours) : base (nom, date, numPuce, taille, concours)
        {
            _nom = nom;
            _dateNaissance = date;
            _numPuce = numPuce;
            _taille = taille;
            _concours = concours;
        }
        public void Miauler()
        {

        }

        public void Ronronner()
        {

        }
    }
}
