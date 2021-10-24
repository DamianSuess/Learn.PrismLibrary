using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Sample.PrismMobile.ViewModels;
using Sample.PrismMobile.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Sample.PrismMobile
{
  public partial class App
  {
    public App(IPlatformInitializer initializer)
      : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainView)}");
      if (!ret.Success)
      {
        Debug.WriteLine($"Error loading - {ret.Exception.Message}");
      }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Services
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

      // Navigation
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
    }
  }
}
