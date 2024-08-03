namespace Avalonia_Ex4_Test1101.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  public MainWindowViewModel()
  {
    Title = "Welcome to Prism.Avalonia by Suess Labs!";
  }

  public string Greeting => "Welcome to Prism.Avalonia!";
}
