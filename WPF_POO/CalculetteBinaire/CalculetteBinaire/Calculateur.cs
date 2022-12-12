using System;
using System.Collections.Generic;
using System.Text;

namespace CalculetteBinaire
{
    class Calculateur
    {
        private string _premierBinaire;
        private string _DeuxiemeBinaire;

        public string PremierBinaire
        {
            get { return _premierBinaire; }
            set { _premierBinaire = value; }
        }

        public string DeuxiemeBinaire
        {
            get { return _DeuxiemeBinaire; }
            set { _DeuxiemeBinaire = value; }
        }

        public string Addition()
        {
            string sum = Convert.ToString(Convert.ToInt32(_premierBinaire, 2) + Convert.ToInt32(_DeuxiemeBinaire, 2), 2).PadLeft(4, '0');
            return sum;
        }

        public string Soustraction()
        {
            string sum = Convert.ToString(Convert.ToInt32(_premierBinaire, 2) - Convert.ToInt32(_DeuxiemeBinaire, 2), 2).PadLeft(4, '0');
            return sum;
        }

        public string Multiplication()
        {
            string sum = Convert.ToString(Convert.ToInt32(_premierBinaire, 2) * Convert.ToInt32(_DeuxiemeBinaire, 2), 2).PadLeft(4, '0');
            return sum;
        }

        public string Division()
        {
            string sum = Convert.ToString(Convert.ToInt32(_premierBinaire, 2) / Convert.ToInt32(_DeuxiemeBinaire , 2), 2).PadLeft(4, '0');
            return sum;
        }
    }


}
