using modelisation;
using modelisation.content;
using modelisation.content.episodique;
using modelisation.langues;
using Sérieathon.Fenetre;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Sérieathon.UC.main_window.Marathon.InfoCV
{
    /// <summary>
    /// Logique d'interaction pour InfoCV.xaml
    /// </summary>
    public partial class InfoCV : UserControl
    {
        Manager TheManager => (App.Current as App).TheManager;
        Film Film_Courant { get; set; }
        public InfoCV()
        {
            InitializeComponent();
            Film_Courant = TheManager.FilmCourant;
            DataContext = Film_Courant;
            TextBlockDate.Text = Date();
            TextBlockAudio.Text = Audio();
            TextBlockActeur.Text = Acteur();
            TextBlockSousTitre.Text = SousTitres();

        }
        private string Date()
        {
            string date = null;
            int a = Film_Courant.Date.Year;
            date = "Sortie en ";
            date += a.ToString();
            return date;
        }

        private string SousTitres()
        {
            string sousTitres = null;
            foreach (Langues a in Film_Courant.SousTitresR)
            {
                sousTitres += a;
            }
            return sousTitres;
        }

        private string Audio()
        {
            string audio = null;
            foreach (Langues a in Film_Courant.AudiosR)
            {
                audio += a;
            }
            return audio;
        }

        private string Acteur()
        {
            string acteur = null;
            foreach (string a in Film_Courant.ActeursR)
            {
                acteur += a;
            }
            return acteur;
        }

        private void Streaming_Button_Click(object sender, RoutedEventArgs e)
        {
            new Streaming().ShowDialog();
        }
        private void Vue_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (CheckVu.IsChecked == true)
            {
                CheckVu.Content = "Vu";
                TheManager.UtilisateurCourant.AddCVvu(TheManager.FilmCourant);
            }

            else
            {
                CheckVu.Content = "Pas vu";
                TheManager.UtilisateurCourant.RemoveCVvu(TheManager.FilmCourant);
            }

        }
    }
}
