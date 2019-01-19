using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Test.PrismXF.ViewModels
{
  public class MainViewModel : ViewModelBase
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

    public DelegateCommand NavigatePage2Command => new DelegateCommand(NavigatePage2);

    public DelegateCommand NavigatePage3Command => new DelegateCommand(NavigatePage3);

    // Display warnings before navigating
    // REQUIRES: IConfirmNavigationAsync class reference
    ////public Task<bool> CanNavigateAsync(INavigationParameters parameters)
    ////{ // IConfirmNavigationAsync - Am i allowed to navigate?
    ////  return _dialogService.DisplayAlertAsync("Title", "This form is dirty, fix it", "Accept", "Cancel");
    ////}

    private async void NavigatePage2()
    {
      await _navigateService.NavigateAsync(new Uri("CustomMDPage/NavigationPage/SecondPage", UriKind.Relative));
      // DONE USE: This will loose our MasterDetailPage
      // await _navigateService.NavigateAsync("SecondPage");
    }

    private async void NavigatePage3()
    {
      var p = new NavigationParameters("?id=2&name=damian");
      await _navigateService.NavigateAsync("CustomMDPage/NavigationPage/ThirdPage", p);
      ////  await _navigateService.NavigateAsync("FifthPage?id=2&name=damian");
    }
  }
}