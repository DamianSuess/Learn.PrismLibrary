using Prism;
using Prism.Ioc;
using Test.Prism81.ViewModels;
using Test.Prism81.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Test.Prism81
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

      await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
    }
  }
}
