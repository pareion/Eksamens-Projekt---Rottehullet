using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain;
namespace RotteHullet.Data
{
    static class DBFacade
    {
        public enum DatabaseType
        {
            RamDatabase,
            SqlDatabase
        }

        private static volatile IDBFacade idbf = null;
        private static volatile IDBFacade _idbf = null;
      
        internal static void AngivDatabaseFacade(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.RamDatabase:
                    _idbf = DBRamFacade.HentDbRamFacade();
                    break;
                case DatabaseType.SqlDatabase:
                    _idbf = DBSQLFacade.HentDBSQLFacade();
                    break;
                default:
                    break;
            }
        }

        internal static IDBFacade HentDatabaseFacade()
        {
            return _idbf;
        }
    }
}
