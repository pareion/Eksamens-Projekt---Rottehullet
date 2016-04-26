using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Bog : IAktiv
    {
        private int id { get; set; }
        private int titel { get; set; }
        private string forfatter { get; set; }
        private string genre { get; set; }
        private string subkategori { get; set; }
        private string isbn { get; set; }
        private string familie { get; set; }
        private string forlag { get; set; }
        private string kommentar { get; set; }
    }
}
