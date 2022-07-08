using Test.PrismMaui.Views;

namespace Test.PrismMaui
{
  internal static class PrismStartup
  {
    public static void Configure(PrismAppBuilder builder)
    {
      builder.RegisterTypes(RegisterTypes)
             .OnAppStart("NavigationPage/MainPage");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<MainPage>()
                       .RegisterInstance(SemanticScreenReader.Default);
    }
  }
}
