using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Comptes;

namespace Act8_Guichet.Classes
{
    class Compte_courant : Compte
    {
        private double _number;
        private int _maxDecouvert;
        

        public Compte_courant(double number, int maxDecouvert, int id, Personne personne, DateTime creationDate, float money)
        {
            Id = id;
            Owner = personne;
            CreationDate = creationDate;
            Money = money;
            _maxDecouvert = maxDecouvert;
            _number = number;
        }

        public int MaxDecouvert
        {
            get { return _maxDecouvert; }
            set { _maxDecouvert = value; }
        }

        public double Number
        {
            get { return _number; }
            set { _number = value; }
        }


        public override void Retrait(float montant, Compte compte)
        {
            if(!(montant > Money && (Money - montant) < _maxDecouvert))
            {
                RemoveMoney(Money - montant);
            }
        }
    }

}
