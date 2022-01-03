using Prism.Commands;
using Prism.Navigation;

namespace Sample.PrismMobile.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private int _counter = 0;
    private string _message;

    public MainViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
      Message = "Welcome to Xamarin Forms and Prism!";
    }

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public DelegateCommand CmdTestButton => new DelegateCommand(() =>
    {
      _counter++;
      Message = $"Button Clicked {_counter} Times!";
    });
  }
}
