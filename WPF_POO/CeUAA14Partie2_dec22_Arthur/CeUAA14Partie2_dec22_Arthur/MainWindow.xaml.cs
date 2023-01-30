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

namespace CeUAA14Partie2_dec22_Arthur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int totalJoueur = 4;
        int[] PlayersPawnLocation = new int[4];
        string[] PlayersPawn = new string[4];

       
        public MainWindow()
        {
            PlayersPawnLocation[0] = 0;
            PlayersPawn[0] = "X";

            InitializeComponent();
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            for(int i = 0; i <= 100; i++)
            {
                plateau.Children.Add(new TextBlock());
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int value;
                    
                    if (i % 2 == 0)
                    {
                        value = (10 * i) + j + 1;
                    }
                    else
                    {
                        value = (10 * i) + 10 - j;
                    }
                    TextBlock textBlock = (TextBlock)plateau.Children[(10 * i) + j];
                    textBlock.Text = value.ToString();
                    if(value % 2 == 0)
                    {
                        textBlock.Background = Brushes.Aqua;
                    }
                    else
                    {
                        textBlock.Background = Brushes.Red;
                    }
                    textBlock.Height = 50;
                    textBlock.Width = 50;
                    textBlock.Name = "Value" + value.ToString();
                }
            }
            SetPawn(0, PlayersPawn[0]);
        }

        private void Jouer (object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int De = random.Next(1, 7);
            de.Text = "Dé : " + De.ToString();

            if(PlayersPawnLocation[0] + De >= 100)
            {
                SetPawn(99, PlayersPawn[0]);
                mot.Text = "Fin !";
                btnJouer.IsEnabled = false;
            }
            else
            {
                SetPawn(PlayersPawnLocation[0] + De, PlayersPawn[0]);
            }
        }

        private void SetPawn(int  Newvalue,string Pawn)
        {
            TextBlock textBlock = plateau.Children.OfType<TextBlock>().FirstOrDefault(x => x.Text == Pawn);
            if(textBlock != null)
            {
                textBlock.Text = (PlayersPawnLocation[0] + 1).ToString();
                textBlock.Foreground = Brushes.Black;
            }


            PlayersPawnLocation[0] = Newvalue;
            TextBlock newTextBlock = plateau.Children.OfType<TextBlock>().FirstOrDefault(x => x.Text == (PlayersPawnLocation[0] + 1).ToString());
            if (newTextBlock != null)
            {
                //test.Text = "index" + PlayersPawnLocation[0].ToString() + "value" + newTextBlock.Text;
                newTextBlock.Text = Pawn;
                newTextBlock.Foreground = Brushes.Gold;
                
            }


        }
    }
}
