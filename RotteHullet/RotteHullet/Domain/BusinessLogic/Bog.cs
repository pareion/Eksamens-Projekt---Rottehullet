using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Bog : IAktiv
    {
        private int id { get; set; }
        private string titel { get; set; }
        private string forfatter { get; set; }
        private string genre { get; set; }
        private string subkategori { get; set; }
        private string isbn { get; set; }
        private string familie { get; set; }
        private string forlag { get; set; }
        private string kommentar { get; set; }

        public Bog()
        {}
        public Bog(string titel, string forfatter, string genre, string subkategori, string familie, string forlag, string isbn, string kommentar = null)
        {
            this.titel = titel;
            this.forfatter = forfatter;
            this.genre = genre;
            this.subkategori = subkategori;
            this.familie = familie;
            this.forlag = forlag;
            this.isbn = isbn;
            this.kommentar = kommentar;
        }
        public Bog(int id, string titel, string forfatter, string genre, string subkategori, string familie, string forlag, string isbn, string kommentar = null)
        {
            this.id = id;
            this.titel = titel;
            this.forfatter = forfatter;
            this.genre = genre;
            this.subkategori = subkategori;
            this.familie = familie;
            this.forlag = forlag;
            this.isbn = isbn;
            this.kommentar = kommentar;
        }
    }
}
