using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace Ex7Prism.BarcodeScanner.Droid
{
  [Activity(Label = "@string/ApplicationName",
            Icon = "@mipmap/ic_launcher",
            Theme = "@style/MyTheme",
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      global::Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
      global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      global::FFImageLoading.Forms.Droid.CachedImageRenderer.Init(enableFastRenderer: true);
      global::FFImageLoading.ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration()
      {
        Logger = new Ex7Prism.BarcodeScanner.Services.DebugLogger()
      });
      global::ZXing.Net.Mobile.Forms.Android.Platform.Init();

      LoadApplication(new App(new AndroidInitializer()));
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
      global::ZXing.Net.Mobile
                       .Android
                       .PermissionsHandler
                       .OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}
