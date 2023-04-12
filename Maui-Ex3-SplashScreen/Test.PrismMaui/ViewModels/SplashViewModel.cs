using Test.PrismMaui.Views;

namespace Test.PrismMaui.ViewModels
{
  public class SplashViewModel : IPageLifecycleAware
  {
    private readonly INavigationService _navService;

    public SplashViewModel(INavigationService navService)
    {
      _navService = navService;
    }

    public void OnAppearing()
    {
      // todo: The screen stays black until 5sec is over
      // Task.Delay(5000).Wait();

      // todo: This falls through too.
      Task.Delay(5000).ConfigureAwait(false);

      _navService
        .CreateBuilder()
        .AddNavigationPage()    // Add Navigation page so we can have Back buttons
        .AddSegment<MainView>()
        .Navigate();
    }

    public void OnDisappearing()
    {
      // throw new NotImplementedException();
    }
  }
}
