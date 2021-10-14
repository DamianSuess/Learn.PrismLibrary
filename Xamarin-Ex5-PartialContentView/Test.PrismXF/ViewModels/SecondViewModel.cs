using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Test.PrismXF.ViewModels
{
  public class SecondViewModel : BaseViewModel
  {
    private IPageDialogService _pageDialog;

    public SecondViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        : base(navigationService)
    {
      Title = "Second Page";

      _pageDialog = pageDialog;
    }

    public DelegateCommand GoBackCommand => new DelegateCommand(OnGoBack);

    private async void OnGoBack()
    {
      await NavigationService.GoBackAsync();

      // NOTE: This will fail under the following scenerio
      //  1. [Main] => Nav."Second/Third"
      //  2. [3rd]  => Nav.GoBackOne()
      //  3. [2nd]  => Nav.GoBackToRoot() !FAIL! must use, GoBackOne
      // await NavigationService.GoBackToRootAsync();
    }
  }
}