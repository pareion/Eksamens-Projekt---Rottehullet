using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    internal class Utility
    {
        public enum MedlemType { Bruger, Bestyrelse }
        public enum Godkendelse { Afventning = 0, Tillad = 1, Afvist = 2 }
    }
}
