using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Udlån
    {
        public enum godkendelse { godkendt = 0, ikketagetstillingtil = 1, ikkegodkendt = 2};
        private int _id;
        private Medlem _medlem;
        private int _adminId;
        private DateTime _udlåningsdato;
        private DateTime _afleveringsdato;
        private DateTime? _reelleafleveringsdato;
        private godkendelse _godkendt;
        private List<IAktiv> _aktiver;

        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public Medlem Medlem
        {
            get
            {
                return _medlem;
            }

            set
            {
                _medlem = value;
            }
        }

        public int AdminId
        {
            get
            {
                return _adminId;
            }

            set
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

            set
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

            set
            {
                _afleveringsdato = value;
            }
        }

        public DateTime? Reelleafleveringsdato
        {
            get
            {
                return _reelleafleveringsdato;
            }

            set
            {
                _reelleafleveringsdato = value;
            }
        }

        internal List<IAktiv> Aktiver
        {
            get
            {
                return _aktiver;
            }

            set
            {
                _aktiver = value;
            }
        }

        public godkendelse Godkendt
        {
            get
            {
                return _godkendt;
            }

            set
            {
                _godkendt = value;
            }
        }
        #endregion

        public Udlån(int id, Medlem medlem, int adminId, DateTime udlåningsdato, 
            DateTime afleveringsdato, DateTime? reelleafleveringsdato, int godkendt, List<IAktiv> aktiver)
        {
            _id = id;
            _medlem = medlem;
            _adminId = adminId;
            _udlåningsdato = udlåningsdato;
            _afleveringsdato = afleveringsdato;
            _reelleafleveringsdato = reelleafleveringsdato;
            Godkendt = (godkendelse)godkendt;
            _aktiver = aktiver;
        }
    }//Klasse
}//Namespace
