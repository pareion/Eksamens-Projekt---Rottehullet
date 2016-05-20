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
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            RotteHullet.Data.DBSQLFacade.HentDBSQLFacade().Terminate();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
