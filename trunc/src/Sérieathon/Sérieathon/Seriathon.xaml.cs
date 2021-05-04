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

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for Seriathon.xaml
    /// </summary>
    public partial class Seriathon : Window
    {
        public Seriathon()
        {
            InitializeComponent();
        }
        private void Marathon_Click(object sender, RoutedEventArgs e)
        {
            content_control_page_accueil.Content = new UC_NouveauMarathon1_5();
        }
        private void Suivant_NM1(object sender, RoutedEventArgs e)
        {
            content_control_page_accueil.Content = new UC_NouveauMarathon2_5();
        }
        private void Retour_NM1(object sender, RoutedEventArgs e)
        {
            content_control_page_accueil.Content = new UC_accueil();
        }
    }

    
}
