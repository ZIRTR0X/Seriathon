using modelisation;
using modelisation.user;
using Sérieathon.converter;
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

namespace Sérieathon.UC.main_window.Marathon.Creation_marathon
{
    /// <summary>
    /// Logique d'interaction pour UC_NouveauMarathon1_5.xaml
    /// </summary>
    public partial class UC_NouveauMarathon1_5 : UserControl
    {

        public NavNavBar NavNavBar => (App.Current as App).NavNavBar;
        Manager TheManager => (App.Current as App).TheManager;
        string Nbjours { get; set; }
        string NBheures { get; set; }
        int NombreJour { get; set; }
        int NombreHeure { get; set; }

        public UC_NouveauMarathon1_5()
        {
            InitializeComponent();
            DataContext = this;
;
        }

        private void NM1_Next_Button_Click(object sender, RoutedEventArgs e)
        {

            Nbjours = NombreDeJour.Text;
            NBheures = TempsParJour.Text;

            if (string.IsNullOrWhiteSpace(NomMarathon.Text)) { new CreationMarathon_erreur1().ShowDialog(); return; }
            if (string.IsNullOrWhiteSpace(Nbjours)) { new CreationMarathon_erreur2().ShowDialog(); return; }
            if (string.IsNullOrWhiteSpace(NBheures)) { new CreationMarathon_erreur3().ShowDialog(); return; }

            NombreJour = Nbjours switch
            {
                "1 jour" => 1,
                "2 jours" => 2,
                "3 jours" => 3,
                "4 jours" => 4,
                "5 jours" => 5,
                "6 jours" => 6,
                "7 jours" => 7,
                _ => 1,
            };

            /* equivalent à 
             * switch (Nbjours)
            {
                case "1 jour": NombreJour = 1; break;
                case "2 jours": NombreJour = 2; break;
                case "3 jours": NombreJour = 3; break;
                case "4 jours": NombreJour = 4; break;
                case "5 jours": NombreJour = 5; break;
                case "6 jours": NombreJour = 6; break;
                case "7 jours": NombreJour = 7; break;
                case "8 jours": NombreJour = 8; break;
                case "9 jours": NombreJour = 9; break;
                case "10 jours": NombreJour = 10; break;
                case "11 jours": NombreJour = 11; break;
                case "12 jours": NombreJour = 12; break;
                case "13 jours": NombreJour = 13; break;
                case "2 semaines": NombreJour = 14; break;
                case "3 semaines": NombreJour = 21; break;
                case "4 semaines": NombreJour = 28; break;
                default: NombreJour = 1; break;
            }
            */

            NombreHeure = NBheures switch
            {
                "1 heure" => 1,
                "2 heures" => 2,
                "3 heures" => 3,
                "4 heures" => 4,
                "5 heures" => 5,
                _ => 1,
            };
            TheManager.CreerMarathon1(NombreJour, NombreHeure);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
        }

    }
}
