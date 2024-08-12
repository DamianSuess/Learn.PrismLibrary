using Prism;
using Prism.Ioc;

namespace SampleShinyCore.UWP
{
  /// <summary>Main Page.</summary>
  public sealed partial class MainPage
  {
    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new SampleShinyCore.Client.App(new UwpInitializer()));
    }
  }

  /// <summary>Initializer.</summary>
  public class UwpInitializer
    : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}
