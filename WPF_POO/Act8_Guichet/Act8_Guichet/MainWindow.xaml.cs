using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Act8_Guichet.Vues;
using Act8_Guichet.Classes;

namespace Act8_Guichet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Personne CurrentPersonne;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUserStatus();

            main.Content = new Login();
        }

        public void UpdateUserStatus()
        {
            if (CurrentPersonne != null)
            {
                UserStatus.Text = "UserStatus:" + CurrentPersonne.Name ;
            }
            else
            {
                UserStatus.Text = "UserStatus:Not connected";
            }
        }

    }
}
