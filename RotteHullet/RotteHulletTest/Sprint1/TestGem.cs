using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;

namespace RotteHulletTest
{
    [TestClass]
    public class TestGemOgÆndre
    {
        #region Gem Aktiver test

        [TestMethod]
        public void GemBog()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter bogen ud fra biblioteket
            Bog aktiv = Biblotik.Bøger[0];

            //Skaber bogen i systemet
            string message = BogFacade.HentBogFacade().SkabBog(aktiv.Titel, aktiv.Forfatter, aktiv.Genre, aktiv.Subkategori, aktiv.Familie, aktiv.Forlag, aktiv.Udlånes, aktiv.Kommentar);

            //Henter en liste af alle bøger med den angivne titel
            List<object> data = BogFacade.HentBogFacade().FindAlleBøger(aktiv.Titel);

            //Finder det første resultat
            Bog resultat = data[0] as Bog;

            //Checker om bogen er oprettet
            Assert.AreEqual("Bog er oprettet", message);

            //Checker om titlen og forfatteren er den samme på begge bøger (Den får et nyt id i databasen så man kan ikke sammenligne objektet)
            Assert.AreEqual(aktiv.Titel + aktiv.Forfatter, resultat.Titel + resultat.Forfatter);
        }

        [TestMethod]
        public void GemBrætspil()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter brætspillet ud fra biblioteket 
            Brætspil aktiv = Biblotik.Brætspils[0];

            //Skaber brætspillet i systemet
            string message = BrætspilFacade.HentBrætSpilFacade().SkabBrætSpil(aktiv.Id, aktiv.BrætspilsNavn, aktiv.Udgiver, aktiv.Udlånes, aktiv.Kommentar, aktiv.Kategori);

            //Henter en liste af brætspil ned med det angivne navn
            List<object> data = BrætspilFacade.HentBrætSpilFacade().FindAlleBrætspil(aktiv.BrætspilsNavn);

            //Finder det første resultat
            //Brætspil resultat = data[0] as Brætspil;

            //Checker om brætspillet blev oprettet
            Assert.AreEqual("Brætspillet er skabt", message);

            //Checker om navnet og udgiveren er den samme
            //Assert.AreEqual(aktiv.BrætspilsNavn + aktiv.Udgiver, resultat.BrætspilsNavn + resultat.Udgiver);
        }

        [TestMethod]
        public void GemUdstyr()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter udstyret fra biblioteket 
            Udstyr aktiv = Biblotik.Udstyrs[0];

            //Gemmer udstyret i systemet
            string message = UdstyrFacade.HentUdstyrFacade().SkabUdstyr(aktiv.Id, aktiv.UdstyrsNavn, aktiv.Kategori, aktiv.Udlånes, aktiv.Kommentar);

            //Henter alt udstyr med det givne navn
            List<object> data = UdstyrFacade.HentUdstyrFacade().FindAlleUdstyr(aktiv.UdstyrsNavn);

            //Finder det første resultat
            Udstyr resultat = data[0] as Udstyr;

            //Checker om brætspillet blev oprettet
            Assert.AreEqual("Udstyret er skabt", message);

            //Sammenligner navnet 
            Assert.AreEqual(aktiv.UdstyrsNavn, resultat.UdstyrsNavn);
        }

        [TestMethod]
        public void GemLokale()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter lokalet fra biblioteket 
            Lokale aktiv = Biblotik.Lokaler[0];

            //Gemmer lokalet i systemet
            string message = LokaleFacade.HentLokaleFacade().SkabLokale(aktiv.Id, aktiv.LokaleNavn, aktiv.Lokation, aktiv.Udlånes, aktiv.Kommentar, aktiv.Møbler);

            //Henter alle lokaler med det givne navn
            List<object> data = LokaleFacade.HentLokaleFacade().FindAlleLokaler(aktiv.LokaleNavn);

            //Finder det første resultat
            Lokale resultat = data[0] as Lokale;

            //Checker om lokallet blev oprettet
            Assert.AreEqual("Lokalet er skabt", message);

            //Sammenligner navnet 
            Assert.AreEqual(aktiv.LokaleNavn + aktiv.Lokation, resultat.LokaleNavn + resultat.Lokation);
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
