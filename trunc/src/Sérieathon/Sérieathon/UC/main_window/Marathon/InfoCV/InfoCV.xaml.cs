using modelisation;
using modelisation.content;
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
            TextBlockDate.Text = Film_Courant.Date.ToString();
            TextBlockAudio.Text = Film_Courant.AudiosR.ToString();

        }

        private void Streaming_Button_Click(object sender, RoutedEventArgs e)
        {
            new Streaming().ShowDialog();
        }
    }
}
