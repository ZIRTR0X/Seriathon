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
using modelisation.content.episodique;


namespace Sérieathon.UC.main_window.Marathon.marathon_windows
{
    /// <summary>
    /// Logique d'interaction pour UC_Marathon_Episode.xaml
    /// </summary>
    public partial class UC_Marathon_Episode : UserControl
    {

        public Manager TheManager { get; set; } = (App.Current as App).TheManager;

        public Episode Episode_Affiche
        {
            get { return (Episode)GetValue(Episode_AfficheProperty); }
            set { SetValue(Episode_AfficheProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Episode_Affiche.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Episode_AfficheProperty =
            DependencyProperty.Register("Episode_Affiche", typeof(Episode), typeof(UC_Marathon_Episode), new PropertyMetadata(new Episode("e", 0, new DateTime(0), new TimeSpan(0))));

        public UC_Marathon_Episode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// permet de définir si la vue est cochée ou non
        /// </summary>
        private void CheckVuActivation()
        {
            Serie s = Episode.RecupRefSerie(Episode_Affiche);

            if (TheManager.UtilisateurCourant.AVu(s)) { CheckVu.IsChecked = true; CheckVu.Content = "Vu"; }
            else { CheckVu.IsChecked = false; CheckVu.Content = "Pas vu"; }
        }

        private void Vue_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Serie s = Episode.RecupRefSerie(Episode_Affiche);

            if (CheckVu.IsChecked == true)
            {
                CheckVu.Content = "Vu";

                if(s is Anime a) { TheManager.UtilisateurCourant.AddCVvu(a); }

                else { TheManager.UtilisateurCourant.AddCVvu(s); }
            }

            else
            {
                CheckVu.Content = "Pas vu";
                TheManager.UtilisateurCourant.RemoveCVvu(s);
            }

        }
    }
}
