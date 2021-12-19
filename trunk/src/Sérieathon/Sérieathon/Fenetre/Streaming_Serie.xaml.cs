using modelisation;
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

namespace Sérieathon.Fenetre
{
    /// <summary>
    /// Logique d'interaction pour Streaming_Serie.xaml
    /// </summary>
    public partial class Streaming_Serie : Window
    {
        Manager TheManager => (App.Current as App).TheManager;
        Uri Url { get; set; }
        public Streaming_Serie()
        {
            InitializeComponent();
            List<Uri> _ouRegarder = TheManager.SerieCourant.OuRegarder;
            foreach (Uri u in _ouRegarder)
            {
                Url = u;
            }
            VideoWebView.Source = Url;
        }
    }
}
