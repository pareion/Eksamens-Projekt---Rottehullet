using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;

namespace RotteHullet.Domain
{
    class BogFacade
    {
        private static BogFacade _bogFacade;

        public static BogFacade HentBogFacade()
        {
            if (_bogFacade == null)
            {
                _bogFacade = new BogFacade();
            }
            return _bogFacade;
        }

        public string SkabBog(string bognavn, string forfatter, string genre, string subkategori, string familie, 
            string forlag, bool udlånes, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(0, bognavn, forfatter, genre, subkategori, familie,
                forlag, udlånes, kommentar);

            return DBFacade.HentDatabaseFacade().GemBog(bog) ? "Bog er oprettet" : "Bog blev ikke oprettet";
        }

        public string ÆndreBog(int id, string bognavn, string forfatter, string genre, string subkategori, 
            string familie, string forlag,bool udlånes, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(id, bognavn, forfatter, genre, subkategori, familie,
                forlag, udlånes, kommentar);

            return DBFacade.HentDatabaseFacade().ÆndreBog(bog) ? "Bog blev ændret" : "Bog blev ikke ændret";
        }

        public List<object> FindAlleBøger(string søgeord = null)
        {
            List<Bog> aktiver = new List<Bog>();
            List<object> dataListe = new List<object>();

            if(søgeord == null)
            {
                aktiver = DBFacade.HentDatabaseFacade().HentAlleBøger();
            }
            else
            {
                Søgning.HentSøgning().Søg(søgeord, out aktiver);
            }

            foreach (Bog item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletBog(int id)
        {
            return DBFacade.HentDatabaseFacade().SletBog(id) ? "Bog blev slettet" : "Kan ikke slet bog";
        }
    }
}
