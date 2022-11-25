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
        public MainWindow()
        {
            InitializeComponent();

            Calculateur calculateur = new Calculateur();
            
            Afficheur = txtBAfficheur;
        }


        private void AddValue(object sender, RoutedEventArgs e)
        {
            Afficheur.Text += sender.ToString().Substring(sender.ToString().LastIndexOf(':') + 2);

            SpacesNbr++;
            if (SpacesNbr == 4)
            {
                Afficheur.Text += " ";
                SpacesNbr = 0;
            }

            

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if(Afficheur.Text.Length > 0 && !Afficheur.Text.Contains("+") && !Afficheur.Text.Contains("-"))
            {
                FirstNbr = double.Parse(Afficheur.Text.Replace(" ", ""));

                Afficheur.Text += " + ";
                SpacesNbr = 0;
            }

        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (Afficheur.Text.Length > 0 && !Afficheur.Text.Contains("+") && !Afficheur.Text.Contains("-"))
            {
                FirstNbr = double.Parse(Afficheur.Text.Replace(" ", ""));

                Afficheur.Text += " - ";
                SpacesNbr = 0;
            }
        }

        private void Calculer(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
