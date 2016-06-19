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
        /// <summary>
        /// Kaldes når et medlem skal reservere et aktiv for første gang
        /// aktivType 0 = udstyr, 1 = bøger, 2 = brætspil og 3 = lokaler
        /// </summary>
        /// <param name="udlåningsdato"></param>
        /// <param name="afleveringsdato"></param>
        /// <param name="aktivType"></param>
        /// <param name="aktivIDer"></param>
        /// <returns></returns>
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
                        udl.Udstyr.Add(DBFacade.HentDatabaseFacade().HentUdstyr(id));
                    }
                    break;
                case 1:
                    foreach (var id in aktivIDer)
                    {
                        udl.Bog.Add(DBFacade.HentDatabaseFacade().HentBog(id));
                    }
                    break;
                case 2:
                    foreach (var id in aktivIDer)
                    {
                        udl.Brætspil.Add(DBFacade.HentDatabaseFacade().HentBrætSpil(id));
                    }
                    break;
                case 3:
                    foreach (var id in aktivIDer)
                    {
                        udl.Lokale.Add(DBFacade.HentDatabaseFacade().HentLokale(id));
                    }
                    break;
                default:
                    resultat = "Aktiv Type findes ikke";
                    goto finish;
            }

            if (DBFacade.HentDatabaseFacade().GemUdlån(udl))
            {
                resultat = "Udlån er skabt";
            }
            else
            {
                resultat = "Udlån er ikke skabt";
            }

        finish:
            return resultat;
        }

        /// <summary>
        /// Hurtig BesvarReservation
        /// </summary>
        /// <param name="udlån">Udlån objekt</param>
        /// <param name="godkendelse">Godkendelse værdi(0 = Afvent, 1 = Godkendt, 2 = Afvist)</param>
        public string BesvarReservation(object udlån, int godkendelse)
        {
            Udlån data = udlån as Udlån;

            // Opdatere info
            data.godkendelse = godkendelse;
            // Administrator Id
            data.adminid = MedlemFacade.HentMedlemFacade().SessionBruger().medlemid;

            if ((Utility.Godkendelse)data.godkendelse == Utility.Godkendelse.Tillad)
            {
                // Udvide udlån dato
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
            }

            if (DBFacade.HentDatabaseFacade().OpdaterUdlån(data))
            {
                return "Udlån er skabt";
            }
            else
            {
                return "Udlån er ikke skabt";
            }
        }

        /// <summary>
        /// Standard BesvarReservation
        /// </summary>
        /// <param name="udlån">Udlån objekt</param>
        /// <param name="godkendelse">Godkendelse værdi(0 = Afvent, 1 = Godkendt, 2 = Afvist)</param>
        /// <param name="afleveringsdato">Udlån Afleveringsdato</param>
        /// <param name="udlåningsdato">Udlåndato, hvis ikke sætte, bliver det til nuværende tid(DateTime.Now)</param>
        /// <returns></returns>
        public string BesvarReservation(object udlån, int godkendelse, DateTime afleveringsdato, DateTime udlåningsdato = default(DateTime))
        {
            Udlån data = udlån as Udlån;

            if (udlåningsdato == default(DateTime))
            {
                udlåningsdato = DateTime.Now;
            }

            // Opdatere info
            data.godkendelse = godkendelse;
            data.afleveringsdato = afleveringsdato;
            data.udlåningsdato = udlåningsdato;

            // Administrator Id
            data.adminid = MedlemFacade.HentMedlemFacade().SessionBruger().medlemid;

            if (DBFacade.HentDatabaseFacade().OpdaterUdlån(data))
            {
                return "Udlån er skabt";
            }
            else
            {
                return "Udlån er ikke skabt";
            }
        }

        /// <summary>
        /// Brugerdefineret BesvarReservation
        /// <para>* Bruger til opdateret hele reservation set</para>
        /// </summary>
        /// <param name="udlånid"></param>
        /// <param name="medlemid"></param>
        /// <param name="adminid"></param>
        /// <param name="udlåningsdato"></param>
        /// <param name="afleveringsdato"></param>
        /// <param name="godkendelse"></param>
        /// <param name="aktivType"></param>
        /// <param name="aktivIDer"></param>
        /// <returns></returns>
        public string BesvarReservation(int udlånid, int medlemid, int adminid, DateTime udlåningsdato, DateTime afleveringsdato, int godkendelse, int aktivType, HashSet<Bog> bøger = null, HashSet<Udstyr> udstyr = null, HashSet<Lokale> lokaler = null, HashSet<Brætspil> brætspil = null)
        {
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(udlånid, DBFacade.HentDatabaseFacade().HentMedlem(medlemid), adminid, udlåningsdato, afleveringsdato, null, godkendelse, bøger, udstyr, lokaler, brætspil);
            string resultat = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var id in udstyr)
                    {
                        udl.Udstyr.Add(DBFacade.HentDatabaseFacade().HentUdstyr(id.udstyrid));
                    }
                    break;
                case 1:
                    foreach (var id in bøger)
                    {
                        udl.Bog.Add(DBFacade.HentDatabaseFacade().HentBog(id.bogid));
                    }
                    break;
                case 2:
                    foreach (var id in brætspil)
                    {
                        udl.Brætspil.Add(DBFacade.HentDatabaseFacade().HentBrætSpil(id.brætspilid));
                    }
                    break;
                case 3:
                    foreach (var id in lokaler)
                    {
                        udl.Lokale.Add(DBFacade.HentDatabaseFacade().HentLokale(id.lokaleid));
                    }
                    break;
                default:
                    resultat = "Aktiv Type findes ikke";
                    goto finish;
            }

            if (DBFacade.HentDatabaseFacade().OpdaterUdlån(udl))
            {
                resultat = "Udlån er skabt";
            }
            else
            {
                resultat = "Udlån er ikke skabt";
            }

        finish:
            return resultat;
        }

        public List<object> FindAlleUdlån()
        {
            return DBFacade.HentDatabaseFacade().FindAlleUdlån().ToList<object>();
        }

        //public List<Tuple<object, List<object>>> FindAlleUdlån()
        //{
        //    List<Tuple<object, List<object>>> resultater = new List<Tuple<object, List<object>>>();
        //    List<object> aktiver = new List<object>();
        //    List<Udlån> udlån = DBFacade.HentDatabaseFacade().FindAlleUdlån();

        //    if (udlån.Count>0)
        //    {
        //        foreach (Udlån item in udlån)
        //        {
        //            List<object> a = item.Aktiver.ToList<object>();
        //            Tuple<object, List<object>> b = new Tuple<object,List<object>>(item,a);
        //            resultater.Add(b);

        //        }

        //    }


        //    return resultater;
        //}

        public void BegyndVedligeholdelse()
        {
            Thread t = new Thread(new ThreadStart(DBFacade.HentDatabaseFacade().Vedligeholdelse));

            t.Start();
        }
        public void stopVedligeholdelse()
        {
            DBFacade.HentDatabaseFacade().Terminate();
        }
    }
}
