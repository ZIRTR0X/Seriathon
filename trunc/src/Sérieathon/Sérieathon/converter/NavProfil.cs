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
    public class NavProfil : INotifyPropertyChanged
    {
        public enum Etat
        {
            STATISTIQUE,
            VUE
        }

        public static Dictionary<Etat, Func<UserControl>> ProfilUC = new Dictionary<Etat, Func<UserControl>>
        {
            [Etat.VUE] = () => new UC_Profile_Vue(),
            [Etat.STATISTIQUE] = () => new UC_Profile_Statistique(),

        };

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Etat EtatCourant
        {
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

        public NavProfil()
        {
            EtatCourant = Etat.VUE;
        }


    }
}
