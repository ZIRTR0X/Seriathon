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
    /// Interaction logic for UC_connexion.xaml
    /// </summary>
    public partial class UC_connexion : UserControl
    {
        public UC_connexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evenement de click du bouton Validation, ayant pour effet de fermer la page "Accueil.xaml", et d'ouvrir "Seriathon.xaml"
        /// </summary>
        /// <param name="sender"></param> Objet envoyant l'évènement, normalement de classe Button, originellement x:Name Validation_button
        /// <param name="e"></param>
        private void Validation_connexion_click(object sender, RoutedEventArgs e)
        {
            Seriathon main_window = new Seriathon();
            main_window.Show();

            (App.Current as App).MainWindow.Close();

        }
    }
}
