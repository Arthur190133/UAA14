using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Cadre : Personne
    {
        private int _index = 1;
        public int Index { get { return _index; } }

        public Cadre(string matricule, string nom, string prenom, DateTime date, int index) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
            _index = index;
        }

        public override void CalculSalaire()
        {
            _index = Math.Min(_index, 4);
            _salaire = 13000 + ((_index - 1) * 2000 + ((_index == 4) ? 1000 : 0));
        }

        public override string ToString()
        {
            return "je suis un " + this.GetType().Name + " Matricule : " + _matricule + " Nom :" + _nom + " Prenom : " + _prenom + " DateNaissance : " + _dateNaissance + " Salaire : " + _salaire +  "Index : " + _index;
        }
    }
}
