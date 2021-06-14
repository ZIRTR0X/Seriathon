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
using System.Windows.Shapes;

namespace Sérieathon.Information_Vues
{
    /// <summary>
    /// Logique d'interaction pour Connexion_erreur.xaml
    /// </summary>
    public partial class Connexion_erreur : Window
    {
        public Connexion_erreur()
        {
            InitializeComponent();
        }
        

        private void Continuer_bouton_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
