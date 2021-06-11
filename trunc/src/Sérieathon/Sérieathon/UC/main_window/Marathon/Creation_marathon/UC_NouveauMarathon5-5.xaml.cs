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

namespace Sérieathon.UC.main_window.Marathon.Creation_marathon
{
    /// <summary>
    /// Logique d'interaction pour UC_NouveauMarathon5_5.xaml
    /// </summary>
    public partial class UC_NouveauMarathon5_5 : UserControl
    {
        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        Manager TheManager => (App.Current as App).TheManager;
        public UC_NouveauMarathon5_5()
        {
            InitializeComponent();
            DataContext = TheManager;
        }

        private void NM5_Continuer_Button_Click(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.LEMARATHON;
        }

        private void Nm5_Retour_Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON4;
        }
    }
}
