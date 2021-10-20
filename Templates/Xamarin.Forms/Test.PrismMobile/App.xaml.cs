using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Test.PrismMobile.ViewModels;
using Test.PrismMobile.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Test.PrismMobile
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

      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
      if (!ret.Success)
      {
        Debug.WriteLine("Error loading main view");
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
