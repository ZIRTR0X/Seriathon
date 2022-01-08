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
using modelisation.genres;

namespace Sérieathon.UC.main_window.Marathon.Creation_marathon
{
    /// <summary>
    /// Logique d'interaction pour UC_NouveauMarathon3_5_FilmEtSerie.xaml
    /// </summary>
    public partial class UC_NouveauMarathon3_5_FilmEtSerie : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;

        Manager TheManager => (App.Current as App).TheManager;

        public UC_NouveauMarathon3_5_FilmEtSerie()
        {
            InitializeComponent();
            NavNavBar.GenrePrecedent = "Global";
        }

        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Action, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Horreur_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Horreur, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Romance_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Romance, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Fantastique_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Fantastique, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Policier_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Policier, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void ScienceFiction_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.ScienceFiction, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Aventure_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeGlobal(GenreGlobal.Aventure, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Genre_Global_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
        }
    }
}
