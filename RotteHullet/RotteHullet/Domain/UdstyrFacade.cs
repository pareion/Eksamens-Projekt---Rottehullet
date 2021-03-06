﻿using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class UdstyrFacade
    {
        private static UdstyrFacade _udstyrFacade;

        public static UdstyrFacade HentUdstyrFacade()
        {
            if (_udstyrFacade == null)
            {
                _udstyrFacade = new UdstyrFacade();
            }
            return _udstyrFacade;
        }

        public string SkabUdstyr(int id, string navn, string kategori, bool udlånes, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, navn, kategori, udlånes, kommentar);
            if (DBEF.HentDBEF().GemUdstyr(uds))
            {
                return "Udstyret er skabt";
            }
            return "Udstyret blev ikke skabt";
        }

        public string ÆndreUdstyr(int id, string navn, string kategori, bool udlånes, string kommentar)
        {
            Udstyr uds = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, navn, kategori, udlånes, kommentar);
            if (DBEF.HentDBEF().ÆndreUdstyr(uds))
            {
                return "Udstyret er ændret";
            }
            return "Udstyret blev ikke ændret";
        }

        public List<object> FindAlleUdstyr(string søgeord = null)
        {
            List<Udstyr> aktiver = DBEF.HentDBEF().HentALtUdstyr();
            List<object> dataListe = new List<object>();

            if (søgeord == null)
            {
                aktiver = DBEF.HentDBEF().HentALtUdstyr();
            }
            else
            {
                Søgning.HentSøgning().SøgUdstyr(søgeord, out aktiver);
            }

            foreach (Udstyr item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletUdstyr(int id)
        {
            if (DBEF.HentDBEF().SletUdstyr(id))
            {
                return "Udstyret er slettet";
            }
            return "Udstyret blev ikke slettet";
        }
    }
}
