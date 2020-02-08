using Prism.Commands;
using Prism.Navigation;

namespace Test.PrismXF.ViewModels
{
  public class Page3ViewModel : BaseViewModel, INavigatedAware
  {
    public Page3ViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
    }

    public void OnNavigatingTo(NavigationParameters parameters)
    { // INavigatedAware
      // Executed before the page is pushed onto the stack
      if (parameters.ContainsKey("id"))
        Title = (string)parameters["id"];
    }

    public DelegateCommand GoBackOneCommand => new DelegateCommand(OnGoBackOne);

    public DelegateCommand GoBackRootCommand => new DelegateCommand(OnGoBackRoot);

    public DelegateCommand ForceBackOneCommand => new DelegateCommand(OnForceBackOne);

    public DelegateCommand ForceBackTwoCommand => new DelegateCommand(OnForceBackTwo);

    private void OnGoBackOne()
    {
      NavigationService.GoBackAsync();
    }

    private void OnGoBackRoot()
    {
      NavigationService.GoBackToRootAsync();
    }

    private void OnForceBackOne()
    {
      NavigationService.NavigateAsync("../");
    }

    private void OnForceBackTwo()
    {
      // Always use proper navigation flows
      //
      // NOTE: This will break navigation if
      //  1. [Main] => Nav."ThirdPage"
      //  2. [3rd]  => Nav."../../"
      //  3. [3rd]  (now back button is GONE!)
      NavigationService.NavigateAsync("../../");
    }
  }
}