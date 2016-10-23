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
   public delegate void DrawEventHandler(object sender, EventArgs e);
   public delegate void InitEventHander(object sender, EventArgs e);
   public delegate void LoadContentEventHandler(object sender, EventArgs e);

   /// <summary>
   /// Interface for the physical device we're using
   /// </summary>
   public interface IDevice
   {
      /// <summary>
      /// Start the device
      /// </summary>
      void start();

      /// <summary>
      /// Called periodically to update state
      /// </summary>
      event UpdateEventHandler updateEvent;

      /// <summary>
      /// Called to redraw display
      /// </summary>
      event DrawEventHandler drawEvent;

      /// <summary>
      /// Do very early one-off init stuff here
      /// </summary>
      event InitEventHander initEvent;

      /// <summary>
      /// Create your images etc. when this is called.
      /// </summary>
      event LoadContentEventHandler loadContentEvent;

      /// <summary>
      /// Load an image into memory
      /// </summary>
      /// <param name="a_imageName"></param>
      void loadImage(string a_imageName);

      /// <summary>
      /// Draw an image. Make sure this is only called when
      /// called back on the drawEvent.
      /// Make sure this image has already been loaded with
      /// loadImage
      /// </summary>
      /// <param name="a_imageName"></param>
      /// <param name="a_position"></param>
      void drawImage(string a_imageName, Rectangle a_position);
   }
}
