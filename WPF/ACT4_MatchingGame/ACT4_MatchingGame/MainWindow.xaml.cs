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
            FontSize = 36;

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
                    cartes[i, j].MouseDown += new MouseButtonEventHandler(SetTextBlock);
                    Grid.SetColumn(cartes[i, j], j);
                    Grid.SetRow(cartes[i, j], i);
                    grid.Children.Add(cartes[i,j]);
                    cartes[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    cartes[i, j].VerticalAlignment = VerticalAlignment.Center;
                }
            }
        }

        private void SetTextBlock(object sender, MouseButtonEventArgs e)
        {
            ((TextBlock)sender).Text = "X";
        }
    }
}
