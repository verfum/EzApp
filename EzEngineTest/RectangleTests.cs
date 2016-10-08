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

         Assert.AreEqual(rect.TopLeft.X, 1F);
         Assert.AreEqual(rect.TopLeft.Y, 42F);
         Assert.AreEqual(rect.BottomRight.X, 2F);
         Assert.AreEqual(rect.BottomRight.Y, 100F);
         Assert.AreEqual(rect.Top, 42F);
         Assert.AreEqual(rect.Left, 1F);
         Assert.AreEqual(rect.Height, 58F);
         Assert.AreEqual(rect.Width, 1F);

      }
   }
}
