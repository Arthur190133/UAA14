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

        public Banque()
        {
            InitializeComponent();
            database = new Database();

            InitializeComponent();
            //UpdateEpargneUI();


            /*listComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();
            listComptesEpargnes.ItemsSource = comptesEpargnes.readOwn(CurrentUserId).AsDataView();
            listVirementComptesCourants.ItemsSource = comptesCourants.readOwn(CurrentUserId).AsDataView();*/
        }


        private void courantAjoutFond(object sender, RoutedEventArgs e)
        {

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
