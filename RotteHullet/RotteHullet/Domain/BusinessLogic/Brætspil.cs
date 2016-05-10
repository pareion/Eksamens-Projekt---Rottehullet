﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Brætspil : IAktiv
    {
        private int _id;
        private string _brætspilsNavn;
        private string _udgiver;
        private string _kategori;
        private bool _udlånes;
        private string _kommentar;
        private bool _udlånt;

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

        public string BrætspilsNavn
        {
            get
            {
                return _brætspilsNavn;
            }

            private set
            {
                _brætspilsNavn = value;
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

        public Brætspil(int id, string brætspilsNavn, string udgiver,bool udlånes, string kommentar, string kategori = null, bool udlånt = false)
        {
            _id = id;
            _brætspilsNavn = brætspilsNavn;
            _udgiver = udgiver;
            _udlånes = udlånes;
            _kommentar = kommentar;
            _kategori = kategori;
            _udlånt = udlånt;
        }

        public override string ToString()
        {
            return "ID: " + _id + " Brætspilsnavn: " + _brætspilsNavn + " Udgiver: " + _udgiver + 
                " Udlånes: " + _udlånes + " Kommentar: " + _kommentar + " Kategori: " + _kategori;
        }

        public string ToString(int position)
        {
            switch (position)
            {
                case 0:
                    return  "" +_id;
                case 1:
                    return _brætspilsNavn;
                case 2:
                    return _udgiver;
                case 3:
                    return _udlånes.ToString();
                case 4:
                    return _kommentar;
                case 5:
                    return _kategori;
                default:
                    return ToString();
            }
        }
    }//Klasse
}//Namespace
