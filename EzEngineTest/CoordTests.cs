using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EzEngine;

namespace EzEngineTest
{
   [TestClass]
   public class CoordTests
   {
      [TestMethod]
      public void TestCoordConstructor()
      {
         Coord coord = new Coord(2F, 3F);
         Assert.AreEqual(coord.x, 2F);
         Assert.AreEqual(coord.y, 3F);
      }
   }
}
