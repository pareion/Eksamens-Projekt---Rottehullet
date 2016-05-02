using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Data
{
    interface IDBFacade
    {
        #region Brætspil
        bool GemBrætSpil(Brætspil bs);
        bool ÆndreBrætSpil(int gammeltID, Brætspil bs);
        Brætspil HentBrætSpil(int id);
        List<Brætspil> HentAlleBrætSpil();
        bool SletBrætSpil(int id);
        #endregion
        #region Bog
        bool GemBog(Bog bog);
        bool ÆndreBog(int gammeltID, Bog bog);
        Bog HentBog(int id);
        List<Bog> HentAlleBøger();
        bool SletBog(int id);
        #endregion
        #region Udstyr
        bool GemUdstyr(Udstyr udstyr);
        bool ÆndreUdstyr(int gammeltID, Udstyr udstyr);
        Udstyr HentUdstyr(int id);
        List<Udstyr> HentAlleUdstyr();
        bool SletUdstyr(int id);
        #endregion
        #region Lokale
        bool GemLokale(Lokale lokale);
        bool ÆndreLokale(int gammeltID, Lokale lokale);
        Lokale HentLokale(int id);
        List<Lokale> HentAlleLokaler();
        bool SletLokale(int id);
        #endregion

        void checkLister();
    }
}
