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
        public string SkabLokale(int id, string navn, string lokation, int størrelse, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, størrelse, møbler);
            if (DBSQLFacade.HentDBSQLFacade().GemLokale(lok))
            {
                return "Lokalet er skabt";
            }
            return "Lokalet blev ikke skabt";
        }
        public string ÆndreLokale(int gammeltID, int id, string navn, string lokation, int størrelse, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, størrelse, møbler);
            if (DBSQLFacade.HentDBSQLFacade().ÆndreLokale(gammeltID, lok))
            {
                return "Lokalet er blevet ændret";
            }
            return "Lokalet ikke blevet ændret";
        }
        public string HentLokale(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().HentLokale(id).ToString();
        }
        public List<string> HentAlleLokaler()
        {
            List<string> nyeLokaler = new List<string>();
            foreach (var item in DBSQLFacade.HentDBSQLFacade().HentAlleLokaler())
            {
                nyeLokaler.Add(item.ToString());
            }
            return nyeLokaler;
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
