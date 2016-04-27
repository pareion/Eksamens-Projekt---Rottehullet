using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Data
{
    class DBSQLFacade
    {
        private static IDBFacade _dbsqlFacade;
        public static IDBFacade HentDBSQLFacade()
        {
            if (_dbsqlFacade == null)
            {
                // Skal ændres til DBSQLFacade når vi bruger en rigtig database
                _dbsqlFacade = DBRamFacade.HentDbRamFacade();
            }
            return _dbsqlFacade;
        }
    }
}
