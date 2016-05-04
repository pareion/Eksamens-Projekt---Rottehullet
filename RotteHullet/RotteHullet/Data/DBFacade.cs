using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain;
namespace RotteHullet.Data
{
    class DBFacade
    {

        private static volatile IDBFacade idbf = null;
        internal static void AngivDatabaseFacade(DatabaseType databaseType) {
            switch (databaseType)
            {
                case DatabaseType.RamDatabase:
                    idbf = DBRamFacade.HentDbRamFacade();
                    break;
                case DatabaseType.SqlDatabase:
                    idbf = DBSQLFacade.HentDBSQLFacade();
                    break;

                default:
                    break;
            }
        }

        internal static IDBFacade HentDatabaseFacade() {
            return idbf;
        }
    }
}
