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

namespace ACT3_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] Numbers = new int[3];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculer(object sender, MouseButtonEventArgs e)
        {
            int index = 0;

            foreach(TextBox textbox in grid.Children.OfType<TextBox>())
            {
                    Numbers[index] = int.Parse(textbox.ToString());
            }
              
        }

        private void VerifTextInput(TextBox textbox)
        {
             if(textbox.Text != "," && !EstEntier(textbox))
            {
                
            }
        }

        private bool EstEntier(TextBox textbox)
        {
            return int.TryParse(textbox.Text.ToString(), out _);
        }
    }
}
