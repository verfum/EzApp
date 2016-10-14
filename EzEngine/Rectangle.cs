using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class Rectangle
   {
      private Coord m_topLeft;
      private Coord m_bottomRight;

      /// <summary>
      /// Rectangle used for World and Screen
      /// </summary>
      /// <param name="a_topLeft"></param>
      /// <param name="a_bottomRight"></param>
      public Rectangle(Coord a_topLeft, Coord a_bottomRight)
      {
         m_topLeft = a_topLeft;
         m_bottomRight = a_bottomRight;
      }

      public Coord topLeft
      {
         set
         {
            m_topLeft = value;
         }
         get
         {
            return m_topLeft;
         }
      }

      public Coord bottomRight
      {
         set
         {
            m_bottomRight = value;
         }
         get
         {
            return m_bottomRight;
         }
      }

      public float left
      {
         get
         {
            return m_topLeft.x;
         }
      }

      public float top
      {
         get
         {
            return m_topLeft.y;
         }
      }

      public float width
      {
         get
         {
            return m_bottomRight.x - m_topLeft.x;
         }
      }

      public float height
      {
         get
         {
            return m_bottomRight.y - m_topLeft.y;
         }
      }

      /// <summary>
      /// Fit rectangle a in rectangle b. Keeps rectangle a's aspect.
      /// Returns rectangle with coords with respect to rectangle b.
      /// </summary>
      /// <param name="m_a"></param>
      /// <param name="m_b"></param>
      /// <returns>Rectangle with coords with respect to rectangle b</returns>
      public static Rectangle fitRectangle(Rectangle m_a, Rectangle m_b)
      {
         Debug.Assert(false, "Not implemented");

         Rectangle r;
         return null;
      }
   }
}
