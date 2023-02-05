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
        }

        public DateTime DateNaissance
        {
            get
            {
                return _dateNaissance;
            }
        }

        public int NumPuce
        {
            get
            {
                return _numPuce;
            }
        }

        public float Taille
        {
            get
            {
                return _taille;
            }
        }

        public bool Concours
        {
            get
            {
                return _concours;
            }
        }

        public void Dormir()
        {


        }

        public void Manger()
        {

        }

        public override string ToString()
        {
            return "je m'appelle " + _nom + " je suis née le " + _dateNaissance + " ma puce est " + _numPuce + "je fais " + _taille + " de hauteur" + " je fais les concours ? " + _concours;
        }

    }



}
