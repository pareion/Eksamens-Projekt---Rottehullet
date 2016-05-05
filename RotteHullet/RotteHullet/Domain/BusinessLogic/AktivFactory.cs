using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class AktivFactory
    {
        private static AktivFactory _aktivFactory;

        public static AktivFactory HentAktivFactory()
        {
            if (_aktivFactory == null)
            {
                _aktivFactory = new AktivFactory();
            }
            return _aktivFactory;
        }

        //Bog
        public Bog SkabNyBog(int id, string titel, string forfatter, string genre, string subkategori, string familie, string forlag, bool udlånes, string kommentar = null)
        {
            return new Bog(id, titel, forfatter, genre, subkategori, familie, forlag, udlånes, kommentar);
        }

        //Lokale
        public Lokale SkabNytLokale(int id, string navn, string lokation, bool udlånes, string kommentar, string møbler)
        {
            return new Lokale(id, navn, lokation, udlånes, kommentar, møbler);
        }

        //Brætspil
        public Brætspil SkabNyBrætspil(int id, string navn, string udgiver, bool udlånes, string kommentar, string kategori)
        {
            return new Brætspil(id, navn,udgiver, udlånes, kommentar, kategori);
        }

        //Udstyr
        public Udstyr SkabNytUdstyr(int id, string navn, string kategori, bool udlånes, string kommentar)
        {
            return new Udstyr(id, navn, kategori, udlånes, kommentar);
        }

        //Udlån
        public Udlån SkabNytUdlån(int id, int medlemsid, int adminid, DateTime udlåningsdato, DateTime afleveringsdato, DateTime? reelleafleveringsdato, bool godkendelse, List<IAktiv> aktivider)
        {
            return new Udlån(id, medlemsid, adminid, udlåningsdato, afleveringsdato, reelleafleveringsdato, godkendelse, aktivider);
        }
    }
}
