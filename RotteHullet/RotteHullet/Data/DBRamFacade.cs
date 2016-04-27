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

        public bool GemBrætSpil(Brætspil bs)
        {
            _brætspilsListe.Add(bs);
            return true;
        }

        public bool ÆndreBrætSpil(int gammeltID, Brætspil bs)
        {
            //from brætSpil in _brætspilsListe
            //where brætSpil.Id == gammeltID
            //select 
            throw new NotImplementedException();
        }

        public Brætspil HentBrætSpil(int id)
        {
            throw new NotImplementedException();
        }

        public bool SletBrætSpil(int id)
        {
            throw new NotImplementedException();
        }

        public bool GemBog(Bog bog)
        {
            _bogListe.Add(bog);
            return true;
        }

        public bool ÆndreBog(int gammeltID, Bog bog)
        {
            throw new NotImplementedException();
        }

        public Bog HentBog(int id)
        {
            throw new NotImplementedException();
        }

        public bool SletBog(int id)
        {
            throw new NotImplementedException();
        }

        public bool GemUdstyr(Udstyr udstyr)
        {
            _udstyrsListe.Add(udstyr);
            return true;
        }

        public bool ÆndreUdstyr(int gammeltID, Udstyr udstyr)
        {
            throw new NotImplementedException();
        }

        public Udstyr HentUdstyr(int id)
        {
            throw new NotImplementedException();
        }

        public bool SletUdstyr(int id)
        {
            throw new NotImplementedException();
        }

        public bool GemLokale(Lokale lokale)
        {
           _lokaleListe.Add(lokale);
            return true;
        }

        public bool ÆndreLokale(int gammeltID, Lokale lokale)
        {
            throw new NotImplementedException();
        }

        public Lokale HentLokale(int id)
        {
            throw new NotImplementedException();
        }

        public bool SletLokale(int id)
        {
            throw new NotImplementedException();
        }

        #region Constructor
        public DBRamFacade()
        {
            _bogListe = new List<Bog>();
            _brætspilsListe = new List<Brætspil>();
            _udstyrsListe = new List<Udstyr>();
            _lokaleListe = new List<Lokale>();
        }
        #endregion

        

        
    }
}
