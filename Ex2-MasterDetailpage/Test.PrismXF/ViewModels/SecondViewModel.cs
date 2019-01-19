using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Test.PrismXF.ViewModels
{
  public class SecondViewModel : ViewModelBase
  {
    private IPageDialogService _pageDialog;
    private INavigationService _navigateService;

    public SecondViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        : base(navigationService)
    {
      Title = "Second Page";

      _navigateService = navigationService;
      _pageDialog = pageDialog;
    }

    public DelegateCommand GoBackCommand => new DelegateCommand(OnGoBack);

    private async void OnGoBack()
    {
      // nothing
      // await _navigateService.GoBackToRootAsync();
    }
  }
}