using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Værktøjs
{
    class Søgning
    {
        private static Søgning _søgning;

        public static Søgning GetSøgning()
        {
            if (_søgning == null)
            {
                _søgning = new Søgning();
            }
            return _søgning;
        }

        public bool Søg(bool bøger, bool lokaler, bool brætspil, bool udstyr, string søgning, 
            out List<Bog> bogResult, out List<Lokale> lokaleResult, 
            out List<Brætspil> brætspilResult, out List<Udstyr> udstyrResult)
        {
            bogResult = new List<Bog>();
            lokaleResult = new List<Lokale>();
            brætspilResult = new List<Brætspil>();
            udstyrResult = new List<Udstyr>();

            bool result = false;
            //Søger alle bøger igennem og finder de relevante 
            if (bøger == true)
            {
                foreach (Bog item in Data.DBRamFacade.HentDbRamFacade().HentAlleBøger())
                {
                    if (item.Titel.Contains(søgning) || item.Genre.Contains(søgning))
                    {
                        bogResult.Add(item);
                        result = true;
                    }
                }
            }

            //Søger alle lokaler igennem og finder de relevante 
            if (lokaler == true)
            {
                foreach (Lokale item in Data.DBRamFacade.HentDbRamFacade().HentAlleLokaler())
                {
                    if (item.LokaleNavn.Contains(søgning) || item.Møbler.Contains(søgning))
                    {
                        lokaleResult.Add(item);
                        result = true;
                    }
                }
            }

            //Søger alle brætspil igennem og finder de relevante 
            if (brætspil == true)
            {
                foreach (Brætspil item in Data.DBRamFacade.HentDbRamFacade().HentAlleBrætSpil())
                {
                    if (item.BrætspilsNavn.Contains(søgning) || item.Udgiver.Contains(søgning))
                    {
                        brætspilResult.Add(item);
                        result = true;
                    }
                }
            }

            //Søger alle udstyr igennem og finder de relevante 
            if (udstyr == true)
            {
                foreach (Udstyr item in Data.DBRamFacade.HentDbRamFacade().HentAlleUdstyr())
                {
                    if (item.UdstyrsNavn.Contains(søgning) || item.Kategori.Contains(søgning))
                    {
                        udstyrResult.Add(item);
                        result = true;
                    }
                }
            }

            return result;
        }

        public bool Søg(string søgord, out List<Bog> bøger)
        {
            bøger = new List<Bog>();
            bøger = Data.DBRamFacade.HentDbRamFacade().HentAlleBøger().FindAll(x => x.Titel.Contains(søgord) || x.Familie.Contains(søgord) || x.Forfatter.Contains(søgord) || x.Genre.Contains(søgord));

            return bøger.Count != 0;
        }

        public bool Søg(string søgord, out List<Lokale> lokaler)
        {
            lokaler = new List<Lokale>();
            lokaler = Data.DBRamFacade.HentDbRamFacade().HentAlleLokaler().FindAll(x => x.LokaleNavn.Contains(søgord));

            return lokaler.Count != 0;
        }

        public bool Søg(string søgord, out List<Udstyr> udstyr)
        {
            udstyr = new List<Udstyr>();
            udstyr = Data.DBRamFacade.HentDbRamFacade().HentAlleUdstyr().FindAll(x => x.UdstyrsNavn.Contains(søgord));

            return udstyr.Count != 0;
        }

        public bool Søg(string søgord, out List<Brætspil> brætspil)
        {
            brætspil = new List<Brætspil>();
            brætspil = Data.DBRamFacade.HentDbRamFacade().HentAlleBrætSpil().FindAll(x => x.BrætspilsNavn.Contains(søgord));

            return brætspil.Count != 0;
        }
    }
}
