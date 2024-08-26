using DryIoc;
using Prism.Commands;
using Prism.Dialogs;

namespace SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;
    private string _returnedResult = string.Empty;

    public MainWindowViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;

        Title = "Prism.Avalonia - Dialog Sample App";
    }

    public string ReturnedResult { get => _returnedResult; set => SetProperty(ref _returnedResult, value); }

    public DelegateCommand CmdShowMessageBox => new(() =>
    {
        // Simple modal dialog represented as a MessageBox
        var title = "Modal MessageBox";
        var message = "Hello, I am a simple MessageBox modal window with an OK button.\n\n" +
                      "When too much text is added, a scrollbar will appear.";

        // Note: We're disregarding the dialog result
        _dialogService.ShowDialog(
            nameof(MessageBoxView),
            new DialogParameters
            {
                { "title", title },
                { "message", message },
            });
    });

    public DelegateCommand CmdShowNonModalDialog => new(() =>
    {
        // Simple modal dialog represented as a MessageBox
        var title = "Non-Modal MessageBox";
        var message = "Hello, I am a non-modal MessageBox with an OK button.\n\n" +
                      "Notice how you can still interact with the parent window.";

        _dialogService.Show(
            nameof(MessageBoxView),
            new DialogParameters($"title={title}&message={message}"), r =>
            {
                ReturnedResult = r.Result.ToString();
            });
    });
}
