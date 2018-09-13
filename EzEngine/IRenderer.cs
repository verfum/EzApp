using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public interface IRenderer
   {
      void drawImage(String a_image, Rectangle a_position);

      // Property declaration:
      Rectangle position
      {
         get;
         set;
      }
   }
}
