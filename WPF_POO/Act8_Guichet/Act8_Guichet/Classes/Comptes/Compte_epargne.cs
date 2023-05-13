using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Comptes;

namespace Act8_Guichet.Classes
{
    class Compte_epargne : Compte
    {
        private float _taux;
        

        public Compte_epargne(float taux, int id, Personne personne, DateTime creationDate, float money)
        {
            Id = id;
            Owner = personne;
            CreationDate = creationDate;
            Money = money;
            _taux = taux;
        }

        public float Taux
        {
            get { return _taux; }
            set { _taux = value; }
        }

        public override void Retrait(float montant, Compte compte)
        {
            if (!(montant > (Money / 2)))
            {
                RemoveMoney(montant);

                compte.AddMoney(montant);
            }
        }
    }

}
