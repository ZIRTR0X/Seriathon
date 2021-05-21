using Sérieathon.UC.main_window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for UC_inscription.xaml
    /// </summary>
    public partial class UC_inscription : UserControl
    {
        public UC_inscription()
        {
            InitializeComponent();
        }

 
        private void Validation_inscription_click(object sender, RoutedEventArgs e)
        {
            Seriathon main_window = new Seriathon();
            main_window.Show();

            (App.Current as App).MainWindow.Close();
        }

       
    }
}
