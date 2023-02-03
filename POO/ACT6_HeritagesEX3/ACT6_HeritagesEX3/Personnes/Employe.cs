using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Employe : Personne
    {
        private DateTime _dateEntre;

        public Employe(string matricule, string nom, string prenom, DateTime date) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
        }
    }
}
