using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Møbel: Model
    {
        public string Navn { get; set; }

        #region Constructor
        public Møbel() { }
        public Møbel(string navn) : this(0, navn){ }
        public Møbel(int id, string navn): base(id)
        {
            Navn = navn;
        }
        #endregion
    }
}
