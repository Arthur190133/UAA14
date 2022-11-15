using System;
using System.Collections.Generic;
using System.Text;

namespace ACT4_nombre_complexe
{
    class Complexe
    {
        private int _reelle;
        private int _imaginaire;

        public int Reelle
        {
            get
            {
                return _reelle;
            }
            set
            {
                _reelle = value;
            }
        }
        public int Imaginaire
        {
            get
            {
                return _imaginaire;
            }
            set
            {
                _imaginaire = value;
            }
        }

        public void AfficheComplexe()
        {
            Console.WriteLine("Réelle : " + _reelle);
            Console.WriteLine("Imaginaire : " + _imaginaire);
        }
        
        public float CalculeModule()
        {
            float module;

            module = (float)((float)Math.Pow(_reelle, 2) + Math.Pow(_imaginaire, 2));
            module = (float)Math.Sqrt(module);

            return module;
        }

        public void Ajoute(int newReelle, int newImaginaire)
        {
            _reelle += newReelle;
            _imaginaire += newImaginaire;
        }

    }
}
