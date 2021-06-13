using modelisation;
using modelisation.content;
using modelisation.genres;
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
    /// Interaction logic for UC_Marathon_Film.xaml
    /// </summary>
    public partial class UC_Marathon_Film : UserControl
    {
        /// <summary>
        /// Manager de mon app
        /// </summary>
        Manager TheManager { get; set; } = (App.Current as App).TheManager;
        //Film Film_affiche { get; set; }
        
        /// <summary>
        /// DependancyProperty pour connaitre le film courant
        /// </summary>
        public Film Film_affiche
        {
            get { return (Film)GetValue(Film_afficheProperty); }
            set { SetValue(Film_afficheProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Film_afficheProperty =
            DependencyProperty.Register("Film_affiche", typeof(Film), typeof(UC_Marathon_Film), new PropertyMetadata(
                                    new Film("t", new DateTime(0), new TimeSpan(0), "t", new List<GenreGlobal> { GenreGlobal.Aventure}, "void.jpg", new List<string> { "toto"})
                                        ));

        //public bool CheckVuActivation
        //{
        //    get => _checkVuActivation


        //    private set
        //    {

        //    }
        //}
        //private bool _checkVuActivation;

        public UC_Marathon_Film()
        {
            InitializeComponent();
        }

        /// <summary>
        /// permet de définir si la vue est cochée ou non
        /// </summary>
        private bool CheckVuActivation()
        {
            if (TheManager.UtilisateurCourant.AVu(Film_affiche)) { return true; }
            else { return false; }
        }

        /// <summary>
        /// permet de switch la CheckBox d'état, et de supprimer ou ajouter de la liste des ListCVVu de l'utilisateur courant le film
        /// </summary>
        /// <param name="sender">objet envoyant l'évenement, ici un CheckBox</param>
        /// <param name="e"></param>
        private void Vue_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (CheckVu.IsChecked == true)
            {
                CheckVu.Content = "Vu";
                TheManager.UtilisateurCourant.AddCVvu(Film_affiche);
            }

            else
            {
                CheckVu.Content = "Pas vu";
                TheManager.UtilisateurCourant.RemoveCVvu(Film_affiche);
            }
        }
    }
}
