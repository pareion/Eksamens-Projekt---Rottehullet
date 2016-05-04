﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udlån
    {
        private int _id;
        private int _medlemsid;
        private int _adminId;
        private DateTime _udlåningsdato;
        private DateTime _afleveringsdato;
        private DateTime? _reelleafleveringsdato;
        private bool _godkendt;
        private List<IAktiv> _aktiver;

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

        public int AdminId
        {
            get
            {
                return _adminId;
            }

            private set
            {
                _adminId = value;
            }
        }

        public DateTime Udlåningsdato
        {
            get
            {
                return _udlåningsdato;
            }

            private set
            {
                _udlåningsdato = value;
            }
        }

        public DateTime Afleveringsdato
        {
            get
            {
                return _afleveringsdato;
            }

            private set
            {
                _afleveringsdato = value;
            }
        }

        public bool Godkendt
        {
            get
            {
                return _godkendt;
            }

            private set
            {
                _godkendt = value;
            }
        }

        internal List<IAktiv> Aktiver
        {
            get
            {
                return _aktiver;
            }

            private set
            {
                _aktiver = value;
            }
        }
        #endregion

        public Udlån(int id, int medlemsid, int adminId, DateTime udlåningsdato, DateTime afleveringsdato, DateTime? reelleafleveringsdato, 
            bool godkendt, List<IAktiv> aktiver)
        {
            _id = id;
            _medlemsid = medlemsid;
            _adminId = adminId;
            _udlåningsdato = udlåningsdato;
            _afleveringsdato = afleveringsdato;
            _reelleafleveringsdato = reelleafleveringsdato;
            _godkendt = godkendt;
            _aktiver = aktiver;
        }
    }//Klasse
}//Namespace
