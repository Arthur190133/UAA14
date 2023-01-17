using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_Heritages.Animaux
{
    class Animal
    {
        protected string _nom;
        protected DateTime _dateNaissance;
        protected int _numPuce;
        protected float _taille;
        protected bool _concours;

        public Animal(string nom, DateTime date, int numPuce, float taille, bool concours)
        {
            _nom = nom;
            _dateNaissance = date;
            _numPuce = numPuce;
            _taille = taille;
            _concours = concours;
        }

        public string Nom 
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return _dateNaissance;
            }
            set
            {
                _dateNaissance = value;
            }
        }

        public int NumPuce
        {
            get
            {
                return _numPuce;
            }
            set
            {
                _numPuce = value;
            }
        }

        public float Taille
        {
            get
            {
                return _taille;
            }
            set
            {
                _taille = value;
            }
        }

        public bool Concours
        {
            get
            {
                return _concours;
            }
            set
            {
                _concours = value;
            }
        }

        public void Dormir()
        {


        }

        public void Manger()
        {

        }

    }



}
