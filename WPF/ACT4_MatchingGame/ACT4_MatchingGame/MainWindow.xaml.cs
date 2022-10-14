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

namespace ACT4_MatchingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[,] cartes = new TextBlock[4, 4];
        public MainWindow()
        {
            InitializeComponent();
            InitializeInterface();
        }
        private void InitializeInterface()
        {
            for (int i = 0; i < 4; i++)
            {
                ColumnDefinition Column = new ColumnDefinition();
                grid.ColumnDefinitions.Add(Column);

                RowDefinition Row = new RowDefinition();
                grid.RowDefinitions.Add(Row);
            }
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    cartes[i, j] = new TextBlock();
                    cartes[i, j].Text = "?";
                    cartes[i, j].FontSize = 25;
                    SetTextBlock(cartes[i, j], null);
                    Grid.SetColumn(cartes[i, j], j);
                    Grid.SetRow(cartes[i, j], i);
                    grid.Children.Add(cartes[i,j]);
                }
            }
        }

        private void SetTextBlock(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
