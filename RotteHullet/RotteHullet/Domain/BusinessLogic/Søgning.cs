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
        private static Søgning _søgning;

        public static Søgning HentSøgning()
        {
            if (_søgning == null)
            {
                _søgning = new Søgning();
            }
            return _søgning;
        }

        public bool SøgBøger(string søgord, out List<Bog> bøger)
        {
            bøger = new List<Bog>();
            
            bøger = Data.DBEF.HentDBEF().HentAlleBøger().FindAll(x => 
            x.titel.ToLower().Contains(søgord.ToLower()) ||
            x.familie.ToLower().Contains(søgord.ToLower()) ||
            x.forfatter.ToLower().Contains(søgord.ToLower()) ||
            x.genre.ToLower().Contains(søgord.ToLower()));

            return bøger.Count != 0;
        }

        public bool SøgLokaler(string søgord, out List<Lokale> lokaler)
        {
            lokaler = new List<Lokale>();
            lokaler = Data.DBEF.HentDBEF().HentAlleLokaler().FindAll(x =>
            x.lokalenavn.ToLower().Contains(søgord.ToLower()) ||
            x.lokation.ToLower().Contains(søgord.ToLower()) ||
            x.møbler.ToLower().Contains(søgord.ToLower()));

            return lokaler.Count != 0;
        }

        public bool SøgUdstyr(string søgord, out List<Udstyr> udstyr)
        {
            udstyr = new List<Udstyr>();
            udstyr = Data.DBEF.HentDBEF().HentALtUdstyr().FindAll(x => 
            x.navn.ToLower().Contains(søgord.ToLower()) ||
            x.kategori.ToLower().Contains(søgord.ToLower()));

            return udstyr.Count != 0;
        }

        public bool SøgBrætspil(string søgord, out List<Brætspil> brætspil)
        {
            brætspil = new List<Brætspil>();
            brætspil = Data.DBEF.HentDBEF().HentAlleBrætSpil().FindAll(x => 
            x.brætspilnavn.ToLower().Contains(søgord.ToLower()) ||
            x.kategori.ToLower().Contains(søgord.ToLower()) ||
            x.udgiver.ToLower().Contains(søgord.ToLower()));

            return brætspil.Count != 0;
        }
    }
}
