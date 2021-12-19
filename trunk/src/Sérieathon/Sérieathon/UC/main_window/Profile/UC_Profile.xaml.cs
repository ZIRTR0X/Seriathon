using Sérieathon.converter;
using Sérieathon.Information_Vues;
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

namespace Sérieathon.UC.main_window.Profile
{
    /// <summary>
    /// Logique d'interaction pour UC_Profile.xaml
    /// </summary>
    public partial class UC_Profile : UserControl
    {
        public NavProfil NavProfil => (App.Current as App).NavProfil;

        public UC_Profile()
        {
            InitializeComponent();
            DataContext = NavProfil;
        }

        private void Profil_Vue_Button_Click(object sender, RoutedEventArgs e)
        {
            NavProfil.EtatCourant = NavProfil.Etat.VUE;
        }

        private void Profil_Statistiques_Button_Click(object sender, RoutedEventArgs e)
        {
            NavProfil.EtatCourant = NavProfil.Etat.STATISTIQUE;
        }

            private void Supprimer_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Suppression_confirmation_utilisateur()).ShowDialog();
        }
    }
}
