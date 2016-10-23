using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace MonoGameAndroid
{
   [Activity(Label = "MonoGameAndroid"
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
        
          //private static string KEY_API_VERSION = "API_VERSION";
          Bundle request = new Bundle();
          request.PutInt("API_VERSION", 1);


         base.OnCreate(bundle);

         var g = new MonoGameDevice.Device();
         SetContentView((View)g.Services.GetService(typeof(View)));
         var engine = new EzEngine.Engine(g);
         engine.run();
      }
   }
}

