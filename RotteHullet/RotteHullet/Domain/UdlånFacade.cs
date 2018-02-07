using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;
using System.Threading;
using RotteHullet;

namespace RotteHullet.Domain
{
    class UdlånFacade
    {
        private static UdlånFacade _udlåningsFacade;
        public static UdlånFacade HentUdlåningsFacade()
        {
            if (_udlåningsFacade == null)
            {
                _udlåningsFacade = new UdlånFacade();
            }
            return _udlåningsFacade;
        }

        public string ReserverAktiv(DateTime udlåningsdato, DateTime afleveringsdato, int aktivType, List<int> aktivIDer, HashSet<Bog> bøger = null, HashSet<Udstyr> udstyr = null, HashSet<Lokale> lokaler = null, HashSet<Brætspil> brætspil = null)
        {
            // Skift ud Medlem objekt parameter til SessionBruger()-> Medlem objekt i stedet for
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(0, MedlemFacade.HentMedlemFacade().SessionBruger(), 0, udlåningsdato, afleveringsdato, null, 1, bøger, udstyr, lokaler, brætspil);

            string resultat = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var id in aktivIDer)
                    {
                        udl.Udstyr.Add(DBEF.HentDBEF().HentUdstyr(id));
                    }
                    break;
                case 1:
                    foreach (var id in aktivIDer)
                    {
                        udl.Bog.Add(DBEF.HentDBEF().HentBog(id));
                    }
                    break;
                case 2:
                    foreach (var id in aktivIDer)
                    {
                        udl.Brætspil.Add(DBEF.HentDBEF().HentBrætSpil(id));
                    }
                    break;
                case 3:
                    foreach (var id in aktivIDer)
                    {
                        udl.Lokale.Add(DBEF.HentDBEF().HentLokale(id));
                    }
                    break;
                default:
                    return "Aktiv Type findes ikke";
            }

            if (DBEF.HentDBEF().GemUdlån(udl))
            {
                resultat = "Udlån er skabt";
            }
            else
            {
                resultat = "Udlån er ikke skabt";
            }

            return resultat;
        }

        public string BesvarReservation(object udlån, int godkendelse)
        {
            Udlån data = udlån as Udlån;

            data.udlåningsdato = DateTime.Now;
            try
            {
                if (data.Bog.Count > data.Brætspil.Count && data.Bog.Count > data.Udstyr.Count && data.Bog.Count > data.Lokale.Count)
                {
                    data.afleveringsdato = DateTime.Now.AddMonths(3);
                }
                else if (data.Brætspil.Count > data.Bog.Count && data.Brætspil.Count > data.Udstyr.Count && data.Brætspil.Count > data.Lokale.Count)
                {
                    data.afleveringsdato = DateTime.Now.AddDays(7);
                }
                else if (data.Udstyr.Count > data.Bog.Count && data.Udstyr.Count > data.Brætspil.Count && data.Udstyr.Count > data.Lokale.Count)
                {
                    data.afleveringsdato = DateTime.Now.AddMonths(3);
                }
                else if (data.Lokale.Count > data.Bog.Count && data.Lokale.Count > data.Brætspil.Count && data.Lokale.Count > data.Udstyr.Count)
                {
                    data.afleveringsdato = DateTime.Now.AddMonths(3);
                }
            }
            catch
            {
                Console.WriteLine("Fejl, udlån er peudo data eller test data)");
            }


            if (DBEF.HentDBEF().OpdaterUdlån(data))
            {
                return "Udlån er skabt";
            }
            else
            {
                return "Udlån er ikke skabt";
            }
        }

        public string BesvarReservation(object udlån, int godkendelse, DateTime afleveringsdato, DateTime udlåningsdato = default(DateTime))
        {
            Udlån data = udlån as Udlån;

            if (udlåningsdato == default(DateTime))
            {
                udlåningsdato = DateTime.Now;
            }

            data.afleveringsdato = afleveringsdato;
            data.udlåningsdato = udlåningsdato;

            if (DBEF.HentDBEF().OpdaterUdlån(data))
            {
                return "Udlån er skabt";
            }
            else
            {
                return "Udlån er ikke skabt";
            }
        }

        public string BesvarReservation(int udlånid, int medlemid, int adminid, DateTime udlåningsdato, DateTime afleveringsdato, int godkendelse, int aktivType, HashSet<Bog> bøger = null, HashSet<Udstyr> udstyr = null, HashSet<Lokale> lokaler = null, HashSet<Brætspil> brætspil = null)
        {
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(udlånid, DBEF.HentDBEF().HentMedlem(medlemid), adminid, udlåningsdato, afleveringsdato, null, godkendelse, bøger, udstyr, lokaler, brætspil);
            string resultat = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var id in udstyr)
                    {
                        udl.Udstyr.Add(DBEF.HentDBEF().HentUdstyr(id.udstyrid));
                    }
                    break;
                case 1:
                    foreach (var id in bøger)
                    {
                        udl.Bog.Add(DBEF.HentDBEF().HentBog(id.bogid));
                    }
                    break;
                case 2:
                    foreach (var id in brætspil)
                    {
                        udl.Brætspil.Add(DBEF.HentDBEF().HentBrætSpil(id.brætspilid));
                    }
                    break;
                case 3:
                    foreach (var id in lokaler)
                    {
                        udl.Lokale.Add(DBEF.HentDBEF().HentLokale(id.lokaleid));
                    }
                    break;
                default:
                    return "Aktiv Type findes ikke";
            }

            if (DBEF.HentDBEF().OpdaterUdlån(udl))
            {
                resultat = "Udlån er skabt";
            }
            else
            {
                resultat = "Udlån er ikke skabt";
            }

            return resultat;
        }

        public List<object> FindAlleUdlån()
        {
            return DBEF.HentDBEF().FindAlleUdlån().ToList<object>();
        }
    }
}
