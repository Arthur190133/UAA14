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
        Compte_epargne CurrentCompteEpargne;
        Compte_courant CurrentCompteCourant;
        Compte_courant CurrentCompteVirement;
        Comptes_epargnes Table_Epargne;
        Comptes_courants Table_Courant;
        Database database;
        MainWindow window = (Act8_Guichet.MainWindow)App.Current.MainWindow;

        public Banque()
        {
            InitializeComponent();
            database = new Database();

            Table_Epargne = new Comptes_epargnes(database.Connexion());
            Table_Courant = new Comptes_courants(database.Connexion());

            UpdateComptes();
        }


        private void courantAjoutFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(CourantFond.Text) && CurrentCompteCourant != null)
            {
                CurrentCompteCourant.AddMoney(float.Parse(CourantFond.Text));
                Table_Courant.UpdateMoney(CurrentCompteCourant.Id, CurrentCompteCourant.Money);
                CurrentCompteCourant = GetCourant(CurrentCompteCourant.Id.ToString());
                UpdateCourantUI(CurrentCompteCourant);
            }
        }

        private void courantRetireFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(CourantFond.Text) && CurrentCompteCourant != null)
            {
                if(float.Parse(CourantFond.Text) < CurrentCompteCourant.MaxDecouvert)
                {
                    messageError.Text = "VOUS DEPASSEZ VOTRE DECOUVERT";
                }
                else
                {
                    CurrentCompteCourant.RemoveMoney(float.Parse(CourantFond.Text));
                    Table_Courant.UpdateMoney(CurrentCompteCourant.Id, CurrentCompteCourant.Money);
                    CurrentCompteCourant = GetCourant(CurrentCompteCourant.Id.ToString());
                    UpdateCourantUI(CurrentCompteCourant);
                }

            }
        }

        private void UpdateComptes()
        {
            listComptesCourants.ItemsSource = Table_Courant.readOwn(window.CurrentPersonne.Id).AsDataView();
            listComptesEpargnes.ItemsSource = Table_Epargne.readOwn(window.CurrentPersonne.Id).AsDataView();
            listComptesVirement.ItemsSource = Table_Courant.read().AsDataView();
        }

        private void UpdateEpargneUI(Compte_epargne compte)
        {
            soldeEpargne.Text = compte.Money.ToString();
            tauxeEpargne.Text = compte.Taux.ToString();
            Fond.Text = "0";
            messageError.Text = "";
        }

        private void UpdateCourantUI(Compte_courant compte)
        {
            soldeCourant.Text = compte.Money.ToString();
            maxDecouvertCourant.Text = compte.MaxDecouvert.ToString();
            numberCourant.Text = compte.Number.ToString();
            CourantFond.Text ="0";
            messageError.Text = "";
        }

        private void epargneAjoutFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(Fond.Text) && CurrentCompteEpargne != null)
            {
                CurrentCompteEpargne.AddMoney(float.Parse(Fond.Text));
                Table_Epargne.UpdateMoney(CurrentCompteEpargne.Id, CurrentCompteEpargne.Money);
                CurrentCompteEpargne = GetEpagne(CurrentCompteEpargne.Id.ToString());
                UpdateEpargneUI(CurrentCompteEpargne);
            }
        }

        private bool CheckIfIsNumber(string value)
        {
            return (float.TryParse(value, out _));
        }

        private void epargneRetireFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(Fond.Text) && CurrentCompteEpargne != null)
            {
                CurrentCompteEpargne.RemoveMoney(float.Parse(Fond.Text));
                Table_Epargne.UpdateMoney(CurrentCompteEpargne.Id, CurrentCompteEpargne.Money);
                CurrentCompteEpargne = GetEpagne(CurrentCompteEpargne.Id.ToString());
                UpdateEpargneUI(CurrentCompteEpargne);
            }

        }

        private void epargneVirementFond(object sender, RoutedEventArgs e)
        {
            if (CheckIfIsNumber(Fond.Text) && CurrentCompteVirement != null && CurrentCompteEpargne != null)
            {
                if (CurrentCompteVirement.Id != CurrentCompteEpargne.Id)
                {
                    messageError.Text = "VOUS NE POSSEDEZ PAS LE COMPTE";
                }
                else
                {
                    int VirementFond = int.Parse(Fond.Text);
                    CurrentCompteEpargne.Retrait(VirementFond, CurrentCompteVirement);

                    Table_Epargne.UpdateMoney(CurrentCompteEpargne.Id, CurrentCompteEpargne.Money);
                    Table_Courant.UpdateMoney(CurrentCompteVirement.Id, CurrentCompteVirement.Money);
                    UpdateEpargneUI(CurrentCompteEpargne);
                }

            }
            else
            {
                messageError.Text = "IMPOSSIBLE DE FAIRE LE VIREMENT";
            }
        }

        private void listComptesEpargnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                DataRowView selectedRow = (DataRowView)listComptesEpargnes.SelectedItem;
                var columnValue = selectedRow["Id"];
                CurrentCompteEpargne = GetEpagne(columnValue.ToString());
                UpdateEpargneUI(CurrentCompteEpargne);
        }

        private Compte_epargne GetEpagne(string id)
        {
            if (int.TryParse(id.ToString(), out _))
            {
                DataTable data = Table_Epargne.readById(int.Parse(id.ToString()));
                return new Compte_epargne(1, int.Parse(data.Rows[0]["Id"].ToString()), window.CurrentPersonne, (DateTime)data.Rows[0]["CreationDate"], float.Parse((data.Rows[0]["Money"].ToString())));
            }
            return null;
        }

        private Compte_courant GetCourant(string id)
        {
            if (int.TryParse(id.ToString(), out _))
            {
                DataTable data = Table_Courant.readById(int.Parse(id.ToString()));
                return new Compte_courant(int.Parse(data.Rows[0]["Number"].ToString()), int.Parse(data.Rows[0]["MaxDecouvert"].ToString()), int.Parse(data.Rows[0]["Id"].ToString()), window.CurrentPersonne, (DateTime)data.Rows[0]["CreationDate"], float.Parse((data.Rows[0]["Money"].ToString())));
            }
            return null;
        }

        private void listComptesVirement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)listComptesVirement.SelectedItem;
            var columnValue = selectedRow["Id"];

            CurrentCompteVirement = GetCourant(columnValue.ToString());

            
        }

        private void listComptesCourants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)listComptesCourants.SelectedItem;
            var columnValue = selectedRow["Id"];

            CurrentCompteCourant = GetCourant(columnValue.ToString());
            UpdateCourantUI(CurrentCompteCourant);
        }
    }
}
