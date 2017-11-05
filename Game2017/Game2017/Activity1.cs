using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Game2017
{
   [Activity(Label = "Game2017"
       , MainLauncher = true
       , Icon = "@drawable/icon"
       , Theme = "@style/Theme.Splash"
       , AlwaysRetainTaskState = true
       , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
       , ScreenOrientation = ScreenOrientation.SensorLandscape
       , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
   public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
   {
      protected override void OnCreate(Bundle bundle)
      {
         //base.OnCreate(bundle);
         //var g = new Game1();
         //SetContentView((View)g.Services.GetService(typeof(View)));
         //g.Run();


         base.OnCreate(bundle);

         var g = new MonoGameDevice.Device();
         SetContentView((View)g.Services.GetService(typeof(View)));
         var engine = new EzEngine.Engine(g);
         var game = new TestGame.BooGame(engine);
         engine.run();

      }
   }
}

