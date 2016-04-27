using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udstyr : IAktiv
    {
        public enum UdstyrStørrelse { Lille, Mellem, Stor, EkstraStor }

        private int _id;
        private string _navn;
        private string _kategori;
        private UdstyrStørrelse _størrelse;

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

        internal UdstyrStørrelse Størrelse
        {
            get
            {
                return _størrelse;
            }

            private set
            {
                _størrelse = value;
            }
        }
        #endregion

    }//Klasse
}//Namespace
