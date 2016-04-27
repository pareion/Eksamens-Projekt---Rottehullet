using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain.BusinessLogic
{
    class Medlem
    {
        public enum MedlemType { Bestyrelse, Bruger }

        private int _id;
        private string _brugernavn;
        private string _password;
        private string _email;
        private MedlemType _status;

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

        public string Brugernavn
        {
            get
            {
                return _brugernavn;
            }

            private set
            {
                _brugernavn = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            private set
            {
                _password = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            private set
            {
                _email = value;
            }
        }

        internal MedlemType Status
        {
            get
            {
                return _status;
            }

            private set
            {
                _status = value;
            }
        }
        #endregion

        public Medlem(int id, string brugernavn, string password, string email, MedlemType status)
        {
            _id = id;
            _brugernavn = brugernavn;
            _password = password;
            _email = email;
            _status = status;
        }
    }//Klasse
}//Namespace
