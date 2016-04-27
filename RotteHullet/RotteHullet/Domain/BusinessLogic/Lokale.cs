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

        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Navn
        {
            get
            {
                return _navn;
            }
        }
        public string Lokation
        {
            get
            {
                return _lokation;
            }
        }
        public string Møbler
        {
            get
            {
                return _møbler;
            }
        }
        public string Kommentar
        {
            get
            {
                return _kommentar;
            }
        }

        public Lokale(int id, string navn, string lokation, string kommentar, string møbler)
        {
            this._id = id;
            this._navn = navn;
            this._lokation = lokation;
            this._kommentar = kommentar;
            this._møbler = møbler;
        }
    }
}
