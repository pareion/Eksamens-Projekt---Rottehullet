using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Bog : IAktiv
    {
        private int _id;
        private string _titel;
        private string _forfatter;
        private string _genre;
        private string _subkategori;
        private string _familie;
        private string _forlag;
        private string _kommentar;

        #region properties
        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public string Titel
        {
            get
            {
                return _titel;
            }

            private set
            {
                _titel = value;
            }
        }

        public string Forfatter
        {
            get
            {
                return _forfatter;
            }

            private set
            {
                _forfatter = value;
            }
        }

        public string Genre
        {
            get
            {
                return _genre;
            }

            private set
            {
                _genre = value;
            }
        }

        public string Subkategori
        {
            get
            {
                return _subkategori;
            }

            private set
            {
                _subkategori = value;
            }
        }

        public string Familie
        {
            get
            {
                return _familie;
            }

            private set
            {
                _familie = value;
            }
        }

        public string Forlag
        {
            get
            {
                return _forlag;
            }

            private set
            {
                _forlag = value;
            }
        }

        public string Kommentar
        {
            get
            {
                return _kommentar;
            }

            private set
            {
                _kommentar = value;
            }
        }
        #endregion

        public Bog(int id, string titel, string forfatter, string genre, string subkategori,
            string familie, string forlag, string kommentar = null)
        {
            _id = id;
            _titel = titel;
            _forfatter = forfatter;
            _genre = genre;
            _subkategori = subkategori;
            _familie = familie;
            _forlag = forlag;
            _kommentar = kommentar;
        }

        //Test om et bog objekt er ens med et andet
        public bool ErSammeBog(Bog bog)
        { 
            if (bog.Id == Id && bog.Familie == Familie && bog.Forfatter == Forfatter
                && bog.Forlag == Forlag && bog.Genre == Genre && bog.Kommentar == Kommentar
                && bog.Subkategori == Subkategori && bog.Titel == Titel)
            {
                return true;
            }
            return false;
        }
    }//Klasse
}//Namespace
