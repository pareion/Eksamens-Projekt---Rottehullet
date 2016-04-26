using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Lokale : IAktiv
    {
        private int id { get; set; }
        private string navn { get; set; }
        private string lokation { get; set; }
        private int størrelse { get; set; }
        private string møbler { get; set; }
    }
}
