using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security;

namespace RotteHulletMvvm.Models
{
    class Medlem: Model
    {
        private string _email = null;

        public enum MedlemType { Bestyrelse, Bruger }
        public string Brugernavn { get; set; }
        public SecureString Password { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Fuldnavn
        {
            get
            {
                return string.Format("{0} {1}", Fornavn, Efternavn);
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length < 256)
                {
                    string mail = value.ToString();
                    if (Regex.IsMatch(mail, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    {
                        _email = mail;
                    }
                    else
                    {
                        throw new VerificationException("Forkert e-mail format");
                    }
                }
                else
                {
                    throw new Exception("E-mail er for lang");
                }
            }
        }

        #region Constructor
        public Medlem() { }
        /// <summary>
        /// New Medlem Constructor
        /// </summary>
        /// <param name="brugernavn">Max length 64</param>
        /// <param name="password">No limit, lower than 1 Megabyte for better performance</param>
        /// <param name="fornavn">Max 256 characters</param>
        /// <param name="efternavn">Max 256 characters</param>
        public Medlem(string brugernavn, string password, string fornavn, string efternavn, string email) : this(0, brugernavn, castPassword(password), fornavn, efternavn, email) { }
        /// <summary>
        /// New Medlem Constructor
        /// </summary>
        /// <param name="brugernavn">Max length 64</param>
        /// <param name="password">No limit, lower than 1 Megabyte for better performance</param>
        /// <param name="fornavn">Max 256 characters</param>
        /// <param name="efternavn">Max 256 characters</param>
        public Medlem(string brugernavn, SecureString password, string fornavn, string efternavn, string email) : this(0, brugernavn, password, fornavn, efternavn, email) { }
        /// <summary>
        /// Exist Medlem Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brugernavn">Max length 64</param>
        /// <param name="fornavn">Max 256 characters</param>
        /// <param name="efternavn">Max 256 characters</param>
        /// <param name="email">Max 256 characters</param>
        public Medlem(int id, string brugernavn, string fornavn, string efternavn, string email) : this(id, brugernavn, null, fornavn, efternavn, email) { }
        /// <summary>
        /// Full Medlem Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brugernavn">Max length 64</param>
        /// <param name="password">No limit, lower than 1 Megabyte for better performance</param>
        /// <param name="fornavn">Max 256 characters</param>
        /// <param name="efternavn">Max 256 characters</param>
        /// <param name="email">Max 256 characters</param>
        public Medlem(int id, string brugernavn, SecureString password, string fornavn, string efternavn, string email) : base(id)
        {
            Brugernavn = brugernavn;
            Password = password;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Email = email;
        }
        #endregion

        private static SecureString castPassword(string password)
        {
            SecureString secureData = new SecureString();
            foreach (char letter in password)
            {
                secureData.AppendChar(letter);
            }
            return secureData;
        }
    }
}
