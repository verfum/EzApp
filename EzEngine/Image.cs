using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
   public class Image
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="a_name"></param>
      /// <param name="a_position">World position</param>
      public Image(string a_name, Rectangle a_position, int a_zOrder)
      {
         name = a_name;
         position = a_position;
         zOrder = a_zOrder;
      }

      public string name
      {
         get;
         set;
      }


      public Rectangle position
      {
         get;
         set;
      }

      public int zOrder
      {
         get;
         set;
      }
   }
}
