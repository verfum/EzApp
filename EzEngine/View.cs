using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class View
   {
      private Rectangle m_worldRectangle;
      private Rectangle m_screenRectangle;
      private World m_world;
      public View(World a_world, Rectangle a_worldRectangle, Rectangle a_screenRectangle)
      {
         if(a_world == null || a_worldRectangle == null || a_screenRectangle == null)
         {
            throw new Exception("View is invalid");
         }

         m_world = a_world;
         m_worldRectangle = a_worldRectangle;
         m_screenRectangle = a_screenRectangle;
      }
   }
}
