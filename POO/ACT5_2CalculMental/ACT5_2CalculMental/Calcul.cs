using System;
using System.Collections.Generic;
using System.Text;

namespace ACT5_2CalculMental
{
    class Calcul
    {
        private string _op;
        private int _n1;
        private int _n2;

        public string Op
        {
            get
            {
                return _op;
            }
        }
        public int N1
        {
            get
            {
                return _n1;
            }
        }
        public int N2
        {
            get
            {
                return _n2;
            }
        }
        // constructeur
        public Calcul(bool addition)
        {
            Random r = new Random();
            if (addition)
            {
                _op = "+";
            }
            else
            {
                _op = "*";
            }
            _n1 = r.Next(1, 10);
            _n2 = r.Next(1, 10);
        }

        // vérifie si une réponse est correcte
        public bool VerifOpe(int rep)
        {
            bool verif;
            if (_op == "+")
            {
                verif = (rep == _n1 + _n2);
            }
            else
            {
                verif = (rep == _n1 * _n2);
            }
            return verif;
        }
    }

}

