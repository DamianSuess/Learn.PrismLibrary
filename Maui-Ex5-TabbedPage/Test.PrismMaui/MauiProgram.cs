//// using SkiaSharp.Views.Maui.Controls.Hosting;
using Test.PrismMaui.ViewModels;
using Test.PrismMaui.ViewModels.Regions;
using Test.PrismMaui.Views;
using Test.PrismMaui.Views.Regions;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      ////.UseSkiaSharp(true)
      .UseMauiApp<App>()
      ////.UseMauiCommunityToolkit()
      .UsePrism(ConfigureContainer)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    return builder.Build();
  }

  private static void ConfigureContainer(PrismAppBuilder builder)
  {
    // You may also do this in-line via lambdas without the need of static methods.
    builder
      .ConfigureModuleCatalog(OnConfigureModuleCatalog)
      .RegisterTypes(container =>
      {
        // Sample auto-assign MainViewModel and the rest manually
        ////  containerRegistry.RegisterGlobalNavigationObserver();
        container.RegisterForNavigation<MainTabPage, MainTabViewModel>();
        container.RegisterForNavigation<HomePage, HomePageViewModel>();
        container.RegisterForNavigation<ChartPage, ChartPageViewModel>();
        container.RegisterForNavigation<RegionPage, RegionPageViewModel>();

        // Region Views
        container.RegisterForRegionNavigation<SomeRegionView, ChartRegionViewModel>();

        container.RegisterInstance(SemanticScreenReader.Default);
      })
      .OnAppStart($"{nameof(MainTabPage)}");

    // Alternative OnAppStart builders
    ////  .OnAppStart($"{nameof(NavigationPage)}/{nameof(MainView)}");
    ////  .OnAppStart(navSvc =>
    ////    navSvc.CreateBuilder()
    ////          .AddSegment<SplashViewModel>()
    ////          .Navigate(OnNavigationError));
  }

  private static void OnConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // Add custom Module to catalog
    //  moduleCatalog.AddModule<MauiAppModule>();
    //  moduleCatalog.AddModule<MauiTestRegionsModule>();
  }

  private static void OnNavigationError(Exception ex)
  {
    Console.WriteLine($"Exception navigating. {ex}");
    System.Diagnostics.Debugger.Break();
  }
}
