using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Brætspil : IAktiv
    {
        private int id;
        private string navn;
        private string udgiver;

        public int HentID()
        {
            return id;
        }
        public string HentNavn()
        {
            return navn;
        }
        public string HentUdgiver()
        {
            return udgiver;
        }
        public Brætspil(int id, string navn, string udgiver)
        {
            this.id = id;
            this.navn = navn;
            this.udgiver = udgiver;
        }
    }
}
