using System;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using SampleShinyCore.Client.ViewModels;
using SampleShinyCore.Client.Views;

namespace SampleShinyCore.Client
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
        Console.WriteLine($"Error! {ret.Exception.Message}");
      }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
      containerRegistry.RegisterForNavigation<DeviceListView, DeviceListViewModel>();
    }
  }
}
