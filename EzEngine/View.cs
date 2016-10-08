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
      public View(Rectangle a_worldRectangle, Rectangle a_screenRectangle)
      {
         m_worldRectangle = a_worldRectangle;
         m_screenRectangle = a_screenRectangle;
      }
   }
}
