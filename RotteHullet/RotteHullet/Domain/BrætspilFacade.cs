using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;

namespace RotteHullet.Domain
{
    /*
        Private variabler skrives sådan: _myVariable
        Private variabler har properties
        Private metoder med småt - Public med stort
        Brackets {} ved metode, får sin egen linje.
 
     */
    class BrætspilFacade
    {
        private static BrætspilFacade _brætSpilFacade;

        public static BrætspilFacade HentBrætSpilFacade()
        {
            if (_brætSpilFacade == null)
            {
                _brætSpilFacade = new BrætspilFacade();
            }
            return _brætSpilFacade;
        }
        public string SkabBrætSpil(int id, string navn, string udgiver)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, navn, udgiver);
            return DBSQLFacade.HentDBSQLFacade().GemBrætSpil(bs);
        }
        public string ÆndreBrætSpil(int gammeltID, int nytid, string navn, string udgiver)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(nytid, navn, udgiver);
            return DBSQLFacade.HentDBSQLFacade().ÆndreBrætSpil(gammeltID, bs);
        }
        public string HentBrætSpil(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().HentBrætSpil(id);
        }
        public string SletBrætSpil(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().SletBrætSpil(id);
        }
    }
}
