using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

namespace Unit_Testing_Sprint_1
{
    [TestClass]
    public class Ændring
    {
        [TestMethod]
        public void TestÆndringAfBog()
        {
            //Opret bog
            Bog bog = new Bog(0, "test1", "test2", "test3", "test4", "test5", "test6", "test7");

            //Gem bog
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("test2", "test3", "test4", "test5", "test6", "test7", "test8");

            //Ændre bog
            UIFacade.HentUIFacade().HentBogFacade().ÆndreBog(0, "test1", "test2", "test3", "test4", "test5", "test6", "test7");

            //Hent bog
            string bogHentet = UIFacade.HentUIFacade().HentBogFacade().LæsBog(0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(bog.ToString(), bogHentet);
        }

        [TestMethod]
        public void TestÆndringAfUdstyr()
        {
            //Opret udstyr
            Udstyr uds = new Udstyr(1, "test2", "test3", "test4");

            //Gem udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0,"test1", "test2", "test3");

            //Ændre udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().ÆndreUdstyr(0, 1, "test2", "test3", "test4");

            //Hent udstyr
            string udstyrhentet = UIFacade.HentUIFacade().HentUdstyrFacade().HentUdstyr(1);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(uds.ToString(),udstyrhentet);
        }
        [TestMethod]
        public void TestÆndringAfLokaler()
        {
            //Opret udstyr
            Udstyr uds = new Udstyr(1, "test2", "test3", "test4");

            //Gem udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0, "test1", "test2", "test3");

            //Ændre udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().ÆndreUdstyr(0, 1, "test2", "test3", "test4");

            //Hent udstyr
            string udstyrhentet = UIFacade.HentUIFacade().HentUdstyrFacade().HentUdstyr(1);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(uds.ToString(), udstyrhentet);
        }
    }
}
