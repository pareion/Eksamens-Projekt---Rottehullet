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

        public List<object> FindAlleBøger(string søgord = null) //Skal bruge søgning gennem facaden?
        {
            List<Bog> bøgerListe = new List<Bog>();
            List<object> dataListe = new List<object>();

            if(søgord == null)
            {
                bøgerListe = DBFacade.HentDatabaseFacade().HentAlleBøger();
            }
            else
            {
                Værktøjs.Søgning.HentSøgning().Søg(søgord, out bøgerListe);
            }

            foreach (Bog item in bøgerListe)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletBog(int id)
        {
            return DBFacade.HentDatabaseFacade().SletBog(id) ? "Bog blev slettet" : "Kan ikke slet bog";
        }

        #region Gamle HentBøger Metoder som benytter ToString() på objekterne
        public string HentBog(int id, int position)
        {
            return DBFacade.HentDatabaseFacade().HentBog(id).ToString(position);
        }

        public List<string> HentAlleBøger(int position)
        {
            List<string> bøgerListe = new List<string>();
            foreach (var item in DBFacade.HentDatabaseFacade().HentAlleBøger())
            {
                bøgerListe.Add(item.ToString(position));
            }
            return bøgerListe;
        }
        #endregion
    }
}
