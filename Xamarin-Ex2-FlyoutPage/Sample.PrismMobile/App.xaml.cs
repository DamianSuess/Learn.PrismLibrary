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

      var ret = await NavigationService.NavigateAsync($"{nameof(FlyoutView)}/{nameof(NavigationPage)}/{nameof(DashboardView)}");
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
      containerRegistry.RegisterForNavigation<FlyoutView, FlyoutViewModel>();
      containerRegistry.RegisterForNavigation<FlyoutMenuView, FlyoutMenuViewModel>();
      containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
      containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
      containerRegistry.RegisterForNavigation<Customers, CustomersViewModel>();
    }
  }
}
