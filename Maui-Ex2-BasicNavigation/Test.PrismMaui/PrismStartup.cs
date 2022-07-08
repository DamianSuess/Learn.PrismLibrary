using Test.PrismMaui.ViewModels;
using Test.PrismMaui.Views;

namespace Test.PrismMaui
{
  internal static class PrismStartup
  {
    public static void Configure(PrismAppBuilder builder)
    {
      // You may also do this in-line via lambdas without the need of static methods.
      builder
        .ConfigureModuleCatalog(OnConfigureModuleCatalog)
        .RegisterTypes(OnRegisterTypes)
        .OnAppStart($"{nameof(NavigationPage)}/{nameof(MainPage)}");
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
        .RegisterForNavigation<MainPage>()                   // Auto-assign ViewModel
        .RegisterForNavigation<Page2View, Page2ViewModel>()  // Manually assign ViewModel
        .RegisterInstance(SemanticScreenReader.Default);
    }
  }
}
