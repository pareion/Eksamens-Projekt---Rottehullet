using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class LokaleFacade
    {
        private static LokaleFacade _lokaleFacade;

        public static LokaleFacade HentLokaleFacade()
        {
            if (_lokaleFacade == null)
            {
                _lokaleFacade = new LokaleFacade();
            }
            return _lokaleFacade;
        }
        public string SkabLokale(int id, string navn, string lokation,bool udlånes, string kommentar, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, udlånes ,kommentar, møbler);
            if (DBSQLFacade.HentDBSQLFacade().GemLokale(lok))
            {
                return "Lokalet er skabt";
            }
            return "Lokalet blev ikke skabt";
        }
        public string ÆndreLokale(int gammeltID, int id, string navn, string lokation,bool udlånes, string kommentar, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, udlånes, kommentar, møbler);
            if (DBSQLFacade.HentDBSQLFacade().ÆndreLokale(gammeltID, lok))
            {
                return "Lokalet er blevet ændret";
            }
            return "Lokalet ikke blevet ændret";
        }
        public string HentLokale(int id, int position)
        {
            return DBSQLFacade.HentDBSQLFacade().HentLokale(id).ToString(position);
        }
        public List<string> HentAlleLokaler(int position)
        {
            List<string> nyeLokaler = new List<string>();
            foreach (var item in DBSQLFacade.HentDBSQLFacade().HentAlleLokaler())
            {
                nyeLokaler.Add(item.ToString(position));
            }
            return nyeLokaler;
        }
        public List<object> FindAlleLokaler()
        {
            List<Lokale> aktiver = DBRamFacade.HentDbRamFacade().HentAlleLokaler();
            List<object> dataListe = new List<object>();
            foreach (Lokale item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }
        public string SletLokale(int id)
        {
            if (DBSQLFacade.HentDBSQLFacade().SletBrætSpil(id))
            {
                return "Lokalet er blevet slettet";
            }
            return "Lokalet er ikke blevet slettet";
        }
    }
}
