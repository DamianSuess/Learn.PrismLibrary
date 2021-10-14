/* Copyright Omnicell, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    MainActivity.cs
 * Description:
 *  Android entry point
 *
 * References:
 *  - https://brianpeek.com/connect-to-a-bluetooth-device-with-xamarinandroid/
 */

using System;
using Android.App;
using Android.Bluetooth;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace Tmpl.PrismApp.Droid
{
  [Activity(
    Label = "Tmpl.PrismApp",
    Icon = "@mipmap/icon",
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

      BluetoothInitialize();

      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new Client.App(new AndroidInitializer()));
    }

    private void BluetoothInitialize()
    {
      ////bool enabled = false;
      ////BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
      ////if (adapter == null)
      ////  throw new Exception("No Bluetooth adapter found.");
      ////else
      ////  enabled = adapter.IsEnabled;

      ////if (!adapter.IsEnabled)
      ////  throw new Exception("Bluetooth not enabled.");
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