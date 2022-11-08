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
    }
}
