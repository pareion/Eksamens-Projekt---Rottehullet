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
        private static Medlem sessionBruger { get; set; }
        private static MedlemFacade _medlemFacade = null;

        public bool ErAdmin
        {
            get
            {
                return sessionBruger != null && sessionBruger.Status == Medlem.MedlemType.Bestyrelse;
            }
        }

        public static MedlemFacade HentMedlemFacade()
        {
            if (_medlemFacade == null)
            {
                _medlemFacade = new MedlemFacade();
            }
            return _medlemFacade;
        }

        public Medlem SessionBruger()
        {
            return sessionBruger;
        }

        public bool TjekLogind(string brugernavn, string password)
        {
            Medlem bruger = DBRamFacade.HentDbRamFacade().HentMedlem(brugernavn, password);

            if (bruger != null)
            {
                sessionBruger = bruger;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
