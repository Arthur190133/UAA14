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

        public bool Sous(ushort[] nbr1, ushort[] nbr2, ref ushort[] binaire)
        {
            int[] arrayTemp = new int[8];
            ushort[] arrayRes = new ushort[8];
            bool ok = true;

            for (int i = 0; i < 7; i++)
            {
                arrayTemp[i] = (ushort)(nbr1[i] - nbr2[i]);
            }

            for (int i = 7; i > 1; i--)
            {
                if (arrayTemp[i] == -1)
                {
                    nbr2[i - 1]++;
                    nbr1[i] += 2;
                }
                if (nbr1[i] < nbr2[i])
                {
                    nbr2[i - 1]++;
                    nbr1[i] += 2;
                }
                arrayRes[i] = (ushort)(nbr1[i] - nbr2[i]);
            }

            if (nbr1[0] >= nbr2[0])
            {
                arrayRes[0] = (ushort)(nbr1[0] - nbr2[0]);
            }
            else
            {
                ok = false;
            }
            binaire = arrayRes;

            return ok;
        }

        private bool CheckValue(string binaire)
        {
            return double.TryParse(binaire, out _);
        }

        public ushort[] FillArray(string binaire)
        {
            ushort[] array = new ushort[8];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
            //Afficheur.Text = binaire.Length.ToString();
            binaire.Replace(" ", "");
            for (int i = 0; i < binaire.Length; i++)
            {
                array[7 - i] = ushort.Parse(binaire[binaire.Length - 1 - i].ToString());
            }

            return array;
        }

        public ushort[] Add(ushort[] nbr1, ushort[] nbr2)
        {
            bool ok = false;
            int report = 0;

            ushort[] arrayRes = new ushort[8];

            for (int i = 7; i > 0; i--)
            {
                int res = nbr1[i] + nbr2[i] + report;
                if (res / 2 == 0)
                {
                    report = 0;
                }
                else
                {
                    report = 1;
                }

                if (res == 1)
                {
                    arrayRes[i] = 1;
                }
                else
                {
                    if (res % 2 == 1)
                    {
                        arrayRes[i] = 1;
                    }
                    else
                    {
                        arrayRes[i] = 0;
                    }
                }
            }

            if (report == 1)
            {
                ok = false;
            }

            return arrayRes;
        }

        public string binaireToString(ushort[] binaire)
        {
            string result = "";

            for (int i = 0; i < binaire.Length; i++)
            {
                result += binaire[i];
            }

            return result;
        }
    }


}
