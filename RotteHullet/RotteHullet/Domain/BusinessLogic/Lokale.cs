using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Lokale : IAktiv
    {
        private int _id;
        private string _navn;
        private string _lokation;
        private string _kommentar;
        private string _møbler;

        #region Properties
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

        public string Navn
        {
            get
            {
                return _navn;
            }

            private set
            {
                _navn = value;
            }
        }

        public string Lokation
        {
            get
            {
                return _lokation;
            }

            private set
            {
                _lokation = value;
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

        public string Møbler
        {
            get
            {
                return _møbler;
            }

            private set
            {
                _møbler = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor til skabelse af lokale fra UI
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="lokation"></param>
        /// <param name="kommentar"></param>
        /// <param name="møbler"></param>
        public Lokale(string navn, string lokation, string kommentar, string møbler)
        {
            _navn = navn;
            _lokation = lokation;
            _kommentar = kommentar;
            _møbler = møbler;
        }

        /// <summary>
        /// Constructor til skabelse af lokale fra database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="navn"></param>
        /// <param name="lokation"></param>
        /// <param name="kommentar"></param>
        /// <param name="møbler"></param>
        public Lokale(int id, string navn, string lokation, string kommentar, string møbler)
            :this(navn, lokation, kommentar, møbler)
        {
            _id = id;
        }
        #endregion

    }//Klasse
}//Namespace
