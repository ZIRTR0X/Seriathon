using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using modelisation;
using Sérieathon.converter;

namespace Sérieathon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager MonManager { get; set; } = new Manager();
        public NavNavBar NavNavBar { get; set; } = new NavNavBar();
        public App()
        {
           
        }
    }
}

