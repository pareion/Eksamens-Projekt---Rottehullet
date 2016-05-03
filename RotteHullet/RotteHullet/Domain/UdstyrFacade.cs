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
        public string SkabUdstyr(int id, string navn, string kategori, bool udlånes, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, navn, kategori, udlånes, kommentar);
            if (DBSQLFacade.HentDBSQLFacade().GemUdstyr(uds))
            {
                return "Udstyret er skabt";
            }
            return "Udstyret blev ikke skabt";
        }
        public string ÆndreUdstyr(int gammeltID, int nytid, string navn, string kategori, bool udlånes, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(nytid, navn, kategori, udlånes, kommentar);
            if (DBSQLFacade.HentDBSQLFacade().ÆndreUdstyr(gammeltID, uds))
            {
                return "Udstyret er ændret";
            }
            return "Udstyret blev ikke ændret";
        }
        public string HentUdstyr(int id, int position)
        {
            return DBSQLFacade.HentDBSQLFacade().HentUdstyr(id).ToString(position);
        }
        public List<string> HentAlleUdstyr(int position)
        {
            List<string> nytUdstyr = new List<string>();
            foreach (var item in DBSQLFacade.HentDBSQLFacade().HentAlleUdstyr())
            {
                nytUdstyr.Add(item.ToString(position));
            }
            return nytUdstyr;
        }
        public List<object> FindAlleUdstyr()
        {
            List<Udstyr> aktiver = DBRamFacade.HentDbRamFacade().HentAlleUdstyr();
            List<object> dataListe = new List<object>();
            foreach (Udstyr item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
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
