using Prism.Navigation;

namespace Test.PrismXF.ViewModels
{
  public class ThirdViewModel : ViewModelBase, INavigatedAware
  {
    private INavigationService _navigateService;

    public ThirdViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";

      _navigateService = navigationService;
    }

    public void OnNavigatedFrom(NavigationParameters parameters)
    { // INavigatedAware
      // Navigated away from the page
    }

    public void OnNavigatedTo(NavigationParameters parameters)
    { // INavigatedAware
      // After the page has been pushed onto the stack, and it is now visible
    }

    public void OnNavigatingTo(NavigationParameters parameters)
    { // INavigatedAware
      // Executed before the page is pushed onto the stack
      if (parameters.ContainsKey("id"))
        Title = (string)parameters["id"];
    }
  }
}