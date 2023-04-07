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
using Act8_Guichet.Classes.Comptes;
using Act8_Guichet.Classes.Personnes;

namespace Act8_Guichet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Personne personne = new Personne();
            Compte_epargne compte = new Compte_epargne(0, "1234", personne, DateTime.Now, 150);
            compte.Retrait(15, compte);
        }
    }
}
