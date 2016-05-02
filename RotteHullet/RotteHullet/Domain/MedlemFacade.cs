using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class MedlemFacade
    {
        public static bool TjekLogind(string brugernavn, string password)
        {
            if (brugernavn == "admin" && password == "admin")
            {
                return true;
            }
            else if (brugernavn == "medlem" && password == "medlem")
            {
                return true;
            }
            return false;
        }
    }
}
