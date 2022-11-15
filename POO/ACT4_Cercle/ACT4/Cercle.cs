using System;
using System.Collections.Generic;
using System.Text;

namespace ACT4
{
    class Cercle
    {
        private double _rayon;

        public double Rayon
        {
            get
            {
                return _rayon;
            }
            set
            {
                _rayon = value;
            }
        }
        public double CalculeAire()
        {
            double aire;

            aire = Math.PI * Math.Pow(_rayon, 2);

            return aire;
        }

        public double CalculePerimetre()
        {
            double perimetre;

            perimetre = 2 * Math.PI * _rayon;

            return perimetre;
        }

        public void Caracteristique()
        {
            string phrase = "Le cercle de rayon" + _rayon + " a un périmètre de " + CalculePerimetre() + " et une aire de " + CalculeAire();
            Console.WriteLine(phrase);
        }
    }



}
