using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ACT3BIS_Events
{
    /// <summary>
    /// Logique d'interaction pour logs.xaml
    /// </summary>
    public partial class logs : Window
    {
        public logs()
        {
            InitializeComponent();
        }
    }
    public class LogEntry
    {
        public float Timestamp { get; set; }
        public string System { get; set; }
        public string Message { get; set; }
    }
}
