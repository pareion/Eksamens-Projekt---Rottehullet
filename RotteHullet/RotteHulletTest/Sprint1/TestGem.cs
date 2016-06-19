using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;
using RotteHullet;

namespace RotteHulletTest
{
    [TestClass]
    public class TestGemOgÆndre
    {
        /*
        #region Gem Aktiver test
        
        [TestMethod]
        public void GemBog()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter bogen ud fra biblioteket
            Bog aktiv = Biblotik.Bøger[0];

            //Skaber bogen i systemet
            string message = BogFacade.HentBogFacade().SkabBog(aktiv.titel, aktiv.forfatter, aktiv.genre, aktiv.subkategori, aktiv.familie, aktiv.forlag, aktiv.udlånes, aktiv.kommentar);

            //Henter en liste af alle bøger med den angivne titel
            List<object> data = BogFacade.HentBogFacade().FindAlleBøger(aktiv.titel);

            //Finder det første resultat
            Bog resultat = data[0] as Bog;

            //Checker om bogen er oprettet
            Assert.AreEqual("Bog er oprettet", message);

            //Checker om titlen og forfatteren er den samme på begge bøger (Den får et nyt id i databasen så man kan ikke sammenligne objektet)
            Assert.AreEqual(aktiv.titel + aktiv.forfatter, resultat.titel + resultat.forfatter);

            //Sletter aktivet fra databasen 
            BogFacade.HentBogFacade().SletBog(resultat.bogid);
        }

        [TestMethod]
        public void GemBrætspil()
        {
            //Angiver hvilken type database vi skal bruge
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);

            //Henter brætspillet ud fra biblioteket 
            Brætspil aktiv = Biblotik.Brætspils[0];

            //Skaber brætspillet i systemet
            string message = BrætspilFacade.HentBrætSpilFacade().SkabBrætSpil(aktiv.brætspilid, aktiv.brætspilnavn, aktiv.udgiver, aktiv.udlånes, aktiv.kommentar, aktiv.kategori);

            //Henter en liste af brætspil ned med det angivne navn
            List<object> data = BrætspilFacade.HentBrætSpilFacade().FindAlleBrætspil(aktiv.BrætspilsNavn);

            //Finder det første resultat
            Brætspil resultat = data[0] as Brætspil;

            //Checker om brætspillet blev oprettet
            Assert.AreEqual("Brætspillet er skabt", message);

            //Checker om navnet og udgiveren er den samme
            Assert.AreEqual(aktiv.BrætspilsNavn + aktiv.Udgiver, resultat.BrætspilsNavn + resultat.Udgiver);

            //Sletter aktivet fra databasen
            BrætspilFacade.HentBrætSpilFacade().SletBrætSpil(resultat.Id);
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

            //Sletter aktivet fra databasen
            UdstyrFacade.HentUdstyrFacade().SletUdstyr(resultat.Id);
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

            //Sletter aktivet fra databasen
            LokaleFacade.HentLokaleFacade().SletLokale(resultat.Id);
        }
        #endregion
        */
    }
}
