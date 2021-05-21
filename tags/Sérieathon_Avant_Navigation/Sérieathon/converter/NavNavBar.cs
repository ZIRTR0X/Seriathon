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
using Sérieathon.UC.main_window.Marathon.Profile;

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
            NEWMARATHON3,
            NEWMARATHON4,
            NEWMARATHON5
        }

        public static Dictionary<Etat, Func<UserControl>> FactoryUC = new Dictionary<Etat, Func<UserControl>>
        {
            [Etat.ACCUEIL] = () => new UC_accueil(),
            [Etat.MARATHON] = () => new UC_NouveauMarathon1_5(),
            [Etat.PROFIL] = () => new UC_Profile(),
            [Etat.NEWMARATHON2] = () => new UC_NouveauMarathon2_5(),
            [Etat.NEWMARATHON1] = () => new UC_NouveauMarathon1_5(),
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

        public NavNavBar()
        {
            EtatCourant = Etat.ACCUEIL;
        }

        //public const string Uc_accueil = "Accueil";
        //public const string Uc_marathon = "Marathon";
        //public const string Uc_profil = "Profil";


        //public ReadOnlyDictionary<string, Func<UserControl>> WindowParts { get; private set; }

        //Dictionary<string, Func<UserControl>> windowParts = new Dictionary<string, Func<UserControl>>()
        //{
        //    [Uc_accueil] = () => new UC_accueil(),
        //    [Uc_marathon] = () => new UC_Marathon(),
        //    [Uc_profil] = () => new UC_Profile(),
        //};

        //public NavNavBar()
        //{
        //    WindowParts = new ReadOnlyDictionary<string, Func<UserControl>>(windowParts);
        //    SelectedUserControlCreator = WindowParts.First();
        //}

        //public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreator //faire un func
        //{
        //    get => selectedUserControlCreator;

        //    set
        //    {
        //        if (selectedUserControlCreator.Equals(value)) return;
        //        selectedUserControlCreator = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public KeyValuePair<string, Func<UserControl>> selectedUserControlCreator;

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //public void NavigateTo(string windowsPartName)
        //{
        //    if (WindowParts.ContainsKey(windowsPartName))
        //    {
        //        SelectedUserControlCreator = WindowParts.Single(kvp => kvp.Key == windowsPartName);
        //    }
        //}
    }
}
