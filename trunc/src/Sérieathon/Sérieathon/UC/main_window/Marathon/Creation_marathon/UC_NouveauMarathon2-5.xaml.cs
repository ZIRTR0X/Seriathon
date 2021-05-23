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
    /// Logique d'interaction pour UC_NouveauMarathon2_5.xaml
    /// </summary>
    public partial class UC_NouveauMarathon2_5 : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        public UC_NouveauMarathon2_5()
        {
            InitializeComponent();
        }
        private void NM2_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON1;
        }
        private void Film_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.GENREGLOBAL;
        }
        private void Serie_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.GENREGLOBAL;
        }
        private void Anime_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.GENREANIME;
        }
    }
    
}
