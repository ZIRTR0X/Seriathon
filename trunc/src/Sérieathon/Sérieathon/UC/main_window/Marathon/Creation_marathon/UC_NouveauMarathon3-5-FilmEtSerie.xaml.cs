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

namespace Sérieathon.UC.main_window.Marathon.Creation_marathon
{
    /// <summary>
    /// Logique d'interaction pour UC_NouveauMarathon3_5_FilmEtSerie.xaml
    /// </summary>
    public partial class UC_NouveauMarathon3_5_FilmEtSerie : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;

        

        public UC_NouveauMarathon3_5_FilmEtSerie()
        {
            InitializeComponent();
            NavNavBar.GenrePrecedent = "Global";
        }

        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Horreur_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Romance_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Fantastique_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Policier_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void ScienceFiction_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Aventure_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Tout_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Genre_Global_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
        }
    }
}
