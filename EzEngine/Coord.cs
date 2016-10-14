using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   // Represents a 2-D coordinat
   public class Coord
   {
      /// <summary>
      /// 2D coordinate that is used for World and Screen
      /// </summary>
      /// <param name="a_x"></param>
      /// <param name="a_y"></param>
      public Coord(float a_x, float a_y)
      {
         m_x = a_x;
         m_y = a_y;
      }

      private float m_x;
      private float m_y;

      public float x
      {
         set
         {
            m_x = value;
         }
         get
         {
            return m_x;
         }
      }

      public float y
      {
         set
         {
            m_y = value;
         }
         get
         {
            return m_y;
         }
      }

   }
}