using System;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;
using Application = Gtk.Application;

namespace Sample.PrismMobile.Gtk
{
  public class Program
  {
    [STAThread]
    public static void Main(string[] args)
    {
      Application.Init();
      Forms.Init();

      //// Xamarin.Essentials.Platform.Init(this);

      var app = new PrismMobile.App(new GtkInitializer());
      var window = new FormsWindow();
      window.LoadApplication(app);
      window.SetApplicationTitle("Your App Name");
      window.Show();

      Application.Run();
    }
  }

  public class GtkInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}
