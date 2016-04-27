using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udstyr : IAktiv
    {
        private int _id;
        private string _navn;
        private string _kategori;
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

        public string Kategori
        {
            get
            {
                return _kategori;
            }

            private set
            {
                _kategori = value;
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

        public Udstyr(int id, string navn, string kategori, string kommentar)
        {
            _id = id;
            _navn = navn;
            _kategori = kategori;
            Kommentar = kommentar;
        }
    }//Klasse
}//Namespace
