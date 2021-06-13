using modelisation.content;
using modelisation.content.episodique;
using modelisation.usefull_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour UC_Marathon_Jour.xaml
    /// </summary>
    public partial class UC_Marathon_Jour : UserControl
    {

        public List<Film> ListFilm { get; private set; }
        public List<Episode> ListEpisode { get; private set; }

        public UC_Marathon Uc { get; private set; }

        public UC_Marathon_Jour()
        {

            InitializeComponent();


            DataContext = this;
        }

        public UC_Marathon_Jour(IEnumerable<IEstAjoutableAuMarathon> l, UC_Marathon uc)
        {
            InitializeComponent();
            Uc = uc;

            TriListes(l);

            DataContext = this;
        }

        public void TriListes(IEnumerable<IEstAjoutableAuMarathon> l)
        {
            List<IEstAjoutableAuMarathon> copie = new List<IEstAjoutableAuMarathon>(l);

            ListFilm = new List<Film>(copie.Where(e => e is Film).Cast<Film>());
            ListEpisode = new List<Episode>(copie.Where(e => e is Episode).Cast<Episode>());
        }
    }
}
