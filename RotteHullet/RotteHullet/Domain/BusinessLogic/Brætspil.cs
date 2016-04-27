using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Brætspil : IAktiv
    {
        private int id { get; set; }
        private string navn { get; set; }
        private string udgiver { get; set; }

        public Brætspil(int id, string navn, string udgiver)
        {
            this.id = id;
            this.navn = navn;
            this.udgiver = udgiver;
        }
    }
}
