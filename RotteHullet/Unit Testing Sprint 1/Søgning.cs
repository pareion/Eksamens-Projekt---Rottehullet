using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotteHullet;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Data;

namespace Unit_Testing_Sprint_1
{
    [TestClass]
    public class Søgning
    {
        [TestMethod]
        public void TestSøg()
        {
            Bog test1 = new Bog(1, "test", "test", "test", "test", "test", "test", "test");
            Bog test2 = new Bog(1, "test", "test", "test", "test", "test", "test", "test");
            

            //Assert.AreEqual(test1.GetHashCode(), test2.GetHashCode());
        }
    }
}
