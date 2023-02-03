using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Cadre : Personne
    {
        private int _index;

        public Cadre(string matricule, string nom, string prenom, DateTime date, int index) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
            _index = index;
        }
    }
}
