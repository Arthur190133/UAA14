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
using System.Windows.Threading;

namespace MatchingGame_Arthur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    List<string> AnimalEmoji = new List<string>()
        {
            "🐈","🐈",
            "🐷","🐷",
            "🐐","🐐",
            "🦊","🦊",
            "🐴","🐴",
            "🦨","🦨",
            "🦉","🦉",
            "🐀","🐀",
        };
        DispatcherTimer timer = new DispatcherTimer();
        int tempsEcoule = 0;
        int nbPairesTrouvees = 0;
        TextBlock derniereTBClique = null;
        bool trouvePaire = false;
        public MainWindow()
        {

            timer.Interval = TimeSpan.FromSeconds(.06);
            timer.Tick += new EventHandler(Timer_tick);
            timer.Start();

            InitializeComponent();
            SetUpGame();
        }
        private void SetUpGame() 
        { 
            tempsEcoule = 0;
            nbPairesTrouvees = 0;
            SetTextBlocks();
            timer.Start();
        }

        private void SetTextBlocks()
        {
            Random random = new Random();
            foreach (TextBlock textBlock in Grid.Children.OfType<TextBlock>())
            {
                if(textBlock.Name != "txtTemps" && AnimalEmoji.Count != 0)
                {
                    
                    Random nbAlea = random;
                    int index = nbAlea.Next(AnimalEmoji.Count); // index est de type int // nbalea est un objet de type Random()
                    string nextEmoji = AnimalEmoji[index]; // nextEmoji est de type string
                    textBlock.Text = nextEmoji;
                    AnimalEmoji.RemoveAt(index); // on retire un animal de la liste pour ne pas l’attribuer à nouveau.
                }

            }

        }

        private void txtTemps_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nbPairesTrouvees == 8)
            {
                SetUpGame();
            }
        }


        private void Timer_tick(object sender, EventArgs e)
        {
            tempsEcoule++;
            txtTemps.Text = (tempsEcoule / 10F).ToString("0.0s");
            if (nbPairesTrouvees == 8)
            {

                timer.Stop();
                txtTemps.Text = txtTemps.Text + " - Rejouer ?";
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock textBlockActif = sender as TextBlock;
            if (!trouvePaire)
            {
                textBlockActif.Visibility = Visibility.Hidden;
                derniereTBClique = textBlockActif;
                trouvePaire = true;
            }
            else if (textBlockActif.Text == derniereTBClique.Text)
            {
                nbPairesTrouvees++;
                textBlockActif.Visibility = Visibility.Hidden;
                trouvePaire = false;
            }
            else if (textBlockActif.Text == derniereTBClique.Text)
            {
                textBlockActif.Visibility = Visibility.Hidden;
                trouvePaire = false;
            }
            else
            {
                derniereTBClique.Visibility = Visibility.Visible;
                trouvePaire = false;
            }
        }
    }
}
