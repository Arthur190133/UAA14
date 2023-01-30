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
        private Plateau plateau = new Plateau();
        private Joueur[] players = new Joueur[4];
        private int CurrentPlayer = 0;
        


       
        public MainWindow()
        {
            players[0] = new Joueur("X");

            InitializeComponent();
            Frame.Navigate(plateau);
            plateau.InitializeInterface();
            int location = 0;
            plateau.SetPawn(0, players[CurrentPlayer].Pawn,ref location);
            players[0].Location = location;
        }

        private void Jouer (object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int De = random.Next(1, 7);
            int location = players[CurrentPlayer].Location;
            de.Text = "Dé : " + De.ToString();

            if(players[CurrentPlayer].Location + De >= 100)
            {
                plateau.SetPawn(99, players[CurrentPlayer].Pawn, ref location);
                mot.Text = "Fin !";
                btnJouer.IsEnabled = false;
            }
            else
            {
                plateau.SetPawn(players[CurrentPlayer].Location + De, players[CurrentPlayer].Pawn,ref location);
            }

            players[CurrentPlayer].Location = location;

            // CHANGER DE JOUEUR
            //CurrentPlayer = players[CurrentPlayer].PlayersTurn(CurrentPlayer);
            mot.Text = "Joueur " + (CurrentPlayer + 1).ToString();
        }


    }
}
