using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Medlem
    {
        public enum MedlemType { Bestyrelse, Bruger }
        private int id { get; set; }
        private string brugernavn { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private MedlemType status { get; set; }
    }
}
