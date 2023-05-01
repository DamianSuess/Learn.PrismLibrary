namespace Test.PrismMaui.ViewModels;

public class Page2ViewModel : ViewModelBase
{
  public Page2ViewModel(INavigationService nav)
    : base(nav)
  {
    Title = "Prism Maui - Subpage View";
  }

  public DelegateCommand CmdNavigateBack => new DelegateCommand(() =>
  {
    NavigationService.GoBackAsync();
  });
}
