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
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void Inscription_click(object sender, RoutedEventArgs e)
        {
            accueil_content_control.Content = new UC_accueil();

            Button button = sender as Button;
            button.Background = Brushes.Gray;
            button.IsEnabled = false;

            // Connexion_button.Background = Brushes.LightGray; 
            Connexion_button.IsEnabled = true;

        }

        private void Connexion_click(object sender, RoutedEventArgs e)
        {
            accueil_content_control.Content = new UC_connexion();

            // cast intelligent, null si cast non réussi sinon bouton
            Button button = sender as Button;
            button.Background = Brushes.Gray;
            button.IsEnabled = false;

            // Inscription_button.Background = Brushes.LightGray;
            Inscription_button.IsEnabled = true;

        }
    }
}
