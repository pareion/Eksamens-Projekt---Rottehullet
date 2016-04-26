using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udstyr : IAktiv
    {
        public enum UdstyrStørrelse { Lille, Mellem, Stor, EkstraStor }

        private int id { get; set; }
        private string navn { get; set; }
        private string kategori { get; set; }
        private UdstyrStørrelse størrelse { get; set; }
    }
}
