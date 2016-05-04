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
        /// aktivType 0 = udstyr, 1 = bøger, 2 = brætspil og 3 = lokaler
        /// </summary>
        /// <param name="medlemsid"></param>
        /// <param name="udlåningsdato"></param>
        /// <param name="afleveringsdato"></param>
        /// <param name="aktivType"></param>
        /// <param name="aktivider"></param>
        /// <returns></returns>
        public string SkabNyUdlån(int medlemsid, DateTime udlåningsdato, DateTime afleveringsdato, int aktivType, List<int> aktivider)
        {
            Udlån udl = AktivFactory.HentAktivFactory().SkabNytUdlån(0,medlemsid,0,udlåningsdato,afleveringsdato,null,false,null);

            string result = "";
            switch (aktivType)
            {
                case 0:
                    foreach (var item in aktivider)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentUdstyr(item));
                    }
                    break;
                case 1:
                    foreach (var item in aktivider)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBog(item));
                    }
                    break;
                case 2:
                    foreach (var item in aktivider)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentBrætSpil(item));
                    }
                    break;
                case 3:
                    foreach (var item in aktivider)
                    {
                        udl.Aktiver.Add(DBFacade.HentDatabaseFacade().HentLokale(item));
                    }
                    break;
                default:
                    result = "There is no such type";
                    goto finish;
            }
            result = DBFacade.HentDatabaseFacade().GemUdlån(udl);
            finish:
            return result;
        }
    }
}
