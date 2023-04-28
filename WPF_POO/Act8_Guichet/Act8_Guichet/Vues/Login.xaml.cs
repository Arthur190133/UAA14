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
using Act8_Guichet.Vues;
using Act8_Guichet.Classes;
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
        MainWindow window = (Act8_Guichet.MainWindow)App.Current.MainWindow;
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
            DataTable Personne = loginPerson.login(name, password);

            if(Personne.Rows.Count > 0)
            {
                Message.Text = "Welcome " + Personne.Rows[0]["Name"].ToString();
                //System.Threading.Thread.Sleep(4000);
                window.CurrentPersonne = new Personne(Personne.Rows[0]["Name"].ToString(), Personne.Rows[0]["LastName"].ToString(), int.Parse(Personne.Rows[0]["Id"].ToString()), (DateTime)Personne.Rows[0]["BirthDate"]);
                window.UpdateUserStatus();
                window.main.Content = new Banque();
            }
            else
            {
                Message.Text = "Nom ou mot de passe incorrecte ! ";
            }
            
        }
    }
}
