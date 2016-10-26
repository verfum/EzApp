using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class Image
   {
      Image(string a_name)
      {
         name = a_name;
      }

      Image(string a_name, Rectangle a_position)
      {
         name = a_name;
         position = a_position;
      }

      string name
      {
         get;
         set;
      }


      Rectangle position
      {
         get;
         set;
      }
   }
}
