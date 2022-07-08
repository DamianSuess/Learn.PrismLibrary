using Test.PrismMaui.ViewModels;
using Test.PrismMaui.Views;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder()
      .UsePrismApp<App>(Configure)
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
      .RegisterTypes(OnRegisterTypes)
      //.OnAppStart($"{nameof(NavigationPage)}/{nameof(MainView)}");
      .OnAppStart(navSvc =>
        navSvc.CreateBuilder()
              .AddNavigationSegment<SplashViewModel>()
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

  private static void OnRegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry
      .RegisterForNavigation<MainView>()                      // Auto-assign ViewModel
      .RegisterForNavigation<SubPageView, SubPageViewModel>() // Manually assign ViewModel
      .RegisterForNavigation<SplashView, SplashViewModel>()
      .RegisterInstance(SemanticScreenReader.Default);
  }
}
