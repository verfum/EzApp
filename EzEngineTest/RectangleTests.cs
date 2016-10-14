using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EzEngine;

namespace EzEngineTest
{
   [TestClass]
   public class RectangleTests
   {
      [TestMethod]
      public void TestRectangleConstructor()
      {
         Rectangle rect = new Rectangle(new Coord(1F,42F), new Coord(2F,100F));

         Assert.AreEqual(rect.topLeft.x, 1F);
         Assert.AreEqual(rect.topLeft.y, 42F);
         Assert.AreEqual(rect.bottomRight.x, 2F);
         Assert.AreEqual(rect.bottomRight.y, 100F);
         Assert.AreEqual(rect.top, 42F);
         Assert.AreEqual(rect.left, 1F);
         Assert.AreEqual(rect.height, 58F);
         Assert.AreEqual(rect.width, 1F);

      }
   }
}
