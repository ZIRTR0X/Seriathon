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
using Sérieathon.UC.main_window.Marathon.marathon_windows;
using Sérieathon.converter;

namespace Sérieathon.UC.main_window
{
    /// <summary>
    /// Interaction logic for Seriathon.xaml
    /// </summary>
    public partial class Seriathon : Window
    {

        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        public Seriathon()
        {
            InitializeComponent();
            DataContext = NavNavBar;
        }
        

    }
}
