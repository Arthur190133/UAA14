using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Personne
    {
        protected string _matricule;
        protected string _nom;
        protected string _prenom;
        protected DateTime _dateNaissance;

        public Personne(string matricule, string nom, string prenom, DateTime date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
        }
    }


}
