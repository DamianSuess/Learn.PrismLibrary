using MetroLog.MicrosoftExtensions;
using MetroLog.Operators;
using Test.PrismMaui.ViewModels;
using Test.PrismMaui.Views;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder()
      .UseMauiApp<App>()
      .UsePrism(Configure)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    builder.Logging
    .AddTraceLogger(o =>
    {
      //// Write to the Debug Output
      o.MinLevel = LogLevel.Trace;
      o.MaxLevel = LogLevel.Critical;
    })
    .AddInMemoryLogger(o =>
    {
      o.MaxLines = 1024;
      o.MinLevel = LogLevel.Trace;
      o.MaxLevel = LogLevel.Critical;
    })
    .AddStreamingFileLogger(o =>
    {
      o.RetainDays = 2;
      o.FolderPath = Path.Combine(FileSystem.CacheDirectory, "PrismTests");
    })
    .AddConsoleLogger(o =>
    {
      //// Write to the Console Output (logcat for android)
      o.MinLevel = LogLevel.Information;
      o.MaxLevel = LogLevel.Critical;
    });

    return builder.Build();
  }

  private static void Configure(PrismAppBuilder builder)
  {
    // You may also do this in-line via lambdas without the need of static methods.
    builder
      .ConfigureModuleCatalog(OnConfigureModuleCatalog)
      .RegisterTypes(container =>
      {
        // Sample auto-assign MainViewModel and the rest manually
        container.RegisterForNavigation<MainView>();
        container.RegisterForNavigation<ListCoffeeView, ListCoffeeViewModel>();
        container.RegisterForNavigation<Page2View, Page2ViewModel>();
        container.RegisterForNavigation<SplashView, SplashViewModel>();
        container.RegisterInstance(SemanticScreenReader.Default);
      })
      ////.RegisterTypes(containerRegistry =>
      ////{
      ////  containerRegistry.RegisterGlobalNavigationObserver();
      ////  containerRegistry.RegisterForNavigation<MainView>();
      ////  containerRegistry.RegisterForNavigation<RootView>();
      ////  containerRegistry.RegisterForNavigation<ListCoffeeView>();
      ////  containerRegistry.RegisterForNavigation<SplashView>();
      ////})
      //.OnAppStart($"{nameof(NavigationPage)}/{nameof(MainView)}");
      .OnAppStart(navSvc =>
        navSvc.CreateBuilder()
              .AddSegment<SplashViewModel>()
              .Navigate(OnNavigationError));
  }

  private static void OnNavigationError(Exception ex)
  {
    Console.WriteLine($"Exception navigating. {ex}");
    System.Diagnostics.Debugger.Break();
  }

  private static void OnConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // Add custom Module to catalog
    //  moduleCatalog.AddModule<MauiAppModule>();
    //  moduleCatalog.AddModule<MauiTestRegionsModule>();
  }
}
