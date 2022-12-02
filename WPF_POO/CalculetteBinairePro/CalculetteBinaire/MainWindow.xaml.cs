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
                        valeur = Addition(FirstNbr.ToString(), SecondNbr.ToString());
                        break;

                    case "-":
                        valeur = Soustraction(FirstNbr.ToString(), SecondNbr.ToString());
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
    }
}
