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

        public string SkabLokale(int id, string navn, string lokation, bool udlånes, string kommentar, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, udlånes, kommentar, møbler);
            if (DBEF.HentDBEF().GemLokale(lok))
            {
                return "Lokalet er skabt";
            }
            return "Lokalet blev ikke skabt";
        }
        public string ÆndreLokale(int id, string navn, string lokation, bool udlånes, string kommentar, string møbler)
        {
            Lokale lok = AktivFactory.HentAktivFactory().SkabNytLokale(id, navn, lokation, udlånes, kommentar, møbler);
            if (DBEF.HentDBEF().ÆndreLokale(lok))
            {
                return "Lokalet er blevet ændret";
            }
            return "Lokalet ikke blevet ændret";
        }

        public List<object> FindAlleLokaler(string søgeord = null)
        {
            List<Lokale> aktiver = DBEF.HentDBEF().HentAlleLokaler();
            List<object> dataListe = new List<object>();

            if (søgeord == null)
            {
                aktiver = DBEF.HentDBEF().HentAlleLokaler();
            }
            else
            {
                Søgning.HentSøgning().SøgLokaler(søgeord, out aktiver);
            }

            foreach (Lokale item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletLokale(int id)
        {
            if (DBEF.HentDBEF().SletBrætSpil(id))
            {
                return "Lokalet er blevet slettet";
            }
            return "Lokalet er ikke blevet slettet";
        }
    }
}
