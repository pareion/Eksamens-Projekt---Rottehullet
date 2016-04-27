using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet.Data
{
    class DBRamFacade : IDBFacade
    {
        private static DBRamFacade _dbRamFacade;
        private List<Bog> _bogListe;
        private List<Brætspil> _brætspilsListe;
        private List<Udstyr> _udstyrsListe;
        private List<Lokale> _lokaleListe;

        #region Constructor
        public DBRamFacade()
        {
            _bogListe = new List<Bog>();
            _brætspilsListe = new List<Brætspil>();
            _udstyrsListe = new List<Udstyr>();
            _lokaleListe = new List<Lokale>();
        }
        #endregion

        /// <summary>
        /// Statisk metode som returner den instans af facaden. Laver en ny, hvis den ikke eksisterer.
        /// </summary>
        /// <returns></returns>
        public static DBRamFacade HentDbRamFacade()
        {
            if (_dbRamFacade == null)
            {
                _dbRamFacade = new DBRamFacade();
            }
            return _dbRamFacade;
        }

        #region Brætspil
        public bool GemBrætSpil(Brætspil bs)
        {
            _brætspilsListe.Add(bs);
            return true;
        }
        public bool ÆndreBrætSpil(int gammeltID, Brætspil bs)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == gammeltID)
                {
                    _brætspilsListe[i] = bs;
                    return true;
                }
            }
            return false;
        }

        public Brætspil HentBrætSpil(int id)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == id)
                {
                    return _brætspilsListe[i];
                }
            }
            return null;
        }

        public List<Brætspil> HentAlleBrætSpil()
        {
            return _brætspilsListe;
        }

        public bool SletBrætSpil(int id)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == id)
                {
                    _brætspilsListe.Remove(_brætspilsListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Bog
        public bool GemBog(Bog bog)
        {
            _bogListe.Add(bog);
            return true;
        }

        public bool ÆndreBog(int gammeltID, Bog bog)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == gammeltID)
                {
                    _bogListe[i] = bog;
                    return true;
                }
            }
            return false;
        }

        public Bog HentBog(int id)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == id)
                {
                    return _bogListe[i];
                }
            }
            return null;
        }

        public bool SletBog(int id)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == id)
                {
                    _bogListe.Remove(_bogListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Udstyr
        public bool GemUdstyr(Udstyr udstyr)
        {
            _udstyrsListe.Add(udstyr);
            return true;
        }

        public bool ÆndreUdstyr(int gammeltID, Udstyr udstyr)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == gammeltID)
                {
                    _udstyrsListe[i] = udstyr;
                    return true;
                }
            }
            return false;
        }

        public Udstyr HentUdstyr(int id)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == id)
                {
                    return _udstyrsListe[i];
                }
            }
            return null;
        }

        public bool SletUdstyr(int id)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == id)
                {
                    _udstyrsListe.Remove(_udstyrsListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Lokale
        public bool GemLokale(Lokale lokale)
        {
            _lokaleListe.Add(lokale);
            return true;
        }

        public bool ÆndreLokale(int gammeltID, Lokale lokale)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == gammeltID)
                {
                    _lokaleListe[i] = lokale;
                    return true;
                }
            }
            return false;
        }

        public Lokale HentLokale(int id)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == id)
                {
                    return _lokaleListe[i];
                }
            }
            return null;
        }

        public List<Lokale> HentAlleLokaler()
        {
            return _lokaleListe;
        }

        public bool SletLokale(int id)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == id)
                {
                    _lokaleListe.Remove(_lokaleListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

    }//Klasse
}//Namespace
