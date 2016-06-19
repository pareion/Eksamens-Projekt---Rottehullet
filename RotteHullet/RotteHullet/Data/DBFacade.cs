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
            EntityFrame
        }

        private static volatile IDBFacade _idbf = null;
      
        internal static void AngivDatabaseFacade(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.EntityFrame:
                    _idbf = DBEF.HentDBEFFacade();
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
