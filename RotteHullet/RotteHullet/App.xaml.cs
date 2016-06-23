using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RotteHullet.Data;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.EntityFrame);
            Domain.UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger();
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            RotteHullet.Data.DBFacade.HentDatabaseFacade().Terminate();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
