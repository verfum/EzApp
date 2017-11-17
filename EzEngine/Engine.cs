using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using System.IO;

namespace EzEngine
{
   public class Engine : IRenderer
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
         m_rendererPosition = new Rectangle(new Coord(0, 0), 0, 0);
         foreach (Drawable drawable in m_drawables)
         {
            drawable.draw(this);
         }
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
      /// <param name="a_name"></param>
      public void preLoadImage(string a_name)
      {
         m_device.preLoadImage(a_name);
      }


      public void addDrawable(Drawable a_drawable)
      {
         m_drawables.Add(a_drawable);
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

      List<Drawable> m_drawables = new List<Drawable>();



      // IRenderer implementation

      Rectangle m_rendererPosition = new Rectangle(new Coord(0,0), 0,0);

      Rectangle IRenderer.position
      {
         get
         {
            return m_rendererPosition;
         }

         set
         {
            m_rendererPosition = value;
         }
      }

      void IRenderer.drawImage(string a_image, Rectangle a_position)
      {
         Rectangle rendererPos = (this as IRenderer).position;
         Rectangle newPos = new Rectangle(new Coord(a_position.left + rendererPos.left,
            a_position.top + rendererPos.top), a_position.width, a_position.height);

         m_device.drawImage(a_image, newPos);
      }
   }
}
