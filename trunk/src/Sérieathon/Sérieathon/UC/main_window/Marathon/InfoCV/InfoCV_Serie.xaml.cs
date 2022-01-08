using modelisation;
using modelisation.content;
using modelisation.content.episodique;
using modelisation.langues;
using Sérieathon.Fenetre;
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

namespace Sérieathon.UC.main_window.Marathon.InfoCV
{
    /// <summary>
    /// Logique d'interaction pour InfoCV_Serie.xaml
    /// </summary>
    public partial class InfoCV_Serie : UserControl
    {
        Manager TheManager => (App.Current as App).TheManager;
        Serie Serie_Courant { get; set; }
        public InfoCV_Serie()
        {
            InitializeComponent();
            Serie_Courant = TheManager.SerieCourant;
            DataContext = Serie_Courant;
            TextBlockDate.Text = Date();
            TextBlockAudio.Text = Audio();
            TextBlockSousTitre.Text = SousTitres();
        }
        private string Date()
        {
            string date = null;
            int a = Serie_Courant.Date.Year;
            date = "Sortie en ";
            date += a.ToString();
            return date;
        }

        private string SousTitres()
        {
            string sousTitres = null;
            foreach (Langues a in Serie_Courant.SousTitresR)
            {
                sousTitres += a;
            }
            return sousTitres;
        }

        private string Audio()
        {
            string audio = null;
            foreach (Langues a in Serie_Courant.AudiosR)
            {
                audio += a;
            }
            return audio;
        }

        private void Streaming_Button_Click(object sender, RoutedEventArgs e)
        {
            new Streaming_Serie().ShowDialog();
        }
        private void Vue_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (CheckVu.IsChecked == true)
            {
                CheckVu.Content = "Vu";

                if (Serie_Courant is Anime a) { TheManager.UtilisateurCourant.AddCVvu(a); }

                else { TheManager.UtilisateurCourant.AddCVvu(Serie_Courant); }
            }

            else
            {
                CheckVu.Content = "Pas vu";
                TheManager.UtilisateurCourant.RemoveCVvu(Serie_Courant);
            }
        }
    }
}
