using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;
using System.Threading;

namespace RotteHullet.Data
{
    class DBEF : IDBFacade
    {
        #region variables
        private static DBEF _dbef;
        private bool _running;
        #endregion
        #region constructors
        private DBEF()
        {
            _running = true;
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
            return new EJL52_DBEntities().Udlån.ToList<Udlån>();
        }
        public bool GemBog(Bog bog)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Bog.Count() + 1;
            bool result = false;

            ejl.Bog.Add(bog);
            
            if (ejl.Bog.Count() == count)
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool GemBrætSpil(Brætspil bs)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Brætspil.Count() + 1;
            bool result = false;

            ejl.Brætspil.Add(bs);

            if (ejl.Brætspil.Count() == count)
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool GemLokale(Lokale lokale)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Lokale.Count() + 1;
            bool result = false;

            ejl.Lokale.Add(lokale);

            if (ejl.Lokale.Count() == count)
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool GemUdlån(Udlån udl)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Udlån.Count() + 1;
            bool result = false;

            ejl.Udlån.Add(udl);

            if (ejl.Udlån.Count() == count)
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool GemUdstyr(Udstyr udstyr)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Udstyr.Count() + 1;
            bool result = false;

            ejl.Udstyr.Add(udstyr);

            if (ejl.Udstyr.Count() == count)
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public List<Brætspil> HentAlleBrætSpil()
        {
            return new EJL52_DBEntities().Brætspil.ToList<Brætspil>();
        }
        public List<Bog> HentAlleBøger()
        {
            return new EJL52_DBEntities().Bog.ToList();
        }
        public List<Lokale> HentAlleLokaler()
        {
            return new EJL52_DBEntities().Lokale.ToList<Lokale>();
        }
        public List<Udstyr> HentALtUdstyr()
        {
            return new EJL52_DBEntities().Udstyr.ToList<Udstyr>();
        }
        public Bog HentBog(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Bog b = new Bog();

            foreach (var item in ejl.Bog)
            {
                if (item.bogid == id)
                {
                    b = item;
                    break;
                }
            }

            return b;
        }
        public Brætspil HentBrætSpil(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Brætspil b = new Brætspil();

            foreach (var item in ejl.Brætspil)
            {
                if (item.brætspilid == id)
                {
                    b = item;
                    break;
                }
            }

            return b;
        }
        public Lokale HentLokale(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Lokale l = new Lokale();

            foreach (var item in ejl.Lokale)
            {
                if (item.lokaleid == id)
                {
                    l = item;
                    break;
                }
            }

            return l;
        }
        public Medlem HentMedlem(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Medlem m = new Medlem();

            foreach (var item in ejl.Medlem)
            {
                if (item.medlemid == id)
                {
                    m = item;
                    break;
                }
            }

            return m;
        }
        public Medlem HentMedlem(string brugernavn, string password)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Medlem m = new Medlem();

            foreach (var item in ejl.Medlem)
            {
                if (item.brugernavn == brugernavn && item.adgangskode == password)
                {
                    m = item;
                    break;
                }
            }

            return m;
        }
        public Udstyr HentUdstyr(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            Udstyr u = new Udstyr();

            foreach (var item in ejl.Udstyr)
            {
                if (item.udstyrid == id)
                {
                    u = item;
                    break;
                }
            }

            return u;
        }
        public bool OpdaterUdlån(Udlån udl)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int beforecount = ejl.Udlån.Count() - 1;
            int aftercount = ejl.Udlån.Count();
            bool result = false;

            ejl.Udlån.Remove(ejl.Udlån.ToList().Find(x => x.udlånid == udl.udlånid));

            if (beforecount == ejl.Udlån.Count())
            {
                ejl.Udlån.Add(udl);
                if (aftercount== ejl.Udlån.Count())
                {
                    ejl.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public bool SletBog(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Bog.Count() - 1;
            bool result = false;

            ejl.Bog.Remove(ejl.Bog.ToList().Find(x => x.bogid == id));

            if (count == ejl.Bog.Count())
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool SletBrætSpil(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Brætspil.Count() - 1;
            bool result = false;

            ejl.Brætspil.Remove(ejl.Brætspil.ToList().Find(x => x.brætspilid == id));

            if (count == ejl.Brætspil.Count())
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool SletLokale(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Lokale.Count() - 1;
            bool result = false;

            ejl.Lokale.Remove(ejl.Lokale.ToList().Find(x => x.lokaleid == id));

            if (count == ejl.Lokale.Count())
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool SletUdstyr(int id)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int count = ejl.Udstyr.Count() - 1;
            bool result = false;

            ejl.Udstyr.Remove(ejl.Udstyr.ToList().Find(x => x.udstyrid == id));

            if (count == ejl.Udstyr.Count())
            {
                ejl.SaveChanges();
                result = true;
            }

            return result;
        }
        public void Terminate()
        {
            _running = false;
        }
        /// <summary>
        /// Removes all old reservationens and reservations there have gone through but it only removes 1 each 10 second at max
        /// </summary>
        public void Vedligeholdelse()
        {
            while (_running)
            {
                EJL52_DBEntities ejl = new EJL52_DBEntities();
                Udlån udlån = ejl.Udlån.ToList().Find(x => x.godkendelse == 2 || x.reeleafleveringsdato < DateTime.Now.AddDays(5));
                if (udlån != null)
                {
                    ejl.Udlån.Remove(udlån);
                    ejl.SaveChanges();
                }
                Thread.Sleep(10000);
            }
        }
        public bool ÆndreBog(Bog bog)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int beforecount = ejl.Bog.Count() - 1;
            int aftercount = ejl.Bog.Count();
            bool result = false;

            ejl.Bog.Remove(ejl.Bog.ToList().Find(x => x.bogid == bog.bogid));

            if (beforecount == ejl.Bog.Count())
            {
                ejl.Bog.Add(bog);
                if (aftercount == ejl.Bog.Count())
                {
                    ejl.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public bool ÆndreBrætSpil(Brætspil bs)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int beforecount = ejl.Brætspil.Count() - 1;
            int aftercount = ejl.Brætspil.Count();
            bool result = false;

            ejl.Brætspil.Remove(ejl.Brætspil.ToList().Find(x => x.brætspilid == bs.brætspilid));

            if (beforecount == ejl.Brætspil.Count())
            {
                ejl.Brætspil.Add(bs);
                if (aftercount == ejl.Brætspil.Count())
                {
                    ejl.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public bool ÆndreLokale(Lokale lokale)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int beforecount = ejl.Lokale.Count() - 1;
            int aftercount = ejl.Lokale.Count();
            bool result = false;

            ejl.Lokale.Remove(ejl.Lokale.ToList().Find(x => x.lokaleid == lokale.lokaleid));

            if (beforecount == ejl.Lokale.Count())
            {
                ejl.Lokale.Add(lokale);
                if (aftercount == ejl.Lokale.Count())
                {
                    ejl.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public bool ÆndreUdstyr(Udstyr udstyr)
        {
            EJL52_DBEntities ejl = new EJL52_DBEntities();
            int beforecount = ejl.Udstyr.Count() - 1;
            int aftercount = ejl.Udstyr.Count();
            bool result = false;

            ejl.Udstyr.Remove(ejl.Udstyr.ToList().Find(x => x.udstyrid == udstyr.udstyrid));

            if (beforecount == ejl.Udstyr.Count())
            {
                ejl.Udstyr.Add(udstyr);
                if (aftercount == ejl.Udstyr.Count())
                {
                    ejl.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        #endregion
    }
}
