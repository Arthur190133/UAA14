﻿using System;
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
        TextBlock[] cases = new TextBlock[100];
        int AncienneValeur;
        int totalJoueur;
        int reste;
        int[] positionPionJoueur = new int[2];
        public MainWindow()
        {
            InitializeComponent();
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int value;
                    TextBlock textBlock = new TextBlock();
                    if (i % 2 == 0)
                    {
                        value = (10 * i) + j + 1;
                    }
                    else
                    {
                        value = (10 * i) + 10 - j;
                    }
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
                    plateau.Children.Add(textBlock);
                    cases[value - 1] = textBlock;
                }
            }
            AncienneValeur = 0;
            SetX(0);
        }

        private void Jouer (object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int De = random.Next(1, 7);
            de.Text = "Dé : " + De.ToString();



            if(AncienneValeur + De >= 100)
            {
                SetX(99);
                mot.Text = "Fin !";
                btnJouer.IsEnabled = false;
            }
            else
            {
                SetX(AncienneValeur + De);
            }
            


            /*totalJoueur += De;
            reste = totalJoueur - 10 * (positionPionJoueur[0] + 1);

            if(reste < 0)
            {
                reste += 10;
            }
            else
            {
                positionPionJoueur[0] += 1;
            }

            if(positionPionJoueur[0] %2 != 0)
            {
                positionPionJoueur[1] = 9 - reste;
            }
            else
            {
                positionPionJoueur[1] = reste;
            }

            if(positionPionJoueur[0] <= 9)
            {
                SetX(positionPionJoueur[1] + (10 * positionPionJoueur[0]));
            }
            else
            {
                SetX(99);
                mot.Text = "Fin !";
                btnJouer.IsEnabled = false;
            }*/
        }

        private void SetX(int  Newvalue)
        {
            cases[AncienneValeur].Text = (AncienneValeur + 1 ).ToString();
            cases[AncienneValeur].Foreground = Brushes.Black;
            AncienneValeur = Newvalue;
            cases[AncienneValeur].Text = "X";
            cases[AncienneValeur].Foreground = Brushes.Gold;

        }
    }
}
