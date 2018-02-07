using System;
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

        public string SkabBrætSpil(int id, string navn, string udgiver, bool? udlånes, string kommentar, string kategori)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, navn, udgiver, udlånes, kommentar, kategori);
            if (DBEF.HentDBEF().GemBrætSpil(bs))
            {
                return "Brætspillet er skabt";
            }
            return "Brætspillet blev ikke skabt";
        }

        public string ÆndreBrætSpil(int id, string navn, string udgiver, bool udlånes,
            string kommentar, string kategori)
        {
            Brætspil bs = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, navn, udgiver, udlånes, kommentar, kategori);
            if (DBEF.HentDBEF().ÆndreBrætSpil(bs))
            {
                return "Brætspillet er ændret";
            }
            return "Brætspillet blev ikke ændret";
        }

        public List<object> FindAlleBrætspil(string søgeord = null) //Mangler søgning
        {
            List<Brætspil> aktiver = DBEF.HentDBEF().HentAlleBrætSpil();
            List<object> dataListe = new List<object>();

            if (søgeord == null)
            {
                aktiver = DBEF.HentDBEF().HentAlleBrætSpil();
            }
            else
            {
                Søgning.HentSøgning().SøgBrætspil(søgeord, out aktiver);
            }

            foreach (Brætspil item in aktiver)
            {
                dataListe.Add(item);
            }
            return dataListe;
        }

        public string SletBrætSpil(int id)
        {
            if (DBEF.HentDBEF().SletBrætSpil(id))
            {
                return "Brætspillet er slettet";
            }
            return "Brætspillet blev ikke slettet";
        }
    }
}
