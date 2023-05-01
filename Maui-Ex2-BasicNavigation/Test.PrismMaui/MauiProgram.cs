using Prism.Navigation;
using Test.PrismMaui.ViewModels;
using Test.PrismMaui.Views;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder()
      .UseMauiApp<App>()
      .UsePrism(ConfigurePrism)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    return builder.Build();
  }

  public static void ConfigurePrism(PrismAppBuilder builder)
  {
    // You may also do this in-line via lambdas without the need of static methods.
    builder
      .ConfigureServices(services =>
      {
        //// services.AddSingleton(LogOperatorRetriever.Instance);
      })
      .ConfigureModuleCatalog(OnConfigureModuleCatalog)
      .RegisterTypes(container =>
      {
        // Pages
        container.RegisterForNavigation<MainPage>();                  // Auto-assign ViewModel
        container.RegisterForNavigation<Page2View, Page2ViewModel>(); // Manually assign ViewModel

        // Other stuff
        container.RegisterInstance(SemanticScreenReader.Default);
      })
      ////.OnAppStart($"{nameof(NavigationPage)}/{nameof(MainPage)}");
      .OnAppStart(nav =>
      {
        nav
        .CreateBuilder()
        .AddNavigationPage()
        .AddSegment<MainPage>()
        .NavigateAsync()
        .OnNavigationError((ex) =>
        {
          System.Diagnostics.Debug.WriteLine($"MauiProgram failed to navigate: {ex.Message}");
          System.Diagnostics.Debugger.Break();
        });
      });
  }

  private static void OnConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // Add custom Module to catalog
    //  moduleCatalog.AddModule<MauiAppModule>();
    //  moduleCatalog.AddModule<MauiTestRegionsModule>();
  }
}
