using Prism.Commands;

namespace SampleUITester.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  public MainWindowViewModel()
  {
    Title = "Welcome to Prism.Avalonia by Suess Labs!";
  }

  public DelegateCommand ClickCmd => new(() =>
  {
    ;
  });

  public string ClickedCounterMessage { get; set; }
  public string Greeting => "Welcome to Prism.Avalonia!";

  public DelegateCommand ResetCmd => new(() =>
  {
    ;
  });

  public DelegateCommand RunUITestsCmd => new(() =>
    {
      ; // Do stuff
    });
}
