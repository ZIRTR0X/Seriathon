using modelisation;
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
using static modelisation.genres.GenreGlobal;
using modelisation.genres;
using modelisation.content;

namespace Sérieathon.UC.main_window.Profile
{
    /// <summary>
    /// Logique d'interaction pour UC_Profile_Statistique.xaml
    /// </summary>
    public partial class UC_Profile_Statistique : UserControl
    {
        Manager TheManager => (App.Current as App).TheManager;

        public string NBFilm { get; set; }
        public string NBSerie { get; set; }
        public string NBAnime { get; set; }

        public UC_Profile_Statistique()
        {
            InitializeComponent();
            TheManager.test();
            NombreCVVue();
            StatsGenresFavori();
            StatsRealisateursFavori();
            StatsTempsPasse();
        }

        /// <summary>
        /// Permet de mettre dans la grid le nombre de film, série et anime vue
        /// </summary>
        public void NombreCVVue()
        {
            int nBAnime = TheManager.UtilisateurCourant.NbAnimeVu;
            NBAnime = nBAnime.ToString();
            int nBFilm = TheManager.UtilisateurCourant.NbFilmVu;
            NBFilm = nBFilm.ToString();
            int nBSerie = TheManager.UtilisateurCourant.NbSerieVu;
            NBSerie = nBSerie.ToString();
            StatNbSerie.Text = NBSerie;
            StatNbFilm.Text = NBFilm;
            StatNbAnime.Text = NBAnime;
        }

        /// <summary>
        /// Permet de mettre dans le grid le nombre de mois, jours, heures et minutes passé à regarder
        /// des contenues vidéoludiques
        /// </summary>
        public void StatsTempsPasse()
        {
            int nbMois = TheManager.UtilisateurCourant.DureeMoisCVVu();
            int nbJours = TheManager.UtilisateurCourant.DureeJourCVVu();
            int nbHeures = TheManager.UtilisateurCourant.DureeHeureCVVu();
            int nbMinutes = TheManager.UtilisateurCourant.DureeMinuteCVVu();
            StatMois.Text = nbMois.ToString();
            StatJours.Text = nbJours.ToString();
            StatHeures.Text = nbHeures.ToString();
            StatMinutes.Text = nbMinutes.ToString();
        }

        /// <summary>
        /// Creer un item dans la listbox GenreFavorie contenant le genre déjà vue
        /// </summary>
        public void StatsGenresFavori()
        {
            int nbAventure = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(Aventure);
            int nbAction = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(GenreGlobal.Action);
            int nbSF = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(ScienceFiction);
            int nbHorreur = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(Horreur);
            int nbPolicier = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(Policier);
            int nbRomance = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(Romance);
            int nbFantastique = TheManager.UtilisateurCourant.GetNbGenreGlobalVu(Fantastique);

            int nbShonen = TheManager.UtilisateurCourant.GetNbGenreAnimeVu(Shonen);
            int nbShojo = TheManager.UtilisateurCourant.GetNbGenreAnimeVu(Shojo);
            int nbJosei = TheManager.UtilisateurCourant.GetNbGenreAnimeVu(Josei);
            int nbSeinen = TheManager.UtilisateurCourant.GetNbGenreAnimeVu(Seinen);

            if (nbAventure > 0) GenreFavorie.Items.Add("Aventure");
            if (nbAction > 0) GenreFavorie.Items.Add("Action");
            if (nbSF > 0) GenreFavorie.Items.Add("Science Fiction");
            if (nbHorreur > 0) GenreFavorie.Items.Add("Horreur");
            if (nbPolicier > 0) GenreFavorie.Items.Add("Policier");
            if (nbRomance > 0) GenreFavorie.Items.Add("Romance");
            if (nbFantastique > 0) GenreFavorie.Items.Add("Fantastique");

            if (nbShonen > 0) GenreFavorie.Items.Add("Shonen");
            if (nbShojo > 0) GenreFavorie.Items.Add("Shojo");
            if (nbJosei > 0) GenreFavorie.Items.Add("Josei");
            if (nbSeinen > 0) GenreFavorie.Items.Add("Seinen");
        }

        /// <summary>
        /// Permet de mettre dans la liste box les réalisateurs déjà vue
        /// </summary>
        public void StatsRealisateursFavori()
        {
           foreach(ContenuVideoludique c in TheManager.UtilisateurCourant.ListCVvuR)
            {
                string realisateur = c.Realisateur;
                RealisateurFavorie.Items.Add(realisateur);
            }
        }
    }
}
