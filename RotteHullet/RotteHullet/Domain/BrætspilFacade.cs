using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;

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
            IAktiv IA = AktivFactory.HentAktivFactory().SkabNyBrætspil(0, null, udgiver);

        }
    }
}
