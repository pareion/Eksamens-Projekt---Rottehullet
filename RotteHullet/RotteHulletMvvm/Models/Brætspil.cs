using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Brætspil: Aktiv
    {
        #region Properties
        public string Navn { get; set; }
        public Kategori Kategori { get; set; }
        public Udgiver Udgiver { get; set; }
        #endregion

        #region Constructor
        public Brætspil() { }
        public Brætspil(string navn, Kategori kategori, Udgiver udgiver, UdlånStatus status) : this(0, navn, kategori, udgiver, status) { }
        public Brætspil(int id, string navn, Kategori kategori, Udgiver udgiver, UdlånStatus status): base(id, status)
        {
            Navn = navn;
            Kategori = kategori;
            Udgiver = udgiver;
        }
        #endregion
    }
}
