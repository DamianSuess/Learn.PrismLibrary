using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using UXDivers.Gorilla;
using UXDivers.Gorilla.Droid;

namespace Test.PrismXF.Droid
{
  [Activity(
    Label = "Test.PrismXF",
    Icon = "@mipmap/ic_launcher",
    Theme = "@style/MainTheme",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      global::Xamarin.Forms.Forms.Init(this, bundle);

      // LoadApplication(new App(new AndroidInitializer()));

      LoadApplication(Player.CreateApplication(this,
            new Config("Gorilla on DESKTOP-JFQ8BHF")
            .RegisterAssemblyFromType<Prism.IActiveAware>() // Prism
            //.RegisterAssemblyFromType<Prism.PrismApplicationBase<object>>() // Prism.Forms
            .RegisterAssemblyFromType<Prism.DryIoc.PrismApplication>() // Prism.Unity
            //.RegisterAssemblyFromType<FFImageLoading.Transformations.GrayscaleTransformation>() // FFImageLoading.Transformations assembly
            //.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>() // FFImageLoading.Forms assembly
        ));

      //LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
      //  this,
      //  new UXDivers.Gorilla.Config("Good Gorilla")
      //  // Register Grial Shared assembly
      //  .RegisterAssemblyFromType<UXDivers.Artina.Shared.CircleImage>()
      //  // Register UXDivers Effects assembly
      //  .RegisterAssembly(typeof(UXDivers.Effects.Effects).Assembly)
      //  // FFImageLoading.Transformations
      //  .RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
      //  // FFImageLoading.Forms
      //  .RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
      //  ));
    }
  }

  public class AndroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}