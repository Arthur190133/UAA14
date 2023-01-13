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
        string FirstNbr;
        string SecondNbr;
        int SpacesNbr = 1;
        string CurrentProp = "";
        public MainWindow()
        {
            InitializeComponent();            
            Afficheur = txtBAfficheur;
        }


        private void AddValue(object sender, RoutedEventArgs e)
        {
            Afficheur.Text += (e.Source as Button).Content.ToString();
            if (SpacesNbr == 4)
            {
                Afficheur.Text += " ";
                SpacesNbr = 0;
            }
            SpacesNbr++;
        }

        private void AddProp(object sender, RoutedEventArgs e)
        {
            if (Afficheur.Text.Length > 0 && CurrentProp == "")
            {
                CurrentProp = (e.Source as Button).Content.ToString();
                FirstNbr = Afficheur.Text.Replace(" ", "");
                Afficheur.Text += " " + CurrentProp + " ";
                SpacesNbr = 1;
            }
        }
        private void Calculer(object sender, RoutedEventArgs e)
        {


            string affichage = "";
            if (Afficheur.Text.Contains(CurrentProp) || Afficheur.Text.Contains("="))
            {

                if (!CheckValue(FirstNbr))
                {
                    FirstNbr = "0";
                }

                string nbr2 = Afficheur.Text.Substring(Afficheur.Text.LastIndexOf(CurrentProp) + 2).ToString();
                if (CheckValue(nbr2))
                {
                    SecondNbr = nbr2;
                }

                switch (CurrentProp)
                {
                    case "+":
                        //affichage = Addition(FirstNbr, SecondNbr);
                        affichage = binaireToString(Add(FillArray(FirstNbr.ToString()), FillArray(SecondNbr.ToString())));
                        break;

                    case "-":
                        //affichage = Soustraction(FirstNbr, SecondNbr);
                        ushort[] bin = new ushort[8];
                        Sous(FillArray(FirstNbr.ToString()), FillArray(SecondNbr.ToString()), ref bin);
                        affichage = binaireToString(bin);
                        break;

                    case "x":
                        affichage = Multiplication(FirstNbr, SecondNbr);
                        break;

                    case "÷":
                        affichage = Divistion(FirstNbr, SecondNbr);
                        break;

                    default:
                        affichage = "0";
                        break;
                }

                Afficheur.Text += " = " + affichage;
            }
        }

        private string binaireToString(ushort[] binaire)
        {
            string result = "";

            for (int i = 0; i < binaire.Length; i++)
            {
                result += binaire[i];
            }

            return result;
        }
        

        private void Clear(object sender, RoutedEventArgs e)
        {
            Afficheur.Text = "";
            SpacesNbr = 0;
            CurrentProp = "";
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

        private string Soustraction(string nbr1, string nbr2)
        {
            string sum = Convert.ToString(Convert.ToInt32(nbr1, 2) - Convert.ToInt32(nbr2, 2), 2).PadLeft(4, '0');

            return sum;
        }

        private bool Sous(ushort[] nbr1, ushort[] nbr2, ref ushort[] binaire)
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

        private bool CheckValue(string binaire)
        {
            return double.TryParse(binaire, out _);
        }

        private ushort[] FillArray(string binaire)
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
    }
}
