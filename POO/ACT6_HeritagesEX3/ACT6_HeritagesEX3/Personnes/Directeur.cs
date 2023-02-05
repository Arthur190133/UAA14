using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Directeur : Personne
    {
        private int _chiffreAffaire;
        private int _pourcentage;

        public int ChiffreAffaire { get { return _chiffreAffaire; } }
        public int Pourcentage { get { return _pourcentage; } }

        public Directeur(string matricule, string nom, string prenom, DateTime date, int chiffreAffaire, int pourcentage) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
            _chiffreAffaire = chiffreAffaire;
            _pourcentage = pourcentage;
        }

        public override void CalculSalaire()
        {
            _salaire = (_pourcentage / _chiffreAffaire) * 100;
        }

        public override string ToString()
        {
            return "je suis un " + this.GetType().Name + " Matricule : " + _matricule + " Nom :" + _nom + " Prenom : " + _prenom + " DateNaissance : " + _dateNaissance + " Salaire : " + _salaire + " ChiffreAffaire : " + _chiffreAffaire + " Pourcentage : " + _pourcentage;
        }
    }
}
