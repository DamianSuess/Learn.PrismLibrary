using Prism.Navigation;
using Prism.Services;

namespace Test.PrismXF.ViewModels
{
  public class SecondViewModel : ViewModelBase
  {
    private IPageDialogService _pageDialog;

    public SecondViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        : base(navigationService)
    {
      Title = "Second Page";

      _pageDialog = pageDialog;
    }
  }
}