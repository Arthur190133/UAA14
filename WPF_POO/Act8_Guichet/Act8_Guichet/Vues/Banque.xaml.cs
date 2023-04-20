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
        Personne personne;
        Compte_epargne OwnCompteEpargne;
        Compte_courant OwnCompteCourant;
        Database database;
        int CurrentUserId = 1;

        public Banque()
        {
            InitializeComponent();
            database = new Database();

            personne = new Personne();
            OwnCompteEpargne = new Compte_epargne(0, "1234", personne, DateTime.Now, 150);
            OwnCompteCourant = new Compte_courant(0, 150, "1235", personne, DateTime.Now, 150);
            InitializeComponent();
            UpdateEpargneUI();


            Comptes_courants comptesCourants = new Comptes_courants(database.Connexion()); //listComptesEpargnes
            Comptes_epargnes comptesEpargnes = new Comptes_epargnes(database.Connexion());
            listComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();
            listComptesEpargnes.ItemsSource = comptesEpargnes.readOwn(CurrentUserId).AsDataView();
            listVirementComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();
        }


        private void courantAjoutFond(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateEpargneUI()
        {
            soldeEpargne.Text = OwnCompteEpargne.Money.ToString();
            EpargneAjoutFond.Text = "0";
            EpargneRetireFond.Text = "0";
            EpargneVirementFond.Text = "0";
        }

        private void UpdateCourantUI()
        {
            soldeCourant.Text = OwnCompteCourant.Money.ToString();
            CourantAjoutFond.Text = "0";
            CourantRetireFond.Text = "0";
            CourantVirementFond.Text = "0";
        }

        private void epargneAjoutFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(EpargneAjoutFond.Text))
            {
                OwnCompteEpargne.AddMoney(float.Parse(EpargneAjoutFond.Text));
                UpdateEpargneUI();
            }
        }

        private bool CheckIfIsNumber(string value)
        {
            return (float.TryParse(value, out _));
        }

        private void epargneRetireFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(EpargneRetireFond.Text))
            {
                OwnCompteEpargne.RemoveMoney(float.Parse(EpargneRetireFond.Text));
                UpdateEpargneUI();
            }
        }

        private void epargneVirementFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(EpargneVirementFond.Text))
            {
                OwnCompteEpargne.Retrait(float.Parse(EpargneVirementFond.Text), null);
                UpdateEpargneUI();
            }
        }
    }
}
