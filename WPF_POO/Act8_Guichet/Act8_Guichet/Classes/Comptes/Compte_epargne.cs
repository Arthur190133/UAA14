using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Personnes;

namespace Act8_Guichet.Classes.Comptes
{
    class Compte_epargne : Compte
    {
        private float _taux;
        

        public Compte_epargne(float taux, string id, Personne personne, DateTime creationDate, float money)
        {
            _id = id;
            _owner = personne;
            _creationDate = creationDate;
            _money = money;
            _taux = taux;
        }

        public override bool Retrait(float montant, Compte compte)
        {
            if (montant > (Money / 2))
            {
                return false;
            }
            else
            {
                float cache_removed_money = Money - montant;
                RemoveMoney(cache_removed_money);
                
                // Verifier si compte est compteEpargne
                if(compte is Compte_epargne)
                {
                    if (CheckIfCanSendMoney((Compte_epargne)compte))
                    {
                        compte.AddMoney(cache_removed_money);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //AddMoney(cache_removed_money);
                return true;
            }
        }

        private bool CheckIfCanSendMoney(Compte_epargne compte)
        {
            return Owner == compte.Owner;
        }
    }

}
