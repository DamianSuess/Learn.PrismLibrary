using Avalonia.Controls;
using Avalonia.Threading;
using Prism.Commands;

namespace SampleUITester.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private int _clickCounter = 0;
  private string _clickMessage = string.Empty;
  private string _greeting = string.Empty;

  public MainWindowViewModel()
  {
    Title = "Welcome to Prism.Avalonia by Suess Labs!";

#if DEBUG || UI_TESTS_ENABLED
    Greeting = "Press F7 to run UI tests with Prism.Avalonia";
#else
    Greeting = "Welcome to Prism.Avalonia!";
#endif

    ClickedCounterMessage = "0";
  }

  public DelegateCommand ClickCmd => new(() =>
  {
    _clickCounter = 0;
    ClickedCounterMessage = $"Clicked {_clickCounter} times";
  });

  public string ClickedCounterMessage { get => _clickMessage; set => SetProperty(ref _clickMessage, value); }

  public string Greeting { get => _greeting; set => SetProperty(ref _greeting, value); }

  public DelegateCommand ResetCmd => new(() =>
  {
    _clickCounter = 0;
    ClickedCounterMessage = $"Clicked {_clickCounter}";
  });

  public DelegateCommand RunUITestsCmd => new(() =>
  {
    ////string resultsLog = await Avalonia.UITester.UITestRunner.RunAllTestsAsync();
    ////
    ////var msgbox = MessageBoxManager.GetMessageBoxStandard(
    ////    new MessageBoxStandardParams()
    ////    {
    ////      ContentTitle = "UI tests results",
    ////      ContentMessage = resultsLog,
    ////      WindowStartupLocation = WindowStartupLocation.CenterScreen,
    ////      ButtonDefinitions = ButtonEnum.Ok
    ////    });
    ////Dispatcher.UIThread.Post(async () => await msgbox.ShowAsync());
  });
}
