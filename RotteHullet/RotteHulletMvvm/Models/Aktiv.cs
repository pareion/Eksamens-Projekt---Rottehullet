using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Aktiv: Model
    {
        public enum UdlånStatus { IkkeTilUdlån, Tilgængelig, Utilgængelig }

        #region Properties
        public UdlånStatus Status { get; set; }
        public List<Kommentar> Kommentarer { get; set; }
        #endregion

        #region Constructor
        protected Aktiv() : this(0, UdlånStatus.Tilgængelig, null) { }
        protected Aktiv(UdlånStatus status) : this(0, status, null) { }
        protected Aktiv(int id): this(id, UdlånStatus.Tilgængelig, null) { }

        protected Aktiv(int id, UdlånStatus status, List<Kommentar> kommentarer): base(id)
        {
            Status = status;
        }
        #endregion
    }
}
