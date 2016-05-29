using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Lokale: Aktiv
    {
        public string Navn { get; set; }
        public Lokation Lokation { get; set; }
        public List<Møbel> Møbler { get; set; }

        public Lokale(int id, string navn, Lokation lokation, List<Møbel> møbler, UdlånStatus status): base() { }
    }
}
