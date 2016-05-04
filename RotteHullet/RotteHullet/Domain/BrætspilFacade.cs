﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;

namespace RotteHullet.Domain
{
    class BrætspilFacade
    {
        private static BrætspilFacade _brætSpilFacade;

        public static BrætspilFacade HentBrætSpilFacade()
        {
            if (_brætSpilFacade == null)
            {
                _brætSpilFacade = new BrætspilFacade();
            }
            return _brætSpilFacade;
        }
        public string SkabBrætSpil(int id, string navn, string udgiver, bool udlånes, string kommentar)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, navn, udgiver, udlånes, kommentar);
            if (DBFacade.HentDatabaseFacade().GemBrætSpil(bs))
            {
                return "Brætspillet er skabt";
            }
            return "Brætspillet blev ikke skabt";
        }
        public string ÆndreBrætSpil(int gammeltID, int nytid, string navn, string udgiver,bool udlånes, string kommentar)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(nytid, navn, udgiver,udlånes, kommentar);
            if (DBFacade.HentDatabaseFacade().ÆndreBrætSpil(gammeltID, bs))
            {
                return "Brætspillet er ændret";
            }
            return "Brætspillet blev ikke ændret";
        }
        public string HentBrætSpil(int id, int position)
        {
            return DBFacade.HentDatabaseFacade().HentBrætSpil(id).ToString(position);
        }
        public List<string> HentAlleBrætspil(int position)
        {
            List<string> nyeBrætspil = new List<string>();
            foreach (var item in DBFacade.HentDatabaseFacade().HentAlleBrætSpil())
            {
                nyeBrætspil.Add(item.ToString(position));
            }
            return nyeBrætspil;
        }

        public object FindBrætspil()
        {
            return null;
        }
        public List<object> FindAlleBrætspil()
        {
            List<Brætspil> aktiver = DBFacade.HentDatabaseFacade().HentAlleBrætSpil();
            List<object> dataListe = new List<object>();
            foreach (Brætspil item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletBrætSpil(int id)
        {
            if (DBFacade.HentDatabaseFacade().SletBrætSpil(id))
            {
                return "Brætspillet er slettet";
            }
            return "Brætspillet blev ikke slettet";
        }
    }
}
