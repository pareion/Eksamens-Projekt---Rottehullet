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
        bool GemBrætSpil(Brætspil bs);
        bool ÆndreBrætSpil(int gammeltID, Brætspil bs);
        Brætspil HentBrætSpil(int id);
        bool SletBrætSpil(int id);
        bool GemBog(Bog bog);
        bool ÆndreBog(int gammeltID, Bog bog);
        Bog HentBog(int id);
        bool SletBog(int id);
        bool GemUdstyr(Udstyr udstyr);
        bool ÆndreUdstyr(int gammeltID, Udstyr udstyr);
        Udstyr HentUdstyr(int id);
        bool SletUdstyr(int id);
        bool GemLokale(Lokale lokale);
        bool ÆndreLokale(int gammeltID, Lokale lokale);
        Lokale HentLokale(int id);
        bool SletLokale(int id);
    }
}
