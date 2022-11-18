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
        public MainWindow()
        {
            InitializeComponent();
            txtBPers.PreviewTextInput += new TextCompositionEventHandler(CheckUserNumber);
            //txtBStartDate.PreviewTextInput += new TextCompositionEventHandler(CheckStartDate);
        
        }

        private void CheckStartDate(object sender, TextCompositionEventArgs e)
        {
            DateTime StartDate;
            string.Format("dd-mm-YY", e.Text);

           
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
                
                DateTime Start = DateTime.Parse(StartDate);
                DateTime End = DateTime.Parse(EndDate);
                

                // verifier si trop long
                if((End.Month - Start.Month) <= 3 && (End.Year - Start.Year) <= 1)
                {
                    int nbrSemaine = RecupSemaine(Start, End);
                    Weeks.Text = nbrSemaine.ToString();
                }
            }
            return false;
        }

        private int RecupSemaine(DateTime Start , DateTime End)
        {
            return (End.DayOfYear - Start.DayOfYear) / 7;
        }

        private bool VerifDate(string Date)
        {
            if(DateTime.TryParse(Date, out _)){ return true; };

            return false;
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Weeks.Text = "validi";
            ValidDates(txtBStartDate.Text, txtBEndDate.Text);
        }

    }
}
