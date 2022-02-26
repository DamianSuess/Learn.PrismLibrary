using System;
using Android.App;
using Android.Runtime;

namespace Test.Prism81.Droid
{
  #if DEBUG
    [Application(Debuggable = true, Theme = "@style/MainTheme")]
  #else
    [Application(Debuggable = false, Theme = "@style/MainTheme")]
  #endif
  public class MainApplication : Application
  {
    public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {
    }

    public override void OnCreate()
    {
      base.OnCreate();
      Xamarin.Essentials.Platform.Init(this);
    }
  }
}
