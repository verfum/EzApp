using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using System.IO;

namespace EzEngine
{
   public class Engine : IEngine
   {
      

      public Engine()
      {

      }

      public void drawLine()
      {
         throw new NotImplementedException();
      }

      private DrawDelegate m_drawCallback;
      public void registerForDraw(DrawDelegate a_drawCallback)
      {
         m_drawCallback = a_drawCallback;
      }
   }
}
