﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;
using System.Collections;
using System.Collections.Generic;

namespace Unit_Testing_Sprint_1
{
    [TestClass]
    public class Søgning
    {
        [TestMethod]
        public void TestSøgBog()
        {
            Bog aktiv1 = new Bog(1, "Hello world", "Forfatter1", "Genre1", "Subkategori1", "Greeting", "Forlag1", "Kommentar1");
            Bog aktiv2 = new Bog(2, "The World is a big place", "Forfatter2", "Genre2", "Subkategori2", "Geography", "Forlag2", "Kommentar2");
            Bog aktiv3 = new Bog(3, "The Code 3", "Forfatter3", "Genre3", "Subkategori3", "PRogramming", "Forlag3", "Kommentar3");

            DBRamFacade.HentDbRamFacade().GemBog(aktiv1);
            DBRamFacade.HentDbRamFacade().GemBog(aktiv2);
            DBRamFacade.HentDbRamFacade().GemBog(aktiv3);

            List<Bog> aktiver = new List<Bog>();
            bool resultat = DBRamFacade.HentDbRamFacade().Søg("Hello", out aktiver);

            if (aktiver.Count > 0)
            {
                Assert.IsTrue(aktiver.Exists(x => x.Id == 1));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestSøgBrætspil()
        {
            Brætspil aktiv1 = new Brætspil(1, "Hello world", "Forfatter1", "Greeting");
            Brætspil aktiv2 = new Brætspil(2, "The World is a big place", "Forfatter2", "Greeting");
            Brætspil aktiv3 = new Brætspil(3, "The Code 3", "Forfatter3", "Kommentar3");



            DBRamFacade.HentDbRamFacade().GemBrætSpil(aktiv1);
            DBRamFacade.HentDbRamFacade().GemBrætSpil(aktiv2);
            DBRamFacade.HentDbRamFacade().GemBrætSpil(aktiv3);

            List<Brætspil> aktiver = new List<Brætspil>();
            bool resultat = DBRamFacade.HentDbRamFacade().Søg("World", out aktiver);

            if (aktiver.Count > 0)
            {
                Assert.IsTrue(aktiver.Exists(x => x.Id == 1 || x.Id == 2));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestSøgLokale()
        {
            Lokale aktiv1 = new Lokale(1, "Hello world", "Forfatter1", "Greeting", "Test");
            Lokale aktiv2 = new Lokale(2, "The World is a big place", "Forfatter2", "Greeting", "Test");
            Lokale aktiv3 = new Lokale(3, "The Code 3", "Forfatter3", "Kommentar3", "Test");

            DBRamFacade.HentDbRamFacade().GemLokale(aktiv1);
            DBRamFacade.HentDbRamFacade().GemLokale(aktiv2);
            DBRamFacade.HentDbRamFacade().GemLokale(aktiv3);

            List<Lokale> aktiver = new List<Lokale>();
            bool resultat = DBRamFacade.HentDbRamFacade().Søg("Code", out aktiver);

            if (aktiver.Count > 0)
            {
                Assert.IsTrue(aktiver.Exists(x => x.Id == 3));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestSøgUdstyr()
        {
            Lokale aktiv1 = new Lokale(1, "Hello world", "Forfatter1", "Greeting", "Test");
            Lokale aktiv2 = new Lokale(2, "The World is a big place", "Forfatter2", "Greeting", "Test");
            Lokale aktiv3 = new Lokale(3, "The Code 3", "Forfatter3", "Kommentar3", "Test");

            DBRamFacade.HentDbRamFacade().GemLokale(aktiv1);
            DBRamFacade.HentDbRamFacade().GemLokale(aktiv2);
            DBRamFacade.HentDbRamFacade().GemLokale(aktiv3);

            List<Lokale> aktiver = new List<Lokale>();
            bool resultat = DBRamFacade.HentDbRamFacade().Søg("Code", out aktiver);

            if (aktiver.Count > 0)
            {
                Assert.IsTrue(aktiver.Exists(x => x.Id == 3));
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}
