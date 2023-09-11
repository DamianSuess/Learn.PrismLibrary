using Test.PrismMaui.Views;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UsePrism(Configure)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
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

      .OnAppStart($"{nameof(MainView)}");
    ////  .OnAppStart($"{nameof(NavigationPage)}/{nameof(MainView)}");
    ////  .OnAppStart(navSvc =>
    ////    navSvc.CreateBuilder()
    ////          .AddSegment<SplashViewModel>()
    ////          .Navigate(OnNavigationError));
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
