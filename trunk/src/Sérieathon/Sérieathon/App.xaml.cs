using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using modelisation;
using persistance.StubPersist;
using persistance.DataContract;
using Sérieathon.converter;

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // a modifer poru la version récente
        public ManagerOld MonManager { get; set; } = new ManagerOld();
        public NavNavBar NavNavBar { get; set; } = new NavNavBar();
        public NavProfil NavProfil { get; set; } = new NavProfil();
        public Manager TheManager { get; set; }

        

        public App()
        {
            TheManager = Manager.GetInstanceWithPersist(DataContract2XML.GetInstance());
            TheManager.ChargerDonnees();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            TheManager.SauvegarderDonnees();
        }
    }
}

