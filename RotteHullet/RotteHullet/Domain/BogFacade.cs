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
        private static BogFacade bogFacade;
        public static BogFacade getBogFacade()
        {
            if (bogFacade == null)
            {
                bogFacade = new BogFacade();
            }
            return bogFacade;
        }

        public void doBogStuff()
        {
            Console.WriteLine("lol");
        }

        public bool SkabBog(string bognavn, string forfatter, string genre, string subkategori, string familie, string forlag, string isbn, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(bognavn, forfatter, genre, subkategori, familie, forlag, isbn, kommentar);
            return DBSQLFacade.HentDBSQLFacade().GemBog(bog);
        }

        public bool ÆndreBog(int id, string bognavn, string forfatter, string genre, string subkategori, string familie, string forlag, string isbn, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(bognavn, forfatter, genre, subkategori, familie, forlag, isbn, kommentar);
            return DBSQLFacade.HentDBSQLFacade().ÆndreBog(bog);
        }

        public List<Bog> LæsBog(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().HentBog(id);
        }

        public bool SletBog(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().SletBog(id);
        }
    }
}
