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
         TimeElapsed = a_timeElapsed;
      }
      public int TimeElapsed { get; set; }
   }
   public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

   /// <summary>
   /// Interface for the physical device we're using
   /// </summary>
   public interface IDevice
   {
      event UpdateEventHandler UpdateEvent;
   }
}
