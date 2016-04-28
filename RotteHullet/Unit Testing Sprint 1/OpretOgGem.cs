using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

namespace Unit_Testing_Sprint_1
{
    [TestClass]
    public class OpretOgGem
    {
        /// <summary>
        /// Test skal køres seperat og ikke i forbindelse med de andre pga. af Id'et,
        /// som skal være med i testen.
        /// Der testes ikke for at oprette og gemme de andre aktiver, da hvis denne virker
        /// så vil de andre også siden koden er den samme i facaderne
        /// </summary>
        [TestMethod]
        public void TestOpretGemBog()
        {
            //Opret bog
            Bog bog = new Bog(0, "Abernes Verden", "Abe Far", "Gys", "Komedie",
                "Abernes Planet", "Gyldendal", "Stand: Ødelagt. Må ikke udlånes.");

            //Gem bog
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Abernes Verden", "Abe Far", "Gys", "Komedie",
                "Abernes Planet", "Gyldendal", "Stand: Ødelagt. Må ikke udlånes.");

            //Hent bog
            string bogHentet = UIFacade.HentUIFacade().HentBogFacade().HentBog(0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.AreEqual(bog.ToString(), bogHentet);
        }

        [TestMethod]
        public void TestOpretGemBogIkkeIdentisk()
        {
            //Opret bog med kommentar  
            Bog bog = new Bog(0, "Test", "Test", "Test", "Test", "Test", "Test", "TestKommentar");
            
            //Gem bog uden kommentar
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Test", "Test", "Test", "Test", "Test", "Test", null);

            //Hent bog uden kommentar
            string bogHentet = UIFacade.HentUIFacade().HentBogFacade().HentBog(0);

            //Sammenlign om den gemte ikke er identisk med den som er hentet ud
            Assert.AreNotEqual(bog.ToString(), bogHentet);
        }

        [TestMethod]
        public void TestOpretGemFlereBøger()
        {
            //Gem 4 bøger.
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Test", "Test", "Test", "Test", "Test", "Test", "Test");
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Test", "Test", "Test", "Test", "Test", "Test", "Test");
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Test", "Test", "Test", "Test", "Test", "Test", "Test");
            UIFacade.HentUIFacade().HentBogFacade().SkabBog("Test", "Test", "Test", "Test", "Test", "Test", "Test");

            //Hent liste med bøger
            List<string> bogListe = UIFacade.HentUIFacade().HentBogFacade().HentAlleBøger();

            //Sammenlign om den gemte ikke er identisk med den som er hentet ud
            Assert.AreEqual(bogListe.Count, 4);
        }
    }
}
