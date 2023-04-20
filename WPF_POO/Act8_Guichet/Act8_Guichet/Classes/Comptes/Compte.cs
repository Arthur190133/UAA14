using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Act8_Guichet.Classes.Personnes;

namespace Act8_Guichet.Classes.Comptes
{
    abstract class Compte
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
            set
            {
                _id = value;
            }
        }

        public Personne Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
            set { _creationDate = value; }
        }

        public float Money
        {
            get
            {
                return _money;
            }
            set {_money = value; }
        }

        public void RemoveMoney(float money)
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
