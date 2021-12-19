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
    /// Logique d'interaction pour UC_NouveauMarathon4_5.xaml
    /// </summary>
    public partial class UC_NouveauMarathon4_5 : UserControl
    {

        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;

        public UC_NouveauMarathon4_5()
        {
            InitializeComponent();
        }

        private void NM4_Ajouter_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
        }
        private void NM4_Retour_Button_Click(object sender, RoutedEventArgs e)
        {
            if(NavNavBar.GenrePrecedent == "Global")
            {
                NavNavBar.EtatCourant = NavNavBar.Etat.GENREGLOBAL;
            }
            else
            {
                NavNavBar.EtatCourant = NavNavBar.Etat.GENREANIME;
            }
            
        }
        private void NM4_Continuer_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON5;
        }

    }
}
