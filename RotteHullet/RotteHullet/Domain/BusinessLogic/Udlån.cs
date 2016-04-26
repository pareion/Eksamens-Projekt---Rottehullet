using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udlån
    {
        private int id { get; set; }
        private int adminid { get; set; }
        private DateTime udlåningdato { get; set; }
        private DateTime afleveringsdato { get; set; }
        private bool godkendt { get; set; }
        private List<IAktiv> aktiver { get; set; }
    }
}
