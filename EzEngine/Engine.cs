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
      public event EzEngine.UpdateEventHandler updateEvent;


      private IDevice m_device;

      public Engine(IDevice a_device)
      {
         m_device = a_device;
         a_device.updateEvent += A_device_updateEvent;
      }

      private void A_device_updateEvent(object sender, UpdateEventArgs e)
      {
         // Pass on unless we're going to add any params.
         if (updateEvent != null)
         {
            updateEvent(this, e);
         }
      }

      public void run()
      {
         m_device.start();
      }

      
   }
}
