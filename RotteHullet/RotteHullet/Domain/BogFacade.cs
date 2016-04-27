using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class BogFacade
    {
        private static BogFacade bogFacade;
        public static BogFacade getBogFacade()
        {
            if (bogFacade == null)
            {
                bogFacade = new BogFacade();
            }
            return bogFacade;
        }

        public void doBogStuff()
        {
            Console.WriteLine("lol");
        }
    }
}
