//// using SkiaSharp.Views.Maui.Controls.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Test.PrismMaui.Services;
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
      .UseSkiaSharp(true)
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
    builder
      .ConfigureServices(services =>
      {
        services.AddSingleton<CounterService>();
      })
      .ConfigureModuleCatalog(moduleCatalog =>
      {
        // Add custom Module to catalog
        // moduleCatalog.AddModule<MauiAppModule>();
        // moduleCatalog.AddModule<MauiTestRegionsModule>();
      })
      .RegisterTypes(container =>
      {
        // Sample auto-assign MainViewModel and the rest manually
        ////  containerRegistry.RegisterGlobalNavigationObserver();
        container.RegisterForNavigation<MainTabPage, MainTabViewModel>();
        container.RegisterForNavigation<HomePage, HomePageViewModel>();
        container.RegisterForNavigation<ChartPage, ChartPageViewModel>();
        container.RegisterForNavigation<RegionPage, RegionPageViewModel>();

        // Region Views
        container.RegisterForRegionNavigation<SomeRegionView, SomeRegionViewModel>();

        container.RegisterInstance(SemanticScreenReader.Default);
      })
      .OnInitialized(containerProvider =>
      {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion("ContentRegion", nameof(SomeRegionView));
      })
      .OnAppStart($"{nameof(MainTabPage)}");

    // Alternative OnAppStart builders
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
}
