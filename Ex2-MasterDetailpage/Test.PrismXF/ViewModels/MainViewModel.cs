using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Test.PrismXF.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    private IPageDialogService _dialogService;

    public MainViewModel(INavigationService navigationService, IPageDialogService dialogService)
        : base(navigationService)
    {
      Title = "Main Page";
      _dialogService = dialogService;
    }

    public DelegateCommand NavigatePage2Command => new DelegateCommand(NavigatePage2);

    public DelegateCommand NavigatePage3Command => new DelegateCommand(NavigatePage3);

    public DelegateCommand DoubleFwdTo3rdCommand => new DelegateCommand(OnDoubleFwdTo3rd);

    private async void NavigatePage2()
    {
      await NavigationService.NavigateAsync("SecondPage");
    }

    private async void NavigatePage3()
    {
      var p = new NavigationParameters("?id=2&name=damian");
      await NavigationService.NavigateAsync("ThirdPage", p);
      ////  await NavigationService.NavigateAsync("FifthPage?id=2&name=damian");
    }

    private async void OnDoubleFwdTo3rd()
    {
      // use BaseViewModel, not _navService directly
      await NavigationService.NavigateAsync("SecondPage/ThirdPage");
    }
  }
}