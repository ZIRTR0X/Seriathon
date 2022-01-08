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
using modelisation;
using Sérieathon.UC.main_window.Marathon.marathon_windows;
using Sérieathon.UC.main_window.Marathon.Profile;
using Sérieathon.converter;

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for UC_Menu_Nav.xaml
    /// </summary>
    public partial class UC_Menu_Nav : UserControl
    {


        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;

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
            NavNavBar.EtatCourant = NavNavBar.Etat.MARATHON;
        }

        private void profil_button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.PROFIL;
        }
    }
}
