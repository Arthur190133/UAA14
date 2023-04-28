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
using Act8_Guichet.Classes;
using Act8_Guichet.Config;
using Act8_Guichet.Models;
using System.Data;

namespace Act8_Guichet.Vues
{
    /// <summary>
    /// Logique d'interaction pour Banque.xaml
    /// </summary>
    public partial class Banque : Page
    {
        Compte_epargne[] OwnComptseEpargnes;
        Compte_courant[] OwnComptesCourants;
        Database database;
        MainWindow window = (Act8_Guichet.MainWindow)App.Current.MainWindow;

        public Banque()
        {
            InitializeComponent();
            database = new Database();

            InitializeComponent();
            UpdateComptes();
            //UpdateEpargneUI();


            /*listComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();
            listComptesEpargnes.ItemsSource = comptesEpargnes.readOwn(CurrentUserId).AsDataView();
            listVirementComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();*/
        }


        private void courantAjoutFond(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateComptes()
        {
            Comptes_epargnes epargne = new Comptes_epargnes(database.Connexion());
            Comptes_courants courant = new Comptes_courants(database.Connexion());

            listComptesCourants.ItemsSource = courant.readOwn(window.CurrentPersonne.Id).AsDataView();
            listComptesEpargnes.ItemsSource = epargne.readOwn(window.CurrentPersonne.Id).AsDataView();
            //listVirementComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();
        }

        private void UpdateEpargneUI(Compte_epargne compte)
        {
            soldeEpargne.Text = compte.Money.ToString();
            EpargneAjoutFond.Text = "0";
            EpargneRetireFond.Text = "0";
            EpargneVirementFond.Text = "0";
        }

        private void UpdateCourantUI(Compte_courant compte)
        {
            soldeCourant.Text = compte.Money.ToString();
            CourantAjoutFond.Text = "0";
            CourantRetireFond.Text = "0";
            CourantVirementFond.Text = "0";
        }

        private void epargneAjoutFond(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = listComptesEpargnes.SelectedItem as DataRowView;

            if (CheckIfIsNumber(EpargneAjoutFond.Text) && selectedItem != null)
            {
                
                int id = int.Parse(selectedItem["Id"].ToString());
                Comptes_epargnes compte = new Comptes_epargnes(database.Connexion());
                compte.UpdateMoney(id, float.Parse(EpargneAjoutFond.Text));
                DataTable data = compte.readById(id);

                Compte_epargne compteEpargne = new Compte_epargne(1, data.Rows[0]["Id"].ToString(), window.CurrentPersonne, (DateTime)data.Rows[0]["CreationDate"], float.Parse((data.Rows[0]["Money"].ToString())));

                compteEpargne.AddMoney(float.Parse(EpargneAjoutFond.Text));
                UpdateEpargneUI(compteEpargne);
            }
        }

        private bool CheckIfIsNumber(string value)
        {
            return (float.TryParse(value, out _));
        }

        private void epargneRetireFond(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = listComptesEpargnes.SelectedItem as DataRowView;

            if (CheckIfIsNumber(EpargneRetireFond.Text) && selectedItem != null)
            {

                int id = int.Parse(selectedItem["Id"].ToString());
                Comptes_epargnes compte = new Comptes_epargnes(database.Connexion());
                DataTable data = compte.readById(id);
                Compte_epargne compteEpargne = new Compte_epargne(1, data.Rows[0]["Id"].ToString(), window.CurrentPersonne, (DateTime)data.Rows[0]["CreationDate"], float.Parse((data.Rows[0]["Money"].ToString())));

                compteEpargne.RemoveMoney(float.Parse(EpargneRetireFond.Text));
                UpdateEpargneUI(compteEpargne);
            }

        }

        private void epargneVirementFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(EpargneVirementFond.Text))
            {
                //OwnCompteEpargne.Retrait(float.Parse(EpargneVirementFond.Text), null);
                //UpdateEpargneUI();
            }
        }
    }
}
