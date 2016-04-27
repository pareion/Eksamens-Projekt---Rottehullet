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
        string GemBrætSpil(Brætspil bs);
        string ÆndreBrætSpil(int gammeltID, Brætspil bs);
        string HentBrætSpil(int id);
        string SletBrætSpil(int id);
        string GemBog(Bog bog);
        string ÆndreBog(int gammeltID, Bog bog);
        string HentBog(int id);
        string SletBog(int id);
        string GemUdstyr(Udstyr udstyr);
        string ÆndreUdstyr(int gammeltID, Udstyr udstyr);
        string HentUdstyr(int id);
        string SletUdstyr(int id);
        string GemLokale(Lokale lokale);
        string ÆndreLokale(int gammeltID, Lokale lokale);
        string HentLokale(int id);
        string SletLokale(int id);
    }
}
