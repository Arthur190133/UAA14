using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Employe : Personne
    {
        private int _annee = 0;

        public int Annee { get { return _annee; }}

        public Employe(string matricule, string nom, string prenom, DateTime date, int Annee) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
            _annee = Annee;
        }

        public override void CalculSalaire()
        {
            _salaire = Math.Min((_annee * 100) + 2500, 5000) ;    
        }

        public override string ToString()
        {
            return "je suis un " + this.GetType().Name +  " Matricule : " + _matricule + " Nom :" + _nom + " Prenom : " + _prenom + " DateNaissance : " + _dateNaissance + " Salaire : " + _salaire + " Annee : " + _annee;
        }
    }
}
