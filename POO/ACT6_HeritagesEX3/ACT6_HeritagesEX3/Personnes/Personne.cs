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
        protected int _salaire;

        public string Matricule { get { return _matricule; }}
        public string Nom { get { return _nom; } }
        public string Prenom { get { return _prenom; } }
        public DateTime DateNaissance { get { return _dateNaissance; } }
        public int Salaire { get { return _salaire; } }

        public Personne(string matricule, string nom, string prenom, DateTime date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
        }

        public virtual void CalculSalaire()
        {
            _salaire = 0;
        }
    }


}
