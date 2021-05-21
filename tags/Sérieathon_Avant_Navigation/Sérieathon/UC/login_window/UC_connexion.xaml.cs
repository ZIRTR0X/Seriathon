using Sérieathon.UC.main_window;
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

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for UC_connexion.xaml
    /// </summary>
    public partial class UC_connexion : UserControl
    {

        public bool Visibility_icon { get; private set; }

        public UC_connexion()
        {
            InitializeComponent();

            Visibility_icon = false;

            Image_View_Password.Source = new BitmapImage(new Uri("../../image/view.png", UriKind.Relative));

        }

        /// <summary>
        /// Evenement de click du bouton Validation, ayant pour effet de fermer la page "Accueil.xaml", et d'ouvrir "Seriathon.xaml"
        /// </summary>
        /// <param name="sender"></param> Objet envoyant l'évènement, normalement de classe Button, originellement x:Name Validation_button
        /// <param name="e"></param>

        private void Validation_connexion_click(object sender, RoutedEventArgs e)
        {
            Seriathon main_window = new Seriathon();
            main_window.Show();

            (App.Current as App).MainWindow.Close();

        }
        
        //private void View_Password_Click(object sender, RoutedEventArgs e)
        //{
        //    Image_View_Password.Source = BitmapImage(new Uri(@"/image/visibility.png"));

        //}
        
        /// <summary>
        /// Event de click permettant de changer l'icone de visibilitée d'un oeil visible à un barré
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_Password_Click(object sender, RoutedEventArgs e)
        {
            
            if(Visibility_icon)
            {
                Image_View_Password.Source = new BitmapImage(new Uri("../../image/view.png", UriKind.Relative));
                Visibility_icon = false;
            } else
            {
                Image_View_Password.Source = new BitmapImage(new Uri("../../image/visibility.png", UriKind.Relative));
                Visibility_icon = true; 
            }
            
        }
        

    }
}
