using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using modelisation;
using Sérieathon.UC.main_window.Marathon.marathon_windows;
using Sérieathon.UC.main_window.Profile;
using Sérieathon.UC.main_window.Marathon.Creation_marathon;
using Sérieathon.UC.main_window.page_principale;

namespace Sérieathon.converter
{
    public class NavNavBar : INotifyPropertyChanged
    {
        public enum Etat
        {
            ACCUEIL,
            MARATHON,
            PROFIL,
            NEWMARATHON1,
            NEWMARATHON2,
            NEWMARATHON4,
            NEWMARATHON5,
            GENREANIME,
            GENREGLOBAL,
            LEMARATHON
        }

        public static Dictionary<Etat, Func<UserControl>> FactoryUC = new Dictionary<Etat, Func<UserControl>>
        {
            [Etat.ACCUEIL] = () => new UC_accueil(),
            [Etat.MARATHON] = () => new UC_NouveauMarathon1_5(),
            [Etat.PROFIL] = () => new UC_Profile(),
            [Etat.NEWMARATHON2] = () => new UC_NouveauMarathon2_5(),
            [Etat.NEWMARATHON1] = () => new UC_NouveauMarathon1_5(),
            [Etat.NEWMARATHON4] = () => new UC_NouveauMarathon4_5(),
            [Etat.NEWMARATHON5] = () => new UC_NouveauMarathon5_5(),
            [Etat.GENREANIME] = () => new UC_NouveauMarathon3_5_Anime(),
            [Etat.GENREGLOBAL] = () => new UC_NouveauMarathon3_5_FilmEtSerie(),
            [Etat.LEMARATHON] = () => new UC_Marathon(),
        };

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Etat EtatCourant {
            get => etatCourant;
            set
            {
                if (value != etatCourant)
                {
                    etatCourant = value;
                    OnPropertyChanged();
                }
            }
        }
        private Etat etatCourant;

        public string GenrePrecedent
        {
            get => genrePrecedent;
            set
            {
                if (value != genrePrecedent)
                {
                    genrePrecedent = value;
                }
            }
        }
        private string genrePrecedent = "";

        public NavNavBar()
        {
            EtatCourant = Etat.ACCUEIL;
        }

 
    }
}
