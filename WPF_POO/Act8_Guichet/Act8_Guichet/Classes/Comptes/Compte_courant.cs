using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Personnes;

namespace Act8_Guichet.Classes.Comptes
{
    class Compte_courant : Compte
    {
        private double _number;
        private int _maxDecouvert;

        public Compte_courant(double number, int maxDecouvert, string id, Personne personne, DateTime creationDate, float money) : base( id,  personne,  creationDate,  money)
        {

        }


        public override bool Retrait(float montant, Compte compte)
        {
            if(montant > Money)
            {
                return false;
            }
            else
            {
                RemoveMoney(Money - montant);
                return true;
            }
        }
    }

}
