using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class UIFacade
    {
        private static UIFacade UIfacade;
        public static UIFacade getUIFacade()
        {
            if (UIfacade == null)
            {
                UIfacade = new UIFacade();
            }
            return UIfacade;
        }

        public BogFacade getBogFacade()
        {
            return BogFacade.getBogFacade();
        }
        public BrætspilFacade HentBrætSpilFacade()
        {
            return BrætspilFacade.HentBrætSpilFacade();
        }
        public LokaleFacade HentLokaleFacade()
        {
            return LokaleFacade.HentLokaleFacade();
        }
    }
}
