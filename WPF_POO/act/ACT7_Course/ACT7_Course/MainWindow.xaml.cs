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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ACT7_Course
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personne[] personnes = new Personne[3];
        Chien[] chiens = new Chien[4];
        Pari[] paris = new Pari[3];

        int CurrentPersonneSelected;
        bool IsRaceStarted = false;
        public MainWindow()
        {
           InitializeComponent();
           InitializePersonne();
           InitializeChien();
           InitializePari();
           InitializeInterface();
        }

        private void InitializePersonne()
        {
            personnes[0] = new Personne("Joe", 50);
            personnes[1] = new Personne("Bob", 75);
            personnes[2] = new Personne("Bill", 45);
        }

        private void InitializeChien()
        {
            for (int i = 0; i < chiens.Length; i++)
            {
                chiens[i] = new Chien(i, new Image());
            }
        }

        private void ClearChien()
        {
            for (int i = 0; i < chiens.Length; i++)
            {
                CanvasChiens.Children.Remove(chiens[i].image);
                chiens[i].image.Source = null ;
            }
        }

        private void InitializePari()
        {
            for (int i = 0; i < paris.Length; i++)
            {
                paris[i] = new Pari(new Personne("", 0), new Chien(0, new Image()), 0);
            }
        }

        private void InitializeInterface()
        {
            // Initialiser la course
            BitmapImage imageChien = new BitmapImage();
            imageChien.BeginInit();
            imageChien.UriSource = new Uri("/dog.png", UriKind.Relative);
            imageChien.EndInit();

            for(int i = 0; i < chiens.Length; i++)
            {
                Image image = new Image();
                image.Source = imageChien;
                image.Height = 35;
                image.Width = 121;
                Canvas.SetTop(image, 58 * i);
                chiens[i].image = image;

                CanvasChiens.Children.Add(image);
            }

            // Initialiser la salle des paris

            PersonneName.Text = personnes[0].Nom;

            UpdateParieursPanel();
            UpdateParieursState();

        }

        private void UpdateParieursState()
        {
            for (int i = 0; i < personnes.Length; i++)
            {
                TextBlock? textBlockPersonne = ParieursState.Children[i] as TextBlock;

                // Utilisez le RadioButton sélectionné pour effectuer des opérations
                if (textBlockPersonne != null)
                {

                    Pari? pariPersonne = paris.FirstOrDefault(pari => pari.Personne == personnes[i]);
                    if (pariPersonne != null)
                    {
                        textBlockPersonne.Text = personnes[i].Nom + " a parié " + pariPersonne.Mise + " écus sur le chiens numéro " + (pariPersonne.Chien.Numero + 1);
                    }
                    else
                    {
                        textBlockPersonne.Text = personnes[i].Nom + " n'a pas encore parié";
                    }
                    
                }
            }
        }

        private void UpdateParieursPanel()
        {
            string ecus = " écus";
            for (int i = 0; i < personnes.Length; i++)
            {
                RadioButton? radioButton = ParieursPanel.Children[i] as RadioButton;

                // Utilisez le RadioButton sélectionné pour effectuer des opérations
                if (radioButton != null)
                {
                    if (personnes[i].Argent <= 1)
                    {
                        ecus = " écu";
                    }
                    radioButton.Content = personnes[i].Nom + " possède " + personnes[i].Argent + ecus;
                }
            }
        }

        private void GenerateRace()
        {
            Random random = new Random();
            int WinnerDog = random.Next(0, chiens.Length - 1);
            Chien ChienCache = chiens[WinnerDog];
            chiens[WinnerDog] = chiens[0];
            chiens[0] = ChienCache;

            MoveChien(chiens[0], 700);

            for (int i = 1; i < chiens.Length; i++)
            {
                int randomDistance = random.Next(200, 650);
                MoveChien(chiens[i], randomDistance);
            }
            RemoveEcuPersonne();
            EndRace(WinnerDog);

        }

        private void MoveChien(Chien chien, int maxDistance)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0; // Valeur de départ
            animation.To = maxDistance; // Valeur finale
            animation.Duration = TimeSpan.FromSeconds(10);
            animation.AccelerationRatio = 0.2;
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, chien.image);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
            storyboard.Begin();
        }

        private void UpdateEcusFromPersonne(int WinnerIndex)
        {
            for(int i = 0; i < personnes.Length; i++)
            {
                if (paris[i].Chien.Numero == WinnerIndex)
                {
                    personnes[i].UpdateWallet((paris[i].Mise * 2));
                }
            }
        }

        private void MaskNumericInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumeric(e.Text))
            {
                if(!(int.Parse(ecusNombre.Text + e.Text) <= 500))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }

            
        }

        private void MaskNumericInputChien(object sender, TextCompositionEventArgs e)
        {
            if (chienNombre.Text.Length >= 1)
            {
                e.Handled= true;
            }
            else
            {
                if (TextIsNumeric(e.Text))
                {
                    if (!(int.Parse(e.Text) >= 1 && int.Parse(e.Text) <= chiens.Length))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = !TextIsNumeric(e.Text);
                }
            }

            

        }

        private void MaskNumericPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string input = (string)e.DataObject.GetData(typeof(string));
                if (!TextIsNumeric(input)) e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool TextIsNumeric(string input)
        {
            return input.All(c => Char.IsDigit(c) || Char.IsControl(c));
        }

        private void StartRaceButton_Click(object sender, RoutedEventArgs e)
        {

            if (!IsRaceStarted)
            {
                bool canStartRace = true;

                for (int i = 0; i < personnes.Length; i++)
                {
                    if (paris[i].Personne.Nom == "")
                    {
                        canStartRace = false;
                    }
                }

                if (canStartRace)
                {
                    IsRaceStarted = true;

                    // désactiver les boutons
                    pariButton.IsEnabled = false;
                    StartRaceButton.IsEnabled = false;
                    ResetButton.IsEnabled = false;

                    GenerateRace();

                }
            }

        }

        private void RemoveEcuPersonne()
        {
            for(int i = 0; i < personnes.Length; i++)
            {
                personnes[i].UpdateWallet(- paris[i].Mise);
            }

            UpdateParieursPanel();
        }

        private async void EndRace(int winner)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            pariButton.IsEnabled = true;
            StartRaceButton.IsEnabled = true;
            ResetButton.IsEnabled = true;

            UpdateEcusFromPersonne(winner);
            UpdateParieursPanel();
            InitializePari();
            UpdateParieursState();
            IsRaceStarted = false;



        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
                InitializePari();
                InitializePersonne();
                ClearChien();
                InitializeChien();
                InitializeInterface();

                ecusNombre.Text = null;
                chienNombre.Text = null;
            
        }

        private void pariButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsRaceStarted)
            {
                if (IsNumeric(ecusNombre.Text))
                {
                    int ecus = int.Parse(ecusNombre.Text);
                    if (ecus >= 5 && personnes[CurrentPersonneSelected].Argent - ecus >= 0)
                    {
                        if (IsNumeric(chienNombre.Text))
                        {
                            int numeroChien = int.Parse(chienNombre.Text);

                            if (numeroChien >= 1 && numeroChien <= chiens.Length)
                            {
                                paris[CurrentPersonneSelected] = new Pari(personnes[CurrentPersonneSelected], chiens[numeroChien - 1], ecus);
                                UpdateParieursState();

                            }
                        }
                    }

                }
            }
      
        }

        private void RadioBob_Click(object sender, RoutedEventArgs e)
        {
            int PersonneIndex = ParieursPanel.Children.IndexOf((UIElement)sender);
            CurrentPersonneSelected = PersonneIndex;
            PersonneName.Text = personnes[CurrentPersonneSelected].Nom;
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out int _);
        }
    }
}
