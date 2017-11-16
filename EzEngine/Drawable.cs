using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   class Drawable
   {
      private Rectangle m_position;
      private List<Drawable> m_drawables = new List<Drawable>();

      public void add(Drawable a_drawable)
      {
         m_drawables.Add(a_drawable);
      }

      public void draw(/*Renderer a_renderer*/)
      {
         foreach(Drawable drawable in m_drawables)
         {
            drawable.draw(/*a_renderer*/);
         }
      }
   }
}
