using modelisation;
using Sérieathon.Fenetre;
using Sérieathon.UC.main_window.Profile;
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

namespace Sérieathon.Information_Vues
{
    /// <summary>
    /// Logique d'interaction pour Suppression_confirmation_utilisateur.xaml
    /// </summary>
    public partial class Suppression_confirmation_utilisateur : Window
    {
        Manager TheManager => (App.Current as App).TheManager;

        public Suppression_confirmation_utilisateur()
        {
            InitializeComponent();
        }
        private void Annule_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Supprimer_Button_Click(object sender, RoutedEventArgs e)
        {
            //(App.Current as App).MainWindow.Close();
            //Seriathon.Close();
            Accueil main_window = new Accueil();
            main_window.Show();

            Close();
            TheManager.SupprimerUtilisateur();
            (App.Current as App).MainWindow.Close();
        }
    }


}
