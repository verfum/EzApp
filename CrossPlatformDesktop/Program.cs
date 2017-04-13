using System;

namespace CrossPlatformDesktop
{
   /// <summary>
   /// The main class.
   /// </summary>
   public static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         var engine = new EzEngine.Engine(new MonoGameDevice.Device());
         //var game = new TestGame.BooGame(engine);
         engine.run();


         //using (var game = new MonoGameCommon.MonoGameDevice())
         //      game.Run();
      }
   }
}
