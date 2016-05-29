using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Bog: Aktiv
    {
        #region Properties
        public string Titel { get; set; }
        public Familie Familie { get; set; }
        public Kategori Kategori { get; set; }
        public List<Forfatter> Forfatter { get; set; }
        public Forlag Forlag { get; set; }
        #endregion

        public Bog() { }
        public Bog(int id, string titel) { }
    }
}
