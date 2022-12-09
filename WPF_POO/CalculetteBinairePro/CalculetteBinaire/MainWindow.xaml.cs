using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculetteBinaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock Afficheur;
        double FirstNbr;
        double SecondNbr = 0;
        int SpacesNbr = 0;
        string prop = "";
        public MainWindow()
        {
            InitializeComponent();            
            Afficheur = txtBAfficheur;
        }


        private void AddValue(object sender, RoutedEventArgs e)
        {
            if (!Afficheur.Text.Contains("="))
            {

                Afficheur.Text += sender.ToString().Substring(sender.ToString().LastIndexOf(':') + 2);

                SpacesNbr++;
                if (SpacesNbr == 4)
                {
                    Afficheur.Text += " ";
                    SpacesNbr = 0;
                }
            }
        }

        private void AddProp(object sender, RoutedEventArgs e)
        {
            prop = (e.Source as Button).Content.ToString();

            if (Afficheur.Text.Length > 0 && !Afficheur.Text.Contains(prop))
            {
                FirstNbr = double.Parse(Afficheur.Text.Replace(" ", ""));

                Afficheur.Text += " " + prop +" ";
                SpacesNbr = 0;
            }
        }
        private void Calculer(object sender, RoutedEventArgs e)
        {
            string valeur = "";
            if (Afficheur.Text.Contains(prop) || Afficheur.Text.Contains("="))
            {
                SecondNbr = CheckValue(prop);
                switch (prop)
                {
                    case "+":
                        //valeur = Addition(FirstNbr.ToString(), SecondNbr.ToString());
                        valeur =  binaireToString(Add(FillArray(FirstNbr.ToString()), FillArray(SecondNbr.ToString())));
                        //arr(FillArray(SecondNbr.ToString()));
                        break;

                    case "-":
                        //valeur = Soustraction(FirstNbr.ToString(), SecondNbr.ToString());
                        ushort[] bin = new ushort[8];
                        Sous(FillArray(FirstNbr.ToString()), FillArray(SecondNbr.ToString()),ref bin);
                        valeur = binaireToString(bin);
                        break;

                    case "x":
                        valeur = Multiplication(FirstNbr.ToString(), SecondNbr.ToString());
                        break;

                    case "÷":
                        valeur = Divistion(FirstNbr.ToString(), SecondNbr.ToString());
                        break;

                    default:
                        valeur = "0";
                        break;
                }

                Afficheur.Text += " = " + valeur;
            }
        }

        private string binaireToString(ushort[] binaire)
        {
            string result = "";

            for(int i = 0; i < binaire.Length; i++)
            {
                result += binaire[i];
            }

            return result;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Afficheur.Text = "";
            SpacesNbr = 0;
        }

        private string Addition(string nbr1, string nbr2)
        {
            string sum = Convert.ToString(Convert.ToInt32(nbr1, 2) + Convert.ToInt32(nbr2, 2), 2).PadLeft(4, '0');

            return sum;
        }

        private ushort[] Add(ushort[] nbr1, ushort[] nbr2)
        {
            bool ok = false;
            int report = 0;

            ushort[] arrayRes = new ushort[8];

            for(int i = 7; i > 0; i--)
            {
                int res = nbr1[i] + nbr2[i] + report;
                if(res / 2 == 0)
                {
                    report = 0;
                }
                else
                {
                    report = 1;
                }

                if(res == 1)
                {
                    arrayRes[i] = 1;
                }
                else
                {
                    if(res % 2 == 1)
                    {
                        arrayRes[i] = 1;
                    }
                    else
                    {
                        arrayRes[i] = 0;
                    }
                }
            }

            if(report == 1)
            {
                ok = false;
            }

            return arrayRes;
        }

        private bool Sous(ushort[] nbr1, ushort[] nbr2,ref ushort[]binaire)
        {
            int[] arrayTemp = new int[8];
            ushort[] arrayRes = new ushort[8];
            bool ok = true;

            for(int i = 0; i < 7; i++)
            {
                arrayTemp[i] = (ushort)(nbr1[i] - nbr2[i]);
            }

            for(int i = 7; i > 1; i--)
            {
                if(arrayTemp[i] == -1)
                {
                    nbr2[i - 1]++;
                    nbr1[i] += 2;
                }
                if(nbr1[i] < nbr2[i])
                {
                    nbr2[i - 1]++;
                    nbr1[i] += 2;
                }
                arrayRes[i] = (ushort)(nbr1[i] - nbr2[i]);
            }

            if(nbr1[0] >= nbr2[0])
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

        private void arr(ushort[] array)
        {
            Afficheur.Text += "     ";
            for(int i = 0; i < array.Length; i++)
            {
                Afficheur.Text += array[i];
            }
        }

        private string Soustraction(string nbr1, string nbr2)
        {
            string sum = Convert.ToString(Convert.ToInt32(nbr1, 2) - Convert.ToInt32(nbr2, 2), 2).PadLeft(4, '0');

            return sum;
        }

        private string Multiplication(string nbr1, string nbr2)
        {
            string sum = Convert.ToString(Convert.ToInt32(nbr1, 2) * Convert.ToInt32(nbr2, 2), 2).PadLeft(4, '0');

            return sum;
        }

        private string Divistion(string nbr1, string nbr2)
        {
            string sum = Convert.ToString(Convert.ToInt32(nbr1, 2) / Convert.ToInt32(nbr2, 2), 2).PadLeft(4, '0');

            return sum;
        }

        private double CheckValue(string prop)
        {
            string value = Afficheur.Text.Substring(Afficheur.Text.LastIndexOf(prop) + 1).ToString();
            double nbr;
            double.TryParse(value, out nbr);

            return nbr;
        }

        private ushort[] FillArray(string binaire)
        {
            ushort[] array = new ushort[8];

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
            //Afficheur.Text = binaire.Length.ToString();
            for (int i = 0; i < binaire.Length; i++)
            {
                array[7 - i] = ushort.Parse(binaire[binaire.Length - 1 - i].ToString());
            }

            return array;
        }
    }
}
