using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet.Data
{
    class DBEF : IDBFacade
    {
        #region variables
        private static DBEF _dbef;
        #endregion
        #region constructors
        private DBEF()
        {

        }
        #endregion
        #region methods
        internal static IDBFacade HentDBEFFacade()
        {
            if (_dbef == null)
            {
                _dbef = new DBEF();
            }
            return _dbef;
        }
        public List<Udlån> FindAlleUdlån()
        {
            throw new NotImplementedException();
        }
        public bool GemBog(Bog bog)
        {
            throw new NotImplementedException();
        }
        public bool GemBrætSpil(Brætspil bs)
        {
            throw new NotImplementedException();
        }
        public bool GemLokale(Lokale lokale)
        {
            throw new NotImplementedException();
        }
        public bool GemUdlån(Udlån udl)
        {
            throw new NotImplementedException();
        }
        public bool GemUdstyr(Udstyr udstyr)
        {
            throw new NotImplementedException();
        }
        public List<Brætspil> HentAlleBrætSpil()
        {
            throw new NotImplementedException();
        }
        public List<Bog> HentAlleBøger()
        {
            throw new NotImplementedException();
        }
        public List<Lokale> HentAlleLokaler()
        {
            throw new NotImplementedException();
        }
        public List<Udstyr> HentALtUdstyr()
        {
            throw new NotImplementedException();
        }
        public Bog HentBog(int id)
        {
            throw new NotImplementedException();
        }
        public Brætspil HentBrætSpil(int id)
        {
            throw new NotImplementedException();
        }
        public Lokale HentLokale(int id)
        {
            throw new NotImplementedException();
        }
        public Medlem HentMedlem(int id)
        {
            throw new NotImplementedException();
        }
        public Medlem HentMedlem(string brugernavn, string password)
        {
            throw new NotImplementedException();
        }
        public Udstyr HentUdstyr(int id)
        {
            throw new NotImplementedException();
        }
        public bool OpdaterUdlån(Udlån udl)
        {
            throw new NotImplementedException();
        }
        public bool SletBog(int id)
        {
            throw new NotImplementedException();
        }
        public bool SletBrætSpil(int id)
        {
            throw new NotImplementedException();
        }
        public bool SletLokale(int id)
        {
            throw new NotImplementedException();
        }
        public bool SletUdstyr(int id)
        {
            throw new NotImplementedException();
        }
        public void Terminate()
        {
            throw new NotImplementedException();
        }
        public void Vedligeholdelse()
        {
            throw new NotImplementedException();
        }
        public bool ÆndreBog(Bog bog)
        {
            throw new NotImplementedException();
        }
        public bool ÆndreBrætSpil(Brætspil bs)
        {
            throw new NotImplementedException();
        }
        public bool ÆndreLokale(Lokale lokale)
        {
            throw new NotImplementedException();
        }
        public bool ÆndreUdstyr(Udstyr udstyr)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
