﻿using System;
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
<<<<<<< HEAD
            return DBSQLFacade.HentDBSQLFacade().GemBog(bog) ? "Bog er oprettet" : "Bog blev ikke oprettetS";
=======
            return DBRamFacade.HentDbRamFacade().GemBog(bog);
>>>>>>> 62eb71f3022e886f7f93a255b9bcd5d5a5a34105
        }

        public string ÆndreBog(int id, string bognavn, string forfatter, string genre, string subkategori, string familie, string forlag, string kommentar)
        {
            Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(id, bognavn, forfatter, genre, subkategori, familie, forlag, kommentar);
            return DBSQLFacade.HentDBSQLFacade().ÆndreBog(id, bog) ? "Bog blev ændret" : "Bog blev ikke ændret";
        }

        public Bog LæsBog(int id)
        {
            return DBRamFacade.HentDbRamFacade().HentBog(id);
        }

        public string SletBog(int id)
        {
            return DBSQLFacade.HentDBSQLFacade().SletBog(id) ? "Bog blev slettet" : "Kan ikke slet bog";
        }
    }
}
