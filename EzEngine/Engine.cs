using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using System.IO;

namespace EzEngine
{
   public class Engine
   {
      private IDevice m_device;

      public Engine(IDevice a_device)
      {
         m_device = a_device;
      }

      public void run()
      {
         m_device.start();
      }

      
   }
}
