using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

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
        /// <param name="medlemsid"></param>
        /// <param name="udlåningsdato"></param>
        /// <param name="afleveringsdato"></param>
        /// <param name="aktivType"></param>
        /// <param name="aktivIDer"></param>
        /// <returns></returns>
        public string ReserverAktiv(int medlemsid, DateTime udlåningsdato, DateTime afleveringsdato, int aktivType, List<int> aktivIDer)
        {
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(0,medlemsid,0,udlåningsdato,afleveringsdato,null,false,new List<IAktiv>());

            string resultat = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentUdstyr(id));
                    }
                    break;
                case 1:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBog(id));
                    }
                    break;
                case 2:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBrætSpil(id));
                    }
                    break;
                case 3:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentLokale(id));
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
        /// Kaldes når et bestyrelses medlem skal godkende en reservation
        /// </summary>
        /// <param name="udlånid"></param>
        /// <param name="medlemsid"></param>
        /// <param name="adminid"></param>
        /// <param name="udlåningsdato"></param>
        /// <param name="afleveringsdato"></param>
        /// <param name="godkendelse"></param>
        /// <param name="aktivType"></param>
        /// <param name="aktivIDer"></param>
        /// <returns></returns>
        public string BesvarReservation(int udlånid, int medlemsid, int adminid, DateTime udlåningsdato, DateTime afleveringsdato, bool godkendelse, int aktivType, List<int> aktivIDer)
        {
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(udlånid, medlemsid, adminid, udlåningsdato, afleveringsdato, null, godkendelse, new List<IAktiv>());
            string resultat = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentUdstyr(id));
                    }
                    break;
                case 1:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBog(id));
                    }
                    break;
                case 2:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBrætSpil(id));
                    }
                    break;
                case 3:
                    foreach (var id in aktivIDer)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentLokale(id));
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

        public List<Udlån> FindAlleUdlån()
        {
            return DBFacade.HentDatabaseFacade().FindAlleUdlån();
        }
    }
}
