using modelisation;
using modelisation.usefull_interfaces;
using Sérieathon.Information_Vues;
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

namespace Sérieathon.UC.main_window.Marathon.marathon_windows
{
    /// <summary>
    /// Logique d'interaction pour UC_Marathon.xaml
    /// </summary>
    public partial class UC_Marathon : UserControl
    {
        private Manager TheManager { get; set; } = (App.Current as App).TheManager;


        public UC_Marathon()
        {
            InitializeComponent();
            //DataContext = TheManager.UtilisateurCourant.MarathonPerso;
            //ListJournalifie = TheManager.UtilisateurCourant.MarathonPerso.ListContenuJournalifieR;
            DataContext = this;

            // au cas où il y a des éléments déjà présent
            content_marathon_wp.Children.Clear();
            int i = 1;
            foreach (List<IEstAjoutableAuMarathon> l in TheManager.UtilisateurCourant.MarathonPerso.ListContenuJournalifieR) {
                content_marathon_wp.Children.Add(new UC_Marathon_Jour(l, i));
                ++i;
            }

        }

        private void Supprimer_button_click(object sender, RoutedEventArgs e)
        {
            (new Suppression_confirmation()).ShowDialog();
        }
    }
}
