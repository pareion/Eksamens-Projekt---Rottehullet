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

        public Brætspil(int id, string navn, string udgiver)
        {
            this._id = id;
            this._navn = navn;
            this._udgiver = udgiver;
        }
    }
}
