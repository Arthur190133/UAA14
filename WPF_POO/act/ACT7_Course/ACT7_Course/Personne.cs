using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ACT7_Course
{
    internal class Personne
    {
        private string _nom;
        private int _argent;

        public string Nom
        {
            get { return _nom; }
        }

        public int Argent
        {
            get { return _argent; }
        }

        public Personne(string nom, int argent)
        {
            _nom = nom;
            _argent = argent;
        }


        public Pari Parier(int mise, Chien chien)
        {
            Pari pari  = new Pari(this, chien, mise);
            return pari;
        }

        public void UpdateWallet(int argent)
        {
            _argent += argent;
        }
    }
}
