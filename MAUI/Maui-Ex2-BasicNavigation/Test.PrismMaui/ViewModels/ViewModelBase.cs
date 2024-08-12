namespace Test.PrismMaui.ViewModels;

public class ViewModelBase : BindableBase
{
  private INavigationService _nav;
  private string _title;

  public ViewModelBase(INavigationService nav)
  {
    _nav = nav;
  }

  public string Title { get => _title; set => SetProperty(ref _title, value); }

  public INavigationService NavigationService { get => _nav; set => SetProperty(ref _nav, value); }
}
