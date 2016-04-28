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
        private string _lokaleNavn;
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

        public string LokaleNavn
        {
            get
            {
                return _lokaleNavn;
            }

            private set
            {
                _lokaleNavn = value;
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

        public Lokale(int id, string lokaleNavn, string lokation, string kommentar, string møbler)
        {
            _lokaleNavn = lokaleNavn;
            _lokation = lokation;
            _kommentar = kommentar;
            _møbler = møbler;
        }
        public override string ToString()
        {
            return "ID: " + _id + " Lokalenavn: " + _lokaleNavn + " Lokation: " + _lokation + 
                " Kommentar: " + _kommentar + " Møbler: " + _møbler;
        }

        public string ToString(int position)
        {
            switch (position)
            {
                case 0:
                    return "" + _id;
                case 1:
                    return _lokaleNavn;
                case 2:
                    return _lokation;
                case 3:
                    return _kommentar;
                case 4:
                    return _møbler;
                default:
                    return ToString();
            }
        }

    }//Klasse
}//Namespace
