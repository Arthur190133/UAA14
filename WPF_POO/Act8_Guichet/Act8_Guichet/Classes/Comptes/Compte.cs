using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Personnes;

namespace Act8_Guichet.Classes.Comptes
{
    class Compte
    {
        private string _id;
        private Personne _owner;
        private DateTime _creationDate;
        private float _money;

        public string Id
        {
            get
            {
                return _id;
            } 
        }

        public Personne Owner
        {
            get
            {
                return _owner;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
        }

        public float Money
        {
            get
            {
                return _money;
            }
        }

        protected void RemoveMoney(float money)
        {
            _money -= money;
        }

        public void AddMoney(float money)
        {
            _money += money;
        }

        public abstract bool Retrait(float monant, Compte compte);
    }


}
