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

namespace ACT7_Course
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personne[] personnes = new Personne[3];
        Chien[] chiens = new Chien[4];
        public MainWindow()
        {
            InitializeComponent();
            InitializePersonne();
            InitializeChien();
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
            for (int i = 0; i < 3; i++)
            {
                chiens[i] = new Chien(i, new Image());
            }
        }

        private void InitializeInterface()
        {
            BitmapImage imageChien = new BitmapImage();
            imageChien.BeginInit();
            imageChien.UriSource = new Uri("/dog.png", UriKind.Relative);
            imageChien.EndInit();

            foreach (Chien chien in chiens)
            {
                Image image = new Image();
                image.Source = imageChien;
                image.Stretch = System.Windows.Media.Stretch.None;
                CanvasChiens.Children.Add(image);
            }
        }

        private void MoveChien()
        {

        }
    }
}
