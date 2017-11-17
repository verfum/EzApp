using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class Drawable
   {

      private List<Drawable> m_drawables = new List<Drawable>();

      public Rectangle position
      {
         get;
         set;
      }

      public void add(Drawable a_drawable)
      {
         m_drawables.Add(a_drawable);
      }

      public virtual void draw(IRenderer a_renderer)
      {

         Rectangle pos = a_renderer.position;
         Rectangle newPos = new Rectangle(new Coord(pos.left + position.left, pos.top + position.top),
            pos.width, pos.height);

         a_renderer.position = newPos;

         foreach (Drawable drawable in m_drawables)
         {
            drawable.draw(a_renderer);
         }
      }
   }
}
