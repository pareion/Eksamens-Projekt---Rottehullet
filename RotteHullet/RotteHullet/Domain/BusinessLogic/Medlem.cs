using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace RotteHullet.Domain.BusinessLogic
{
    class Medlem
    {
        public enum MedlemType { Bruger, Bestyrelse }

        private int _id;
        private string _fornavn;
        private string _efternavn;
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

        public string Fornavn
        {
            get
            {
                return _fornavn;
            }

            set
            {
                _fornavn = value;
            }
        }

        public string Efternavn
        {
            get
            {
                return _efternavn;
            }

            set
            {
                _efternavn = value;
            }
        }
        #endregion

        public Medlem(int id, string fornavn, string efternavn, string brugernavn, 
            string password, string email, MedlemType status)
        {
            _id = id;
            _fornavn = fornavn;
            _efternavn = efternavn;
            _brugernavn = brugernavn;
            _password = password;
            _email = email;
            _status = status;
        }

    }//Klasse
}//Namespace
