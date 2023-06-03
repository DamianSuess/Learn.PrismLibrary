using Test.PrismMaui.Views;

namespace Test.PrismMaui.ViewModels
{
  public class SplashViewModel : INavigationAware // IPageLifecycleAware
  {
    private readonly INavigationService _navService;

    public SplashViewModel(INavigationService navService)
    {
      _navService = navService;
    }

    public void OnAppearing()
    {
      // DON't USE THIS.. THERE's A Cyclic-Navigation BUG
      // AND IT IS REALLY REALLY BAD
      //
      // todo: The screen stays black until 5sec is over
      // Task.Delay(5000).Wait();

      // todo: This falls through too.
      Task.Delay(5000).ConfigureAwait(false);

      _navService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainView)}");

      // When navigating away/to from a subpage, it goes back to root?!
      ////_navService
      ////  .CreateBuilder()
      ////  .AddNavigationPage()    // Add Navigation page so we can have Back buttons
      ////  .AddSegment<MainView>()
      ////  .Navigate();
    }

    public void OnDisappearing()
    {
      // throw new NotImplementedException();
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
      _navService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainView)}");

      // When navigating away/to from a subpage, it goes back to root?!
      ////_navService
      ////  .CreateBuilder()
      ////  .AddNavigationPage()    // Add Navigation page so we can have Back buttons
      ////  .AddSegment<MainView>()
      ////  .Navigate();
    }
  }
}
