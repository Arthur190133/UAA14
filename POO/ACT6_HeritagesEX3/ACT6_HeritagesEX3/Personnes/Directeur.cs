using System;
using System.Collections.Generic;
using System.Text;

namespace ACT6_HeritagesEX3.Personnes
{
    class Directeur : Personne
    {
        private int _chiffreAffaire;
        private int _pourcentage;

        public Directeur(string matricule, string nom, string prenom, DateTime date, int chiffreAffaire, int pourcentage) : base(matricule, nom, prenom, date)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = date;
            _chiffreAffaire = chiffreAffaire;
            _pourcentage = pourcentage;
        }
    }
}
