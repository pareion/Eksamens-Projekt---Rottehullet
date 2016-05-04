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
        private bool _udlånes;

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

        public Udstyr(int id, string udstyrsNavn, string kategori,bool udlånes, string kommentar)
        {
            _id = id;
            _udstyrsNavn = udstyrsNavn;
            _kategori = kategori;
            _udlånes = udlånes;
            Kommentar = kommentar;
        }

        public override string ToString()
        {
            return "ID: " + _id + " Udstyrsnavn: " + _udstyrsNavn + " Kategori: " + _kategori + " Udlånes: " + _udlånes
                + " Kommentar: " + _kommentar;
        }

        public string ToString(int position)
        {
            switch (position)
            {
                case 0:
                    return "" + _id;
                case 1:
                    return _udstyrsNavn;
                case 2:
                    return _kategori;
                case 3:
                    return _udlånes.ToString();
                case 4:
                    return _kommentar;
                default:
                    return ToString();
            }
        }

    }//Klasse
}//Namespace
