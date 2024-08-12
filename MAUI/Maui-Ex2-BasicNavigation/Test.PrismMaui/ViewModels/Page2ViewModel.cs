namespace Test.PrismMaui.ViewModels;

public class Page2ViewModel : ViewModelBase, INavigationAware
{
  private readonly INavigationService _nav;
  private string _message;

  public Page2ViewModel(INavigationService nav)
    : base(nav)
  {
    _nav = nav;
  }

  public string Message { get => _message; set => SetProperty(ref _message, value); }

  public DelegateCommand CmdNavigateBack => new DelegateCommand(() =>
  {
    _nav.GoBackAsync();
  });

  public void OnNavigatedFrom(INavigationParameters parameters)
  {
  }

  public void OnNavigatedTo(INavigationParameters parameters)
  {
    Message = parameters.ContainsKey("Key") ? "with parameter passed" : "without parameter passed";
  }
}
