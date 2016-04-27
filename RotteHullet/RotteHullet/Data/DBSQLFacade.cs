using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Data
{
    class DBSQLFacade : IDBFacade
    {
        private static DBSQLFacade _dbsqlFacade;
        public static DBSQLFacade HentDBSQLFacade()
        {
            if (_dbsqlFacade == null)
            {
                _dbsqlFacade = new DBSQLFacade();
            }
            return _dbsqlFacade;
        }
    }
}
