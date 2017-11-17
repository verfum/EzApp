using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class Image : Drawable
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="a_name"></param>
      /// <param name="a_position">World position</param>
      public Image(string a_name, Rectangle a_position)
      {
         name = a_name;
         position = a_position;
      }

      public string name
      {
         get;
         set;
      }

      public override void draw(IRenderer a_renderer)
      {
         //base.draw(a_renderer);
         a_renderer.drawImage(name, position);
      }
   }
}
