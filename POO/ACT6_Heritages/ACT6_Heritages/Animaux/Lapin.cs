﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_Heritages.Animaux
{
    class Lapin : Animal
    {
        private float _tailleOreilles;
        public Lapin(string nom, DateTime date, int numPuce, float taille, bool concours, float tailleOrreiles) : base(nom, date, numPuce, taille, concours)
        {
            _nom = nom;
            _dateNaissance = date;
            _numPuce = numPuce;
            _taille = taille;
            _concours = concours;
            _tailleOreilles = tailleOrreiles;
        }

        public float TailleOrreilles
        {
            get
            {
                return _tailleOreilles;
            }
        }

        public string Sauter()
        {
            return "Jm'envole";
        }

        public override string ToString()
        {
            string moi = "je m'appelle " + _nom + " je suis née le " + _dateNaissance + " ma puce est " + _numPuce + "je fais " + _taille + " de hauteur" + " je fais les concours ? " + _concours + " mes oreilles font " + _tailleOreilles;

            return moi;
        }


    }
}
