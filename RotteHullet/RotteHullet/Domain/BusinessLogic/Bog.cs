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

        #region Constructors
        /// <summary>
        /// Constructor til oprettelse af Bog fra UI
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="forfatter"></param>
        /// <param name="genre"></param>
        /// <param name="subkategori"></param>
        /// <param name="familie"></param>
        /// <param name="forlag"></param>
        /// <param name="kommentar"></param>
        public Bog(string titel, string forfatter, string genre, string subkategori,
            string familie, string forlag, string kommentar = null)
        {
            _titel = titel;
            _forfatter = forfatter;
            _genre = genre;
            _subkategori = subkategori;
            _familie = familie;
            _forlag = forlag;
            _kommentar = kommentar;
        }
        /// <summary>
        /// Constructor til oprettelse af bog fra Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titel"></param>
        /// <param name="forfatter"></param>
        /// <param name="genre"></param>
        /// <param name="subkategori"></param>
        /// <param name="familie"></param>
        /// <param name="forlag"></param>
        /// <param name="kommentar"></param>
        public Bog(int id, string titel, string forfatter, string genre, string subkategori,
            string familie, string forlag, string kommentar = null)
            : this(titel, forfatter, genre, subkategori, familie, forlag, kommentar)
        {
            _id = id;
        }
        #endregion

    }//Klasse
}//Namespace
