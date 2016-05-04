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
            Bog bog = new Bog(0, "test1", "test2", "test3", "test4", "test5", "test6", false, "test7");

            //Gem bog
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("test2", "test3", "test4", "test5", "test6", "test7", false, "test8");

            //Ændre bog
            UIFacade.HentUIFacade().HentBogFacade().ÆndreBog(0, "test1", "test2", "test3", "test4", "test5", "test6", false, "test7");

            //Hent bog
            string bogHentet = UIFacade.HentUIFacade().HentBogFacade().HentBog(0,0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(bog.ToString(), bogHentet);
        }

        [TestMethod]
        public void TestÆndringAfUdstyr()
        {
            //Opret udstyr
            Udstyr uds = new Udstyr(1, "test2", "test3", false, "test4");

            //Gem udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0,"test1", "test2", false, "test3");

            //Ændre udstyr
            UIFacade.HentUIFacade().HentUdstyrFacade().ÆndreUdstyr(0, 1, "test2", "test3", false, "test4");

            //Hent udstyr
            string udstyrhentet = UIFacade.HentUIFacade().HentUdstyrFacade().HentUdstyr(0,0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(uds.ToString(),udstyrhentet);
        }
        [TestMethod]
        public void TestÆndringAfLokaler()
        {
            //Opret lokale
            Lokale lok = new Lokale(1, "test2", "test3", false, "test4", "test5");

            //Gem lokale
            UIFacade.HentUIFacade().HentLokaleFacade().SkabLokale(0, "test1", "test2", false, "test3", "test4");

            //Ændre lokale
            UIFacade.HentUIFacade().HentLokaleFacade().ÆndreLokale(0, 1, "test2", "test3", false, "test4", "test5");

            //Hent lokale
            string lokhentet = UIFacade.HentUIFacade().HentLokaleFacade().HentLokale(0,0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(lok.ToString(), lokhentet);
        }
        [TestMethod]
        public void TestÆndringAfBrætspil()
        {
            //Opret brætspil
            Brætspil bs = new Brætspil(1, "test2", "udgiver",false, "test3", "test4");

            //Gem brætspil
            UIFacade.HentUIFacade().HentBrætSpilFacade().SkabBrætSpil(0, "test1", "udgiver", false, "test2", "test3");

            //Ændre brætspil
            UIFacade.HentUIFacade().HentBrætSpilFacade().ÆndreBrætSpil(0, 1, "test2", "nyudgiver", true, "test3", "test4");

            //Hent brætspil
            string bsHentet = UIFacade.HentUIFacade().HentBrætSpilFacade().HentBrætSpil(0,0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(bs.ToString(), bsHentet);
        }
    }
}
