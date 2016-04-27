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

        public Brætspil(int id, string navn, string udgiver, string kommentar)
        {
            _id = id;
            _navn = navn;
            _udgiver = udgiver;
            _kommentar = kommentar;
        }
    }//Klasse
}//Namespace
