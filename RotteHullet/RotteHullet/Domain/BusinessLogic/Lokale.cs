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
        private int _størrelse;
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
        public int Størrelse
        {
            get
            {
                return _størrelse;
            }
        }
        public string Møbler
        {
            get
            {
                return _møbler;
            }
        }

        public Lokale(int id, string navn, string lokation, int størrelse, string møbler)
        {
            this._id = id;
            this._navn = navn;
            this._lokation = lokation;
            this._størrelse = størrelse;
            this._møbler = møbler;
        }
    }
}
