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
      public event EzEngine.LoadContentEventHandler loadContentEvent;


      private IDevice m_device;

      public Engine(IDevice a_device)
      {
         m_device = a_device;
         a_device.updateEvent += onUpdateEvent;
         a_device.loadContentEvent += onLoadContentEvent;
         a_device.drawEvent += onDrawEvent;
      }

      private void onDrawEvent(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void onLoadContentEvent(object sender, EventArgs e)
      {
         if(loadContentEvent != null)
         {
            loadContentEvent(this, e);
         }
      }

      public void run()
      {
         m_device.start();
      }

      /*public Image createImage(string m_name)
      {

      }

      public void addImage(Image image, Rectangle a_position)
      {

      }*/

      private void onUpdateEvent(object sender, UpdateEventArgs e)
      {
         // Pass on unless we're going to add any params.
         if (updateEvent != null)
         {
            updateEvent(this, e);
         }
      }

      

      
   }
}
