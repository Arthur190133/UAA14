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
using System.Diagnostics;

namespace ACT3BIS_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Semaines = 0;
        DateTime Start;
        DateTime End;
        public MainWindow()
        {
            InitializeComponent();
            txtBPers.PreviewTextInput += new TextCompositionEventHandler(CheckUserNumber);
            //txtBStartDate.PreviewTextInput += new TextCompositionEventHandler(CheckStartDate);
            

        }

        private void CheckUserNumber(object sender, TextCompositionEventArgs e)
        {
                if (e.Text != "," && !EstEntier(e.Text))
                {
                      e.Handled = true;
                }
                if (EstEntier(e.Text))
                {
                    if (int.Parse(e.Text) < 1 || int.Parse(e.Text) > 6)
                    {
                         e.Handled = true;
                    }
                }
            }
            private bool EstEntier(string userText)
        {
            return int.TryParse(userText, out _);
        }

        private bool ValidDates(string StartDate, string EndDate)
        {
            
            if (VerifDate(StartDate) && VerifDate(EndDate))
            {

                 Start = DateTime.Parse(StartDate);
                 End = DateTime.Parse(EndDate);
                
                // verifier si la premire date est avant la deuxième
                if(End > Start)
                {
                    // verifier si trop long
                    if ((End.Subtract(Start).Days / 30 <= 3) && (End.Year - Start.Year) <= 1)
                    {
                        RecupSemaines(Start, End);
                        Weeks.Text = Semaines + " Semaine(s)";
                        // Dates OK

                        btnCalculer.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Weeks.Text = "Les dates sont trop éloignées";
                    }
                }
                else
                {
                    Weeks.Text = "La premire date est avant la deuxième !!";
                }


            }
            else
            {
                Weeks.Text = "Dates invalides";
            }
            return false;
        }

        private void RecupSemaines(DateTime Start , DateTime End)
        {
            Semaines = ((End.Subtract(Start).Days - 1) / 7 + 1);
        }

        private bool VerifDate(string Date)
        {
            if(DateTime.TryParse(Date, out _)){ return true; };

            return false;
        }
        
        private double calculerPrix()
        {
            int Temps = 0;
            if(Start.Month >= 7 && End.Month <= 8)
            {
                Temps = 1;
            }
           //txtBPers.Text = End.Month.ToString();

            int prix = CalculerPrixSemaines(Temps);

            if(Semaines == 3 || Semaines == 4)
            {
                prix = prix - (int)(prix * 0.05);
            }
            else if(Semaines >= 5)
            {
                prix = prix - (int)(prix * 0.1);
            }

            if(CheckBoxReserv.IsChecked == true)
            {
                prix += 12;
            }

            int jours = Semaines * 7;
            double prixFinal = prix;
            prixFinal += (jours * 0.30) * double.Parse(txtBPers.Text);

            return prixFinal;
        }

        private int CalculerPrixSemaines(int Temps)
        {
            int nbrPersonnes = int.Parse(txtBPers.Text);
            int Emplacement = 1;
            int prix = 0;
            if (RadioLogementChalet.IsChecked == true)
            {
                Emplacement = 0;
            }

            switch (Temps)
            {
                case 0:
                    switch (Emplacement)
                    {
                        case 0:
                            switch (nbrPersonnes)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    prix = 547 * Semaines;
                                    break;

                                case 5:
                                    prix = 581 * Semaines;
                                    break;

                                case 6:
                                    prix = 599 * Semaines;
                                    break;
                            }
                            break;

                        case 1:
                            switch (nbrPersonnes)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    prix = 349 * Semaines;
                                    break;

                                case 5:
                                    prix = 380 * Semaines;
                                    break;

                                case 6:
                                    prix = 390 * Semaines;
                                    break;
                            }
                            break;
                    }
                    break;

               case 1:
                    switch (Emplacement)
                    {
                        case 0:
                            switch (nbrPersonnes)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    prix = 297 * Semaines;
                                    break;

                                case 5:
                                    prix = 330 * Semaines;
                                    break;

                                case 6:
                                    prix = 347 * Semaines;
                                    break;
                            }
                            break;

                        case 1:
                            switch (nbrPersonnes)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    prix = 198 * Semaines;
                                    break;

                                case 5:
                                    prix = 220 * Semaines;
                                    break;

                                case 6:
                                    prix = 250 * Semaines;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return prix;
        }

        private void calculerdureesortieEvent(object sender, RoutedEventArgs e)
        {
            Weeks.Text = "validi";
            ValidDates(txtBStartDate.Text, txtBEndDate.Text);
        }

        private void Calculer(object sender, RoutedEventArgs e)
        {
            if (!(RadioLogementChalet.IsChecked == false && RadioLogementTente.IsChecked == false) && txtBPers.Text != "" && txtBStartDate.Text != "" && txtBEndDate.Text != "")
            {
                double totalPrix = calculerPrix();
                txtPrix.Text = "Prix à payez : " + totalPrix;

                txtSemaine.Text = "Nombres de semaines : " + Semaines;
            }
        }
    }
}
