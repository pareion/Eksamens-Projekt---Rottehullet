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
        private bool _udlånes;
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

        public bool Udlånes
        {
            get
            {
                return _udlånes;
            }

            private set
            {
                _udlånes = value;
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
            string familie, string forlag,bool udlånes, string kommentar = null)
        {
            _id = id;
            _titel = titel;
            _forfatter = forfatter;
            _genre = genre;
            _subkategori = subkategori;
            _familie = familie;
            _forlag = forlag;
            _udlånes = udlånes;
            _kommentar = kommentar;
        }

        public override string ToString()
        {
            return "ID: " + _id + " Titel: " + _titel + " Forfatter: " + _forfatter + " Genre: " + _genre
                   + " Subkategori: " + _subkategori + " Familie: " + _familie + " Forlag: " + _forlag + " Udlånes: " + _udlånes
                   + " Kommentar: " + _kommentar;
        }

        public string ToString(int position)
        {
            switch (position)
            {
                case 0:
                    return "" + _id;
                case 1:
                    return _titel;
                case 2:
                    return _forfatter;
                case 3:
                    return _genre;
                case 4:
                    return _subkategori;
                case 5:
                    return _familie;
                case 6:
                    return _forlag;
                case 7:
                    return _udlånes.ToString();
                case 8:
                    return _kommentar;
                default:
                    return ToString();
            }
        }

    }//Klasse
}//Namespace
