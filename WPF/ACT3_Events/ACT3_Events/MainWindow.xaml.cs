using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ACT3_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] Numbers = new int[3];
        DispatcherTimer timer = new DispatcherTimer();
        Calculs calculs = new Calculs();
        string type = null;
        public MainWindow()
        {
            InitializeComponent();
            //TextCompositionEventHandler PreviewTextInput;
            txtA.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            txtB.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            txtC.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);

            calculer.MouseEnter += new MouseEventHandler(SurvolButton);
            calculer.MouseLeave += new MouseEventHandler(StopSurvolButton);


        }

        private void Calculer(object sender, MouseButtonEventArgs e)
        {
             calculs.ResoudreTrinome(int.Parse(txtA.Text), int.Parse(txtB.Text), int.Parse(txtC.Text), out type);
             PageResultat secondpage = new PageResultat();
             secondpage.txtResultat.Text = type;
             Visibility = Visibility.Hidden;
             secondpage.Show();

        }

        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && !EstEntier(e.Text))
            {
                e.Handled = true;
            }
            if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
            {
                e.Handled = true;
            }
            else
            {


            }
        }

        private bool EstEntier(string userText)
        {
            return int.TryParse(userText, out _);
        }

        private void SurvolButton(object sender, EventArgs e)
        {
            vButton.Visibility = Visibility.Visible;
            vButton.Background = Brushes.Red;
        }

        private void StopSurvolButton(object sender, EventArgs e)
        {
            vButton.Visibility = Visibility.Hidden;
        }

    }
}
