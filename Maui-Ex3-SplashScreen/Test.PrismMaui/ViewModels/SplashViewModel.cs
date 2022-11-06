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
      Task.Delay(5000).ConfigureAwait(false);

      _navService
        .CreateBuilder()
        .AddSegment<MainView>() // Previously: .AddNavigationSegment<MainView>()
        .Navigate();
    }

    public void OnDisappearing()
    {
      // throw new NotImplementedException();
    }
  }
}
