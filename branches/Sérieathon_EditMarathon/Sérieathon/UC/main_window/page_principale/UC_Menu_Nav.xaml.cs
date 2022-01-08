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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sérieathon.UC.main_window.page_principale
{
    /// <summary>
    /// Logique d'interaction pour UC_Menu_Nav.xaml
    /// </summary>
    public partial class UC_Menu_Nav : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        Manager TheManager => (App.Current as App).TheManager;

        public UC_Menu_Nav()
        {
            InitializeComponent();
        }

        private void accueil_button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.ACCUEIL;
        }

        private void marathon_button_Click(object sender, RoutedEventArgs e)
        {
            if (TheManager.UtilisateurCourant.MarathonPerso == null)
            {
                NavNavBar.EtatCourant = NavNavBar.Etat.MARATHON;
            }
            else
            {
                NavNavBar.EtatCourant = NavNavBar.Etat.LEMARATHON;
            }
            
            
        }

        private void profil_button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.PROFIL;
        }
    }
}
