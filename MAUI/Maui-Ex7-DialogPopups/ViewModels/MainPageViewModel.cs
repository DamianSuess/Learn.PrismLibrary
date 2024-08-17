using Sample.DialogPopups.Views;

namespace Sample.DialogPopups.ViewModels;

public class MainPageViewModel : ViewModelBase
{
  private readonly INavigationService _navigation;

  public MainPageViewModel(INavigationService nav)
  {
    _navigation = nav;

    Title = "Dialog Samples App";
  }

  public DelegateCommand CmdDialogTester => new(() =>
  {
    _navigation.NavigateAsync(nameof(DialogTesterPage))
    .OnNavigationError(ex => Console.WriteLine(ex));
  });
}
