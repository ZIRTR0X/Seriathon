using modelisation;
using modelisation.user;
using Sérieathon.Fenetre;
using Sérieathon.Information_Vues;
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
using static modelisation.user.Utilisateur;

namespace Sérieathon.UC.login_window
{
    /// <summary>
    /// Interaction logic for UC_inscription.xaml
    /// </summary>
    public partial class UC_inscription : UserControl
    {
        Manager TheManager => (App.Current as App).TheManager;

        Utilisateur NouvelUtilisateur { get; set; }
        string Mdp2 { get; set; }
        string Mdp1 { get; set; }


        public UC_inscription()
        {
            InitializeComponent();

            NouvelUtilisateur = new Utilisateur();

            DataContext = NouvelUtilisateur;

            DateTime Date2 = DateTime.Today.AddYears(-10);
            DatedeNaissanceDataPicker.DisplayDateStart = new DateTime(1900, 1, 1);
            //DatedeNaissanceDataPicker.DisplayDate = new DateTime(2009, 1, 1);
            DatedeNaissanceDataPicker.DisplayDateEnd = Date2;
        }

        private void SelectedPasswordBox1(Object sender, RoutedEventArgs args)
        {
            Mdp1 = PasswordBox1.SelectedText;
        }

        private void SelectedPasswordBox2(Object sender, RoutedEventArgs args)
        {
            Mdp2 = PasswordBox1.SelectedText;
        }


        /// <summary>
        /// Cette fonction permet de vérifier si le mdp1 est égale au mdp2, si c'est le cas le mdp1 est mit au Password de nouvelUtilisateur et
        /// la page actuel se ferme et ouvre la page suivante. Sinon la page de erreur d'inscription s'ouvre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validation_inscription_click(object sender, RoutedEventArgs e)
        {
           Mdp1 = PasswordBox1.Text;
           Mdp2 = PasswordBox2.Text;
            string emailtextbox = textbox_email.Text;
            string pseudotextbox = textbox_pseudo.Text;
            string comboboxgenre = combobox_genre.Text;
            
            //DateTime DatedeNaissance = DatedeNaissanceDataPicker.SelectedDate;
            //DateTime Date1 = new DateTime(1900, 1, 1);
            //DateTime Date2 = DateTime.Today.AddYears(-10);
            ////DateTime Date2 = new DateTime(10, 0, 0);
            ////TimeSpan Date3 = DateTime.Today.Subtract(Date2);
            ////DateTime Date4 = new DateTime(0, 0, 0);
            ////DateTime Date5 = new DateTime(0, 0, 0);
            //DatedeNaissanceDataPicker.BlackoutDates.Add(new CalendarDateRange(Date2, DateTime.Today));
            //DatedeNaissanceDataPicker.DisplayDateStart = new DateTime(1900, 1, 1);
            //DatedeNaissanceDataPicker.DisplayDateEnd = Date2;

            if (!string.IsNullOrWhiteSpace(pseudotextbox))
            {
                if (!string.IsNullOrWhiteSpace(emailtextbox))
                {
                    if (!string.IsNullOrWhiteSpace(comboboxgenre))
                    {
                        if (!string.IsNullOrWhiteSpace(Mdp1) && !string.IsNullOrWhiteSpace(Mdp2))
                        {
                            if (Mdp1.Equals(Mdp2))
                            {
                                NouvelUtilisateur.Password = Mdp1;
                                if (TheManager.AjouterUtilisateur(NouvelUtilisateur))
                                {
                                    Seriathon main_window = new Seriathon();
                                    main_window.Show();

                                    (App.Current as App).MainWindow.Close();
                                }
                                else
                                {
                                    (new Inscription_erreur2()).ShowDialog();
                                }
                            }
                            else
                            {
                                (new Inscription_erreur()).ShowDialog();
                            }
                        }
                        else
                        {
                            (new Inscription_erreur3()).ShowDialog();
                        }
                    }
                    else
                    {
                        (new Inscription_erreur5()).ShowDialog();
                    }
                }
                else
                {
                    (new Inscription_erreur4()).ShowDialog();
                }
            }
            else
            {
                (new Inscription_erreur6()).ShowDialog();
            }

            

            
            

         
        }

    }
}
