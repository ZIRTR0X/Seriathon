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
using static modelisation.genres.GenreAnime;

namespace Sérieathon.UC.main_window.Marathon.Creation_marathon
{
    /// <summary>
    /// Logique d'interaction pour UC_NouveauMarathon3_5_Anime.xaml
    /// </summary>
    public partial class UC_NouveauMarathon3_5_Anime : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        Manager TheManager => (App.Current as App).TheManager;
        public UC_NouveauMarathon3_5_Anime()
        {
            InitializeComponent();
            NavNavBar.GenrePrecedent = "Anime";
        }
        private void Shojo_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeAnime(Shojo, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Josei_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeAnime(Josei, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Shonen_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeAnime(Shonen, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Seinen_Button_Click(object sender, RoutedEventArgs e)
        {
            TheManager.UtilisateurCourant.MarathonPerso.AddThemeAnime(Seinen, TheManager);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
        private void Genre_Anime_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
        }
    }
}
