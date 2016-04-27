using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class UdstyrFacade
    {
        private static UdstyrFacade _udstyrFacade;

        public static UdstyrFacade HentUdstyrFacade()
        {
            if (_udstyrFacade == null)
            {
                _udstyrFacade = new UdstyrFacade();
            }
            return _udstyrFacade;
        }
        public string SkabUdstyr(int id, string navn, string kategori, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, navn, kategori, kommentar);
            if (DBSQLFacade.HentDBSQLFacade().GemUdstyr(uds))
            {
                return "Udstyret er skabt";
            }
            return "Udstyret blev ikke skabt";
        }
        public string ÆndreUdstyr(int gammeltID, int nytid, string navn, string kategori, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(nytid, navn, kategori, kommentar);
            if (DBSQLFacade.HentDBSQLFacade().ÆndreUdstyr(gammeltID, uds))
            {
                return "Udstyret er ændret";
            }
            return "Udstyret blev ikke ændret";
        }
        public string HentUdstyr(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().HentUdstyr(id).ToString();
        }
        public List<string> HentAlleUdstyr()
        {
            List<string> nytUdstyr = new List<string>();
            foreach (var item in DBSQLFacade.HentDBSQLFacade().HentAlleUdstyr())
            {
                nytUdstyr.Add(item.ToString());
            }
            return nytUdstyr;
        }
        public string SletUdstyr(int id)
        {
            if (DBSQLFacade.HentDBSQLFacade().SletUdstyr(id))
            {
                return "Udstyret er slettet";
            }
            return "Udstyret blev ikke slettet";
        }
    }
}
