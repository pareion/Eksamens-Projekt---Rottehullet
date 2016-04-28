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
        private string _udstyrsNavn;
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

        public string UdstyrsNavn
        {
            get
            {
                return _udstyrsNavn;
            }

            private set
            {
                _udstyrsNavn = value;
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

        public Udstyr(int id, string udstyrsNavn, string kategori, string kommentar)
        {
            _id = id;
            _udstyrsNavn = udstyrsNavn;
            _kategori = kategori;
            Kommentar = kommentar;
        }
        public override string ToString()
        {
            return "ID: " + _id + " Udstyrsnavn: " + _udstyrsNavn + " Kategori: " + _kategori + " Kommentar: " + _kommentar;
        }
    }//Klasse
}//Namespace
