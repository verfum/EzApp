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

         EzEngine.Drawable pane = new EzEngine.Drawable();
         pane.position = new EzEngine.Rectangle(new EzEngine.Coord(100, 100), 300, 300);
         EzEngine.Image hero = new EzEngine.Image(
            "hero", // Image name
            new EzEngine.Rectangle(new EzEngine.Coord(0, 0), 64, 64) //position
            );
         pane.add(hero);


         m_engine.addDrawable(pane);
      }

      private void onLoadContentEvent(object sender, EventArgs e)
      {
         // TODO need to create Image class in EzEngine
         // Image will have string m_image member and Rectangle
         // world coord position, although at present we're 
         // drawing directly to screen
         ///

         // All resources used in the game need to be pre-loaded

         m_engine.preLoadImage("hero");



         //throw new NotImplementedException();
      }

      private void onUpdateEvent(object sender, EzEngine.UpdateEventArgs e)
      {
   
         //throw new NotImplementedException();
      }
   }
}
