using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Søgning
    {
        public enum AktivType { Bog, Brætspil, Udstyr, Lokale }

        private static Søgning _søgning;

        public static Søgning HentSøgning()
        {
            if (_søgning == null)
            {
                _søgning = new Søgning();
            }
            return _søgning;
        }

        public bool Søg(string søgord, out List<Bog> bøger)
        {
            bøger = new List<Bog>();
            
            bøger = Data.DBFacade.HentDatabaseFacade().HentAlleBøger().FindAll(x => 
            x.Titel.ToLower().Contains(søgord) ||
            x.Familie.ToLower().Contains(søgord) ||
            x.Forfatter.ToLower().Contains(søgord) ||
            x.Genre.ToLower().Contains(søgord));

            return bøger.Count != 0;
        }

        public bool Søg(string søgord, out List<Lokale> lokaler)
        {
            lokaler = new List<Lokale>();
            lokaler = Data.DBFacade.HentDatabaseFacade().HentAlleLokaler().FindAll(x =>
            x.LokaleNavn.ToLower().Contains(søgord) ||
            x.Lokation.ToLower().Contains(søgord) ||
            x.Møbler.ToLower().Contains(søgord));

            return lokaler.Count != 0;
        }

        public bool Søg(string søgord, out List<Udstyr> udstyr)
        {
            udstyr = new List<Udstyr>();
            udstyr = Data.DBFacade.HentDatabaseFacade().HentALtUdstyr().FindAll(x => 
            x.UdstyrsNavn.ToLower().Contains(søgord) ||
            x.Kategori.ToLower().Contains(søgord));

            return udstyr.Count != 0;
        }

        public bool Søg(string søgord, out List<Brætspil> brætspil)
        {
            brætspil = new List<Brætspil>();
            brætspil = Data.DBFacade.HentDatabaseFacade().HentAlleBrætSpil().FindAll(x => 
            x.BrætspilsNavn.ToLower().Contains(søgord) ||
            x.Kategori.ToLower().Contains(søgord) ||
            x.Udgiver.ToLower().Contains(søgord));

            return brætspil.Count != 0;
        }
    }
}
