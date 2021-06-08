using modelisation;
using modelisation.user;
using Sérieathon.Fenetre;
using Sérieathon.UC.main_window;
using System;
using System.Collections.Generic;
using System.Security;
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

namespace Sérieathon.UC.login_window
{
    /// <summary>
    /// Interaction logic for UC_inscription.xaml
    /// </summary>
    public partial class UC_inscription : UserControl
    {

        public Manager TheManager => (App.Current as App).TheManager;

        Utilisateur NouvelUtilisateur { get; set; }

        public UC_inscription()
        {
            InitializeComponent();

            NouvelUtilisateur = new Utilisateur();

            DataContext = TheManager;
        }

 
        private void Validation_inscription_click(object sender, RoutedEventArgs e)
        {
            Seriathon main_window = new Seriathon();
            main_window.Show();

            (App.Current as App).MainWindow.Close();
        }

        private void PasswordChangedEvent1(Object sender, RoutedEventArgs args)
        {
            SecureString securePassword = PasswordBox1.SecurePassword;
        }
        private void PasswordChangedEvent2(Object sender, RoutedEventArgs args)
        {
            SecureString securePassword2 = PasswordBox2.SecurePassword;
        }

    }
}
