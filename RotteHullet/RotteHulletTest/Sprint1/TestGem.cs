using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHulletTest
{
    [TestClass]
    public class TestGemOgÆndre
    {
        #region Gem Aktiver test

        [TestMethod]
        public void GemBog()
        {
            Bog aktiv = Biblotik.Bøger[0];
            string message = BogFacade.HentBogFacade().SkabBog(aktiv.Titel, aktiv.Forfatter, aktiv.Genre, aktiv.Subkategori, aktiv.Familie, aktiv.Forlag, aktiv.Udlånes, aktiv.Kommentar);
            List<object> data = BogFacade.HentBogFacade().FindAlleBøger(aktiv.Titel);

            Bog resultat = data[0] as Bog;

            Assert.AreEqual("Bog er oprettet", message);

            Assert.AreEqual(aktiv, resultat);
        }

        [TestMethod]
        public void GemBrætspil()
        {
            Brætspil aktiv = Biblotik.Brætspils[0];
            BrætspilFacade.HentBrætSpilFacade().SkabBrætSpil(aktiv.Id, aktiv.BrætspilsNavn, aktiv.Udgiver, aktiv.Udlånes, aktiv.Kommentar, aktiv.Kategori);
            List<object> data = BogFacade.HentBogFacade().FindAlleBøger(aktiv.BrætspilsNavn);

            Brætspil resultat = data[0] as Brætspil;

            Assert.AreEqual(aktiv, resultat);
        }

        [TestMethod]
        public void GemUdstyr()
        {
            Udstyr aktiv = Biblotik.Udstyrs[0];
            UdstyrFacade.HentUdstyrFacade().SkabUdstyr(aktiv.Id, aktiv.UdstyrsNavn, aktiv.Kategori, aktiv.Udlånes, aktiv.Kommentar);
            List<object> data = UdstyrFacade.HentUdstyrFacade().FindAlleUdstyr(aktiv.UdstyrsNavn);

            Udstyr resultat = data[0] as Udstyr;

            Assert.AreEqual(aktiv, resultat);
        }

        [TestMethod]
        public void GemLokale()
        {
            Lokale aktiv = Biblotik.Lokaler[0];
            LokaleFacade.HentLokaleFacade().SkabLokale(aktiv.Id, aktiv.LokaleNavn, aktiv.Lokation, aktiv.Udlånes, aktiv.Kommentar, aktiv.Møbler);
            List<object> data = UdstyrFacade.HentUdstyrFacade().FindAlleUdstyr(aktiv.LokaleNavn);

            Lokale resultat = data[0] as Lokale;

            Assert.AreEqual(aktiv, resultat);
        }

        /*
        [TestMethod]
        public void GemMedlem()
        {

        }
        */
        #endregion
    }
}
