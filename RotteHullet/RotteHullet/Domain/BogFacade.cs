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
        public string SkabBog(string bognavn, string forfatter, string genre, string subkategori, string familie, string forlag, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(0, bognavn, forfatter, genre, subkategori, familie, forlag, kommentar);
            return DBSQLFacade.HentDBSQLFacade().GemBog(bog) ? "Bog er oprettet" : "Bog blev ikke oprettetS";
        }

        public string ÆndreBog(int id, string bognavn, string forfatter, string genre, string subkategori, string familie, string forlag, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(id, bognavn, forfatter, genre, subkategori, familie, forlag, kommentar);
            return DBSQLFacade.HentDBSQLFacade().ÆndreBog(id, bog) ? "Bog blev ændret" : "Bog blev ikke ændret";
        }

        public string HentBog(int id, int position)
        {

            return DBRamFacade.HentDbRamFacade().HentBog(id).ToString(position);
        }

        public List<string> HentAlleBøger(int position)
        {
            List<string> bøgerListe = new List<string>();
            foreach (var item in DBRamFacade.HentDbRamFacade().HentAlleBøger())
            {
                bøgerListe.Add(item.ToString(position));
            }
            return bøgerListe;
        }

        public List<object> FindAlleBøger()
        {
            List<Bog> bøgerListe = DBRamFacade.HentDbRamFacade().HentAlleBøger();
            List<object> dataListe = new List<object>();
            foreach (Bog item in bøgerListe)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletBog(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().SletBog(id) ? "Bog blev slettet" : "Kan ikke slet bog";
        }
    }
}
