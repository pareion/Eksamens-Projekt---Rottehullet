using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet.Domain
{
    class MedlemFacade
    {
        #region Egenskaber
        public bool ErAdmin
        {
            get
            {
                return _sessionBruger != null && (Utility.MedlemType)_sessionBruger.rang == Utility.MedlemType.Bestyrelse;
            }
        }

        private static Medlem _sessionBruger;
        private static MedlemFacade _medlemFacade = null;
        #endregion

        #region Metoder
        public static MedlemFacade HentMedlemFacade()
        {
            if (_medlemFacade == null)
            {
                _medlemFacade = new MedlemFacade();
            }
            return _medlemFacade;
        }

        public void GemMedlem(string brugernavn, string password, string fornavn, string efternavn, string email)
        {
            // Do something
        }

        public void ÆndreMedlem(int id, string brugernavn, string password, string fornavn, string efternavn, string email)
        {
            // Do something
        }

        public void SletMedlem(int id)
        {
            // Do something
        }

        public Medlem SessionBruger()
        {
            return _sessionBruger;
        }

        public bool TjekLogind(string brugernavn, string password)
        {
            Medlem bruger = DBEF.HentDBEF().HentMedlem(brugernavn, password);

            if (bruger != null)
            {
                _sessionBruger = bruger;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion 
    }
}
