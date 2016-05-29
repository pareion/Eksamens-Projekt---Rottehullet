using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Forfatter: Model
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Fuldnavn
        {
            get
            {
                return string.Format("{0} {1}", Fornavn, Efternavn);
            }
        }
    }
}
