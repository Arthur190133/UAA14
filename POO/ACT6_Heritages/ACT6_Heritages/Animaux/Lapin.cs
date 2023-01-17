﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_Heritages.Animaux
{
    class Lapin : Animal
    {
        private float _tailleOrreilles;
        public Lapin(string nom, DateTime date, int numPuce, float taille, bool concours, float tailleOrreiles) : base(nom, date, numPuce, taille, concours)
        {
            _nom = nom;
            _dateNaissance = date;
            _numPuce = numPuce;
            _taille = taille;
            _concours = concours;
            _tailleOrreilles = tailleOrreiles;
        }

        public float TailleOrreilles
        {
            get
            {
                return _tailleOrreilles;
            }
            set
            {
                _tailleOrreilles = value;
            }
        }

        public void Sauter()
        {
            
        }

        
    }
}