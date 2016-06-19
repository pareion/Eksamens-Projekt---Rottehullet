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
        public Bog SkabNyBog(int id, string titel, string forfatter, string genre, string subkategori, string familie, string forlag, bool udlånes, string kommentar = null, bool udlånt = false)
        {
            Bog b = new Bog();
            b.bogid = id;
            b.titel = titel;
            b.forfatter = forfatter;
            b.genre = genre;
            b.subkategori = subkategori;
            b.familie = familie;
            b.forlag = forlag;
            b.udlånes = udlånes;
            b.kommentar = kommentar;
            b.udlånt = udlånt;
            return b;
        }

        //Lokale
        public Lokale SkabNytLokale(int id, string navn, string lokation, bool udlånes, string kommentar, string møbler, bool udlånt = false)
        {
            Lokale l = new Lokale();
            l.lokaleid = id;
            l.lokalenavn = navn;
            l.lokation = lokation;
            l.udlånes = udlånes;
            l.kommentar = kommentar;
            l.møbler = møbler;
            l.udlånt = udlånt;
            return l;
        }

        //Brætspil
        public Brætspil SkabNyBrætspil(int id, string navn, string udgiver, bool? udlånes, string kommentar, string kategori, bool udlånt = false)
        {
            Brætspil b = new Brætspil();
            b.brætspilid = id;
            b.brætspilnavn = navn;
            b.udgiver = udgiver;
            b.udlånes = udlånes;
            b.kommentar = kommentar;
            b.kategori = kategori;
            b.udlånt = udlånt;
            return b;
        }

        //Udstyr
        public Udstyr SkabNytUdstyr(int id, string navn, string kategori, bool udlånes, string kommentar, bool udlånt = false)
        {
            Udstyr u = new Udstyr();
            u.udstyrid = id;
            u.navn = navn;
            u.kategori = kategori;
            u.udlånes = udlånes;
            u.kommentar = kommentar;
            u.udlånt = udlånt;
            return u;
        }

        //Udlån
        public Udlån SkabNytUdlån(int id, Medlem medlem, int adminid, DateTime udlåningsdato, DateTime afleveringsdato, DateTime? reelleafleveringsdato,
            int godkendelse, HashSet<Bog> bøger = null, HashSet<Udstyr> udstyr = null, HashSet<Lokale> lokaler = null, HashSet<Brætspil> brætspil = null)
        {
            Udlån u = new Udlån();
            u.medlemid = id;
            u.Medlem1 = medlem;
            u.adminid = adminid;
            u.udlåningsdato = udlåningsdato;
            u.afleveringsdato = afleveringsdato;
            u.reeleafleveringsdato = reelleafleveringsdato;
            u.godkendelse = godkendelse;
            u.Bog = bøger;
            u.Udstyr = udstyr;
            u.Lokale = lokaler;
            u.Brætspil = brætspil;
            return u;
        }
    }
}
