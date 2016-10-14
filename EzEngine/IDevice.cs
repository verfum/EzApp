using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{

   public class UpdateEventArgs : EventArgs
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="a_timeElapsed">Elapsed time in milliseconds</param>
      public UpdateEventArgs(int a_timeElapsed)
      {
         timeElapsed = a_timeElapsed;
      }
      public int timeElapsed { get; set; }
   }
   public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

   /// <summary>
   /// Interface for the physical device we're using
   /// </summary>
   public interface IDevice
   {
      void start();

      event UpdateEventHandler updateEvent;

      void drawImage(string a_imageName, Rectangle a_position);
   }
}
