/* Page 3 Example
 * IAutoInitialize - Automatically sets your Properties based on the passed in NavigationParameters
 */
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;

namespace Test.PrismForms.ViewModels
{
  public class Page3AutoInitViewModel : ViewModelBase, IInitializeAsync, IAutoInitialize
  {
    private INavigationService _navigateService;
    private string _navMessage;

    public Page3AutoInitViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";

      _navigateService = navigationService;
    }

    public string NavMessage
    {
      get => _navMessage;
      set => SetProperty(ref _navMessage, value);
    }

    public async Task InitializeAsync(INavigationParameters parameters)
    {
      System.Console.WriteLine($"Initializing MainViewModel...");

      await Task.Delay(3000);

      System.Console.WriteLine($"Initialize MainViewModel completed. ");
    }

    ////public void OnNavigatedFrom(INavigationParameters parameters)
    ////{ // INavigatedAware
    ////  // Navigated away from the page
    ////}

    ////public void OnNavigatedTo(INavigationParameters parameters)
    ////{ // INavigatedAware
    ////  // After the page has been pushed onto the stack, and it is now visible
    ////}

    ////public void OnNavigatingTo(INavigationParameters parameters)
    ////{ // INavigatedAware
    ////  // Executed before the page is pushed onto the stack
    ////  if (parameters.ContainsKey("id"))
    ////    Title = (string)parameters["id"];
    ////}
  }
}