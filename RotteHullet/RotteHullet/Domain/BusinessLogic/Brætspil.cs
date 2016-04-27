using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Brætspil : IAktiv
    {
        private int _id;
        private string _navn;
        private string _udgiver;
        private string _kommentar;

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

        public string Udgiver
        {
            get
            {
                return _udgiver;
            }

            private set
            {
                _udgiver = value;
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
        /// Constructor til skabelse af Brætspil fra UI
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="udgiver"></param>
        /// <param name="kommentar"></param>
        public Brætspil(string navn, string udgiver, string kommentar)
        {
            _navn = navn;
            _udgiver = udgiver;
            _kommentar = kommentar;
        }

        /// <summary>
        /// Constructor til skabelse af Brætspil fra database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="navn"></param>
        /// <param name="udgiver"></param>
        /// <param name="kommentar"></param>
        public Brætspil(int id, string navn, string udgiver, string kommentar)
            :this(navn, udgiver, kommentar)
        {
            this._id = id;
        }
        #endregion

    }//Klasse
}//Namespace
