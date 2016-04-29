using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class UIFacade
    {
        private static UIFacade _uifacade;
        public static UIFacade HentUIFacade()
        {
            if (_uifacade == null)
            {
                _uifacade = new UIFacade();
            }
            return _uifacade;
        }

        public BogFacade HentBogFacade()
        {
            return BogFacade.HentBogFacade();
        }
        public BrætspilFacade HentBrætSpilFacade()
        {
            return BrætspilFacade.HentBrætSpilFacade();
        }
        public LokaleFacade HentLokaleFacade()
        {
            return LokaleFacade.HentLokaleFacade();
        }
        public UdstyrFacade HentUdstyrFacade()
        {
            return UdstyrFacade.HentUdstyrFacade();
        }
        public SøgningsFacade HentSøgningsFacade()
        {
            return SøgningsFacade.GetSøgningsFacade();
        }
    }
}
