using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EzEngine;

namespace EzEngineTest
{
    [TestClass]
    public class CoordTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Coord coord = new Coord(2F, 3F);
            Assert.AreEqual(coord.X, 2F);
            Assert.AreEqual(coord.Y, 3F);
        }
    }
}
