using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
   public class BooGame
   {
      private EzEngine.Engine m_engine;
      public BooGame(EzEngine.Engine a_engine)
      {
         m_engine = a_engine;

         m_engine.updateEvent += onUpdateEvent;
         m_engine.loadContentEvent += onLoadContentEvent;
      }

      private void onLoadContentEvent(object sender, EventArgs e)
      {
         // TODO need to create Image class in EzEngine
         // Image will have string m_image member and Rectangle
         // world coord position, although at present we're 
         // drawing directly to screen
         ///

         List<Image> particles = new List<Image>();
         Image hero = m_engine.createImage("hero");

         // TODO behind the scenes there will only be one raw image 
         // called 'particleA' that is reused from cache.
  
         for (int a = 0; a < 100; a++)
         {
            Image particle = m_engine.createImage("particleA");
            particles.Add(particle1);
         }



         throw new NotImplementedException();
      }

      private void onUpdateEvent(object sender, EzEngine.UpdateEventArgs e)
      {
   
         throw new NotImplementedException();
      }
   }
}
