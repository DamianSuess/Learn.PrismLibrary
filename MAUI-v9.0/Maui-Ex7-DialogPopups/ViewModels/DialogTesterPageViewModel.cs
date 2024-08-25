using Prism.Commands;
using Prism.Dialogs;
using Prism.Navigation;
using Sample.DialogPopups.Dialogs;

namespace Sample.DialogPopups.ViewModels;

public class DialogTesterPageViewModel : ViewModelBase
{
  private readonly IDialogService _dialog;
  private readonly INavigationService _navigation;
  private string _statusText = string.Empty;

  public DialogTesterPageViewModel(INavigationService nav, IDialogService dialog)
  {
    _navigation = nav;
    _dialog = dialog;

    Title = "Dialog Samples App";
  }

  public DelegateCommand CmdGoBack => new(() =>
  {
    _navigation.GoBackAsync();
  });

  public DelegateCommand CmdShowDialog => new(() =>
    {
      _dialog.ShowDialog(nameof(OptionsDialog), null, OnDialogCallback);
    });

  public string StatusText { get => _statusText; set => SetProperty(ref _statusText, value); }

  private void OnDialogCallback()
  {
    StatusText = "Dialog Closed";
  }
}
