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
using Act8_Guichet.Config;
using Act8_Guichet.Models;
using System.Data;

namespace Act8_Guichet.Vues
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Personnes loginPerson;
        Database database;
        public Login()
        {
            InitializeComponent();
            database = new Database();
            loginPerson = new Personnes(database.Connexion());

        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string name = LoginName.Text;
            string password = LoginPassword.Text;
            DataView test = loginPerson.login(name, password).AsDataView();
            Message.Text = test.ToString();
        }
    }
}
