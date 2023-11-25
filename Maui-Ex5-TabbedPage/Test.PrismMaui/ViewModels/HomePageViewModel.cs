using System.Diagnostics;
using Test.PrismMaui.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Test.PrismMaui.ViewModels;

public class HomePageViewModel : ViewModelActiveBase
{
  private ISemanticScreenReader _screenReader { get; }
  private int _counter;
  private string _text = "";

  public HomePageViewModel(INavigationService nav, ISemanticScreenReader screenReader)
    : base(nav)
  {
    _screenReader = screenReader;

    Text = "Click Me!";

    Debug.WriteLine("HomePageViewModel - Constructed");

  }

  public DelegateCommand CmdCounter => new DelegateCommand(OnCounter);

  public string Text { get => _text; set => SetProperty(ref _text, value); }

  private void OnCounter()
  {
    _counter++;

    Text = _counter == 1 ? "Clicked one time" : $"Clicked {_counter} times";

    // Update accessibility screen reader. Ref: https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility
    _screenReader.Announce(Text);
  }

  public override void OnAppearing()
  {
    Debug.WriteLine("HomePageViewModel - OnAppearing");
  }

  public override void OnDisappearing()
  {
    Debug.WriteLine("HomePageViewModel - OnDisappearing");
  }

  public override void OnIsActiveChanged()
  {
    Debug.WriteLine("HomePageViewModel - OnIsActiveChanged");
  }
}
