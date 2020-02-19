using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Test.PrismForms.Views;

namespace Test.PrismForms.ViewModels
{
  public class MainViewModel : ViewModelBase, IConfirmNavigationAsync, IInitializeAsync
  {
    private INavigationService _navigateService;
    private IPageDialogService _dialogService;

    public MainViewModel(INavigationService navigationService, IPageDialogService dialogService)
        : base(navigationService)
    {
      Title = "Main Page";
      _navigateService = navigationService;
      _dialogService = dialogService;
    }

    //// Tell other property to update as well :)
    //// public DelegateCommand NavigatePage4Command => new DelegateCommand(Navigate).ObservesProperty(() => Title);

    public DelegateCommand CmdNavigatePage2 => new DelegateCommand(OnNavigatePage2);

    public DelegateCommand CmdNavigatePage3 => new DelegateCommand(OnNavigatePage3);

    public Task<bool> CanNavigateAsync(INavigationParameters parameters)
    {
      // IConfirmNavigationAsync - Am i allowed to navigate?
      return _dialogService.DisplayAlertAsync("Title", "This form is dirty, fix it", "Accept", "Cancel");
    }

    public async Task InitializeAsync(INavigationParameters parameters)
    {
      System.Console.WriteLine($"Initializing MainViewModel...");

      await Task.Delay(3000);

      System.Console.WriteLine($"Initialize MainViewModel completed. ");
    }

    private async void OnNavigatePage2()
    {
      // await _navigateService.NavigateAsync("NavigationPage/SecondPage");
      await _navigateService.NavigateAsync(nameof(Page2View));
    }

    private async void OnNavigatePage3()
    {
      // 7.2 - We can pass parameters in-line now
      await _navigateService.NavigateAsync(nameof(Page3AutoInitView), ("NavMessage", "hello"));

      // Alternative Methods
      // -------------------
      // #2 - Manually define parameters. Best use when passing objects
      // var p = new NavigationParameters();
      // p.Add("NavMessage", "hello");
      // 
      // #3 - URI parameters to nav to a page
      // var p = new NavigationParameters("?NavMessage=HelloThere&name=Damian");
      // await _navigateService.NavigateAsync(nameof(Page3AutoInitView), p);
      //
      // #4 - URI in-line
      // await _navigateService.NavigateAsync($"{nameof(Page3AutoInitView)}?NavMessage=HelloThere&name=Damian");
    }

  }
}