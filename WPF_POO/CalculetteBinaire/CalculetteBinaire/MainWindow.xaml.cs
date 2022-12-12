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
        int SpacesNbr = 1;
        string CurrentProp = "";
        Calculateur calculateur = new Calculateur();
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
                Afficheur.Text += CurrentProp + " ";
                SpacesNbr = 1;
            }
        }

        private void Calculer(object sender, RoutedEventArgs e)
        {
            string nbr2;
            string affichage = "";
            if (CheckValue(FirstNbr))
            {
                calculateur.PremierBinaire = FirstNbr;
            }
            
            nbr2 = Afficheur.Text.Substring(Afficheur.Text.LastIndexOf(CurrentProp) + 2).ToString();
            if (CheckValue(nbr2))
            {
                calculateur.DeuxiemeBinaire = nbr2;
            }

            switch (CurrentProp)
            {
                case "+":
                    affichage = calculateur.Addition();
                    break;

                case "-":
                    affichage = calculateur.Soustraction();
                    break;

                case "x":
                    affichage = calculateur.Multiplication();
                    break;

                case "÷":
                    affichage = calculateur.Division();
                    break;

                default:
                    affichage = "0";
                    break;
            }

            Afficheur.Text += " = " + affichage;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            txtBAfficheur.Text = null;
            SpacesNbr = 1;
            CurrentProp = "";
        }

        private bool CheckValue(string binaire)
        {
            return (double.TryParse(binaire, out _));
        }
    }
}
