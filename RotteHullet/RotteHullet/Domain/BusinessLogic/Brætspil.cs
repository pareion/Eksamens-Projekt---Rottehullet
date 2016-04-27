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

        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Udgiver
        {
            get
            {
                return _udgiver;
            }
        }
        public string Navn
        {
            get
            {
                return _navn;
            }
        }
        public string Kommentar
        {
            get
            {
                return _kommentar;
            }
        }

        public Brætspil(int id, string navn, string udgiver, string kommentar)
        {
            this._id = id;
            this._navn = navn;
            this._udgiver = udgiver;
            this._kommentar = kommentar;
        }
    }
}
