using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

namespace Unit_Testing_Sprint_1
{
    [TestClass]
    public class OpretOgGem
    {
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
            Bog bogHentet = UIFacade.HentUIFacade().HentBogFacade().LæsBog(0);

            //Sammenlign om den gemte er identisk med den som er hentet ud
            Assert.IsTrue(bog.ErSammeBog(bogHentet));
        }
    }
}
