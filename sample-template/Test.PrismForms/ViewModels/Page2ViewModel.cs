using Prism.Navigation;
using Prism.Services;

namespace Test.PrismForms.ViewModels
{
  public class Page2ViewModel : ViewModelBase
  {
    private IPageDialogService _pageDialog;

    public Page2ViewModel(INavigationService navigationService, IPageDialogService pageDialog)
        : base(navigationService)
    {
      Title = "Second Page";

      _pageDialog = pageDialog;
    }
  }
}