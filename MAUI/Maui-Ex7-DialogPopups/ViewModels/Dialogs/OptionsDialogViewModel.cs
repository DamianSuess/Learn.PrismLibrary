using System;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace Sample.DialogPopups.ViewModels.Dialogs;

public class OptionsDialogViewModel : BindableBase, IDialogAware
{
  private bool _canClose;

  public DelegateCommand CmdSaveAndClose => new(() =>
  {
    _canClose = true;
    RequestClose.Invoke();
  });

  public DialogCloseListener RequestClose { get; }

  public bool CanCloseDialog() => _canClose;

  public void OnDialogClosed()
  {
    Console.WriteLine("Dialog Closed");
  }

  public void OnDialogOpened(IDialogParameters parameters)
  {
    Console.WriteLine("Dialog Opened");
  }
}
