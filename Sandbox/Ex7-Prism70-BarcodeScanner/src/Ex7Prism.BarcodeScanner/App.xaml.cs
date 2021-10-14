using System;
using System.Threading.Tasks;
using BarcodeScanner;
using DryIoc;
using Ex7Prism.BarcodeScanner.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Logging;
using Prism.Plugin.Popups;
using Xamarin.Forms;
using DebugLogger = Ex7Prism.BarcodeScanner.Services.DebugLogger;

namespace Ex7Prism.BarcodeScanner
{
  public partial class App : PrismApplication
  {
    /*
     * NOTE:
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor.
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */

    public App()
      : this(null)
    {
    }

    public App(IPlatformInitializer initializer)
      : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();
      LogUnobservedTaskExceptions();

      await NavigationService.NavigateAsync($"{nameof(SplashScreenPage)}");
      // var nav = await NavigationService.NavigateAsync($"{nameof(SplashScreenPage)}");
      //if (!nav.Success)
      //{
      //  // Log the message
      //  Console.WriteLine(nav.Exception.Message);
      //  throw new System.Exception(nav.Exception.Message);
      //}
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register the Popup Plugin Navigation Service
      containerRegistry.RegisterPopupNavigationService();
      containerRegistry.RegisterInstance(CreateLogger());

      // NOTE: Uses a Popup Page to contain the Scanner. You can optionally register
      // the ContentPageBarcodeScannerService if you prefer a full screen approach.
      containerRegistry.RegisterSingleton<IBarcodeScannerService, PopupBarcodeScannerService>();

      // Navigating to "TabbedPage?createTab=ViewA&createTab=ViewB&createTab=ViewC will generate a TabbedPage
      // with three tabs for ViewA, ViewB, & ViewC
      // Adding `selectedTab=ViewB` will set the current tab to ViewB
      containerRegistry.RegisterForNavigation<TabbedPage>();
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage>();
      containerRegistry.RegisterForNavigation<SplashScreenPage>();
      containerRegistry.RegisterForNavigation<TodoItemDetail>();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle IApplicationLifecycle
      base.OnSleep();

      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle IApplicationLifecycle
      base.OnResume();

      // Handle when your app resumes
    }

    private ILoggerFacade CreateLogger() => new DebugLogger();

    private void LogUnobservedTaskExceptions()
    {
      TaskScheduler.UnobservedTaskException += (sender, e) =>
      {
        Container.Resolve<ILoggerFacade>().Log(e.Exception);
      };
    }
  }
}
