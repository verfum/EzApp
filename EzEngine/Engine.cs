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
         // TODO
         // Need to go through list of views and then its world and then
         // draw the objects it contains
         //throw new NotImplementedException();
      }

      // Do we need this?
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

      /// <summary>
      /// Call when loadContentEvent fires if you need
      /// images loaded in advance for performance.
      /// </summary>
      /// <param name="m_name"></param>
      public void preLoadImage(string m_name)
      {
         m_device.preLoadImage(m_name);
      }

      //
      public void addWorld(/* world */)
      {

      }

      // We should really be adding images to world objects,
      // and adding worlds to the engine.
      //public void addImage(Image a_image)
      

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
