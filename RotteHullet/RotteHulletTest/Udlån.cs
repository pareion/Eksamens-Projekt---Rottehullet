using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletTest
{
    [TestClass]
    class Udlån
    {
        [TestMethod]
        public void TestUdlån()
        {
            //Skaber 2 nye udlån
            RotteHullet.Domain.BusinessLogic.Udlån udlån = new RotteHullet.Domain.BusinessLogic.Udlån(0,new Medlem(0,"","","","","",Medlem.MedlemType.Bruger),2, new DateTime(), new DateTime(), new DateTime(),0,new List<IAktiv>());

            //UIFacade.HentUIFacade().HentUdlåningsFacade().BesvarReservation

        }
    }
}
