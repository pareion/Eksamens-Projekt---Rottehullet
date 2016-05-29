using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Udstyr: Aktiv
    {
        #region Properties
        public string Navn { get; set; }
        #endregion

        #region Constructor
        public Udstyr() { }
        public Udstyr(string navn, UdlånStatus status) : this(0, navn, status) { }
        public Udstyr(int id, string navn, UdlånStatus status): base(id, status)
        {
            Navn = navn;
        }
        #endregion

    }
}
