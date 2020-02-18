using Prism.Navigation;

namespace Test.PrismForms.ViewModels
{
  public class Page3ViewModel : ViewModelBase, INavigatedAware
  {
    private INavigationService _navigateService;

    public Page3ViewModel(INavigationService navigationService)
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