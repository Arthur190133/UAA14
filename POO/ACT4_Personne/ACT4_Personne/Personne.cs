using System;
using System.Collections.Generic;
using System.Text;

namespace ACT4_Personne
{
    class Personne
    {
        private string _nom;
        private int _cash;

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

        public int Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
            }
        }
        public Personne(string NomPersonne, int Cash)
        {
            _nom = NomPersonne;
            _cash = Cash;
        }

        public void Afficher()
        {
            Console.WriteLine( _nom + "a " + _cash + " euros dans son porte monnaie");
        }



        public bool ALaThune(int cash)
        {
            if (cash < _cash){ return true; }

            return false;
        }

    }
}
