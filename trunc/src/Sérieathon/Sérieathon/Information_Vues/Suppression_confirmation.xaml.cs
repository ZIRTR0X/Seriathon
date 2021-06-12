using modelisation;
using Sérieathon.converter;
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
using modelisation.user;

namespace Sérieathon.Information_Vues
{
    /// <summary>
    /// Interaction logic for Suppression_confirmation.xaml
    /// </summary>
    public partial class Suppression_confirmation : Window
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        Manager TheManager => (App.Current as App).TheManager;
        public Suppression_confirmation()
        {
            InitializeComponent();
        }

        private void Annule_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Supprimer_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.ACCUEIL;
            TheManager.UtilisateurCourant.SupprimerMarathon();
            Close();
        }
    }
}
