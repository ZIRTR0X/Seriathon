using modelisation;
using modelisation.content;
using modelisation.content.episodique;
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

namespace Sérieathon.UC.main_window.Profile
{
    /// <summary>
    /// Logique d'interaction pour UC_Profile_Vue.xaml
    /// </summary>
    public partial class UC_Profile_Vue : UserControl
    {
        Manager TheManager => (App.Current as App).TheManager;
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        List<Film> ListFilmsVues { get; set; }
        List<Serie> ListSeriesVues { get; set; }
        List<Anime> ListAnimesVues { get; set; }
        public UC_Profile_Vue()
        {
            InitializeComponent();
            ListFilmsVues = new List<Film>(TheManager.UtilisateurCourant.GetListFilmsVu());
            ListSeriesVues = new List<Serie>(TheManager.UtilisateurCourant.GetListSeriesVu());
            ListAnimesVues = new List<Anime>(TheManager.UtilisateurCourant.GetListAnimeVu());
            ListBoxFilm.DataContext = ListFilmsVues;
            ListBoxSerie.DataContext = ListSeriesVues;
            ListBoxAnime.DataContext = ListAnimesVues;
        }

        private void ListBoxFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = (ListBoxFilm.SelectedItem as Film).Titre;

            foreach (Film f in ListFilmsVues)
            {
                if(f.Titre == b)
                {
                    TheManager.FilmCourants(f);
                    NavNavBar.EtatCourant = NavNavBar.Etat.INFOCV;
                }
            }
        }

        private void ListBoxSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = (ListBoxSerie.SelectedItem as Serie).Titre;

            foreach (Serie s in ListSeriesVues)
            {
                if (s.Titre == b)
                {
                    TheManager.SerieCourants(s);
                    NavNavBar.EtatCourant = NavNavBar.Etat.INFOCVSERIE;
                }
            }
        }

        private void ListBoxAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = (ListBoxAnime.SelectedItem as Anime).Titre;

            foreach (Anime a in ListAnimesVues)
            {
                if (a.Titre == b)
                {
                    TheManager.SerieCourants(a);
                    NavNavBar.EtatCourant = NavNavBar.Etat.INFOCVSERIE;
                }
            }
        }
        //private void ListBoxFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string b = (ListBoxFilm.SelectedItem as Episode).Nom;

        //    foreach (Episode e in ListBoxSerie)
        //    {
        //        if (e.Nom == c)
        //        {
        //            TheManager.SerieCourants(e);
        //            NavNavBar.EtatCourant = NavNavBar.Etat.INFOCV;
        //        }
        //    }
        //}
        //private void ListBoxFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string b = (ListBoxFilm.SelectedItem as Film).Titre;

        //    foreach (Film f in ListFilmsVues)
        //    {
        //        if (f.Titre == b)
        //        {
        //            TheManager.FilmCourants(f);
        //            NavNavBar.EtatCourant = NavNavBar.Etat.INFOCV;
        //        }
        //    }
        //}

    }
}
