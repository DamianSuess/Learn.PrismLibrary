using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace SampleApp.ViewModels;

/// <summary>
///     Simple Message Box Dialog ViewModel that only supports an OK button.
///
///     Parameter Inputs:
///         Title (string): Window's caption
///         Message (string): Text to display
/// </summary>
public class MessageBoxViewModel : BindableBase, IDialogAware
{
    private string _customMessage = string.Empty;
    private string _title = "Notification";
    private int _maxHeight;
    private int _maxWidth;

    public MessageBoxViewModel()
    {
        Title = "Alert!";

        MaxHeight = 800;
        MaxWidth = 600;
    }

    public DialogCloseListener RequestClose { get; }
    
    public string Title { get => _title; set => SetProperty(ref _title, value); }

    public int MaxHeight { get => _maxHeight; set => SetProperty(ref _maxHeight, value); }

    public int MaxWidth { get => _maxWidth; set => SetProperty(ref _maxWidth, value); }

    public DelegateCommand<string> CmdResult => new((string param) =>
    {
        System.Diagnostics.Debug.WriteLine($"CmdResult('{param}')");

        // None = 0, OK = 1, Cancel = 2, Abort = 3, Retry = 4, Ignore = 5, Yes = 6, No = 7
        ButtonResult result = ButtonResult.None;

        if (int.TryParse(param, out int intResult))
            result = (ButtonResult)intResult;

        RequestClose.Invoke(result);
    });

    public string CustomMessage { get => _customMessage; set => SetProperty(ref _customMessage, value); }

    /// <summary>Allow the dialog to close</summary>
    public virtual bool CanCloseDialog() => true;

    public virtual void OnDialogClosed()
    {
        // Detach custom event handlers here, etc.
        System.Diagnostics.Debug.WriteLine("OnDialogClosed()");
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        System.Diagnostics.Debug.WriteLine("OnDialogOpened()");

        var title = parameters.GetValue<string>("title");
        if (!string.IsNullOrEmpty(title))
            Title = title;

        CustomMessage = parameters.GetValue<string>("message");
    }
}
