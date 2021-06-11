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

            if (string.IsNullOrWhiteSpace(NomMarathon.Text)) { (new CreationMarathon_erreur1()).ShowDialog(); return; }
            if (string.IsNullOrWhiteSpace(Nbjours)) { (new CreationMarathon_erreur2()).ShowDialog(); return; }
            if (string.IsNullOrWhiteSpace(NBheures)) { (new CreationMarathon_erreur3()).ShowDialog(); return; }

            switch (Nbjours)
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

            

            switch (NBheures)
            {
                case "1 heure": NombreHeure = 1; break;
                case "2 heures": NombreHeure = 2; break;
                case "3 heures": NombreHeure = 3; break;
                case "4 heures": NombreHeure = 4; break;
                case "5 heures": NombreHeure = 5; break;
                case "6 heures": NombreHeure = 6; break;
                case "7 heures": NombreHeure = 7; break;
                case "8 heures": NombreHeure = 8; break;
                case "9 heures": NombreHeure = 9; break;
                case "10 heures": NombreHeure = 10; break;
                case "11 heures": NombreHeure = 11; break;
                case "12 heures": NombreHeure = 12; break;
                default: NombreHeure = 1; break;
            }

            TheManager.CreerMarathon1(NombreJour, NombreHeure);
            NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;

            /*if (!string.IsNullOrWhiteSpace(NomMarathon.Text))
            {
                if (!string.IsNullOrWhiteSpace(Nbjours))
                {
                    if (Nbjours == "1 jour")
                    {
                        NombreJour = 1;
                    }
                    else
                    {
                        if (Nbjours == "2 jours")
                        {
                            NombreJour = 2;
                        }
                        else
                        {
                            if (Nbjours == "3 jours")
                            {
                                NombreJour = 3;
                            }
                            else
                            {
                                if (Nbjours == "4 jours")
                                {
                                    NombreJour = 4;
                                }
                                else
                                {
                                    if (Nbjours == "5 jours")
                                    {
                                        NombreJour = 5;
                                    }
                                    else
                                    {
                                        if (Nbjours == "6 jours")
                                        {
                                            NombreJour = 6;
                                        }
                                        else
                                        {
                                            if (Nbjours == "7 jours")
                                            {
                                                NombreJour = 7;
                                            }
                                            else
                                            {
                                                if (Nbjours == "8 jours")
                                                {
                                                    NombreJour = 8;
                                                }
                                                else
                                                {
                                                    if (Nbjours == "9 jours")
                                                    {
                                                        NombreJour = 9;
                                                    }
                                                    else
                                                    {
                                                        if (Nbjours == "10 jours")
                                                        {
                                                            NombreJour = 10;
                                                        }
                                                        else
                                                        {
                                                            if (Nbjours == "11 jours")
                                                            {
                                                                NombreJour = 11;
                                                            }
                                                            else
                                                            {
                                                                if (Nbjours == "12 jours")
                                                                {
                                                                    NombreJour = 12;
                                                                }
                                                                else
                                                                {
                                                                    if (Nbjours == "13 jours")
                                                                    {
                                                                        NombreJour = 13;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Nbjours == "2 semaines")
                                                                        {
                                                                            NombreJour = 14;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Nbjours == "3 semaines")
                                                                            {
                                                                                NombreJour = 21;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Nbjours == "4 semaines")
                                                                                {
                                                                                    NombreJour = 28;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }



                    if (!string.IsNullOrWhiteSpace(NBheures))
                    {
                        if (NBheures == "1 heure")
                        {
                            NombreHeure = 1;
                        }
                        else
                        {
                            if (NBheures == "2 heures")
                            {
                                NombreHeure = 2;
                            }
                            else
                            {
                                if (NBheures == "3 heures")
                                {
                                    NombreHeure = 3;
                                }
                                else
                                {
                                    if (NBheures == "4 heures")
                                    {
                                        NombreHeure = 4;
                                    }
                                    else
                                    {
                                        if (NBheures == "5 heures")
                                        {
                                            NombreHeure = 5;
                                        }
                                        else
                                        {
                                            if (NBheures == "6 heures")
                                            {
                                                NombreHeure = 6;
                                            }
                                            else
                                            {
                                                if (NBheures == "7 heures")
                                                {
                                                    NombreHeure = 7;
                                                }
                                                else
                                                {
                                                    if (NBheures == "8 heures")
                                                    {
                                                        NombreHeure = 8;
                                                    }
                                                    else
                                                    {
                                                        if (NBheures == "9 heures")
                                                        {
                                                            NombreHeure = 9;
                                                        }
                                                        else
                                                        {
                                                            if (NBheures == "10 heures")
                                                            {
                                                                NombreHeure = 10;
                                                            }
                                                            else
                                                            {
                                                                if (NBheures == "11 heures")
                                                                {
                                                                    NombreHeure = 11;
                                                                }
                                                                else
                                                                {
                                                                    if (NBheures == "12 heures")
                                                                    {
                                                                        NombreHeure = 12;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        TheManager.CreerMarathon1(NombreJour, NombreHeure);
                        NavNavBar.EtatCourant = NavNavBar.Etat.NEWMARATHON2;
                    }
                    else
                    {
                        (new CreationMarathon_erreur3()).ShowDialog();
                    }
                }
                else
                {
                    (new CreationMarathon_erreur2()).ShowDialog();
                }
            }
            else
            {
                (new CreationMarathon_erreur1()).ShowDialog();
            }
            */
            
            
        }

    }
}
