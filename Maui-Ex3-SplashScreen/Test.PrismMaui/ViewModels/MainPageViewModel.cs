using Test.PrismMaui.Views;

namespace Test.PrismMaui.ViewModels
{
  public class MainPageViewModel : BindableBase
  {
    private readonly INavigationService _nav;
    private ISemanticScreenReader _screenReader { get; }
    private int _counter;
    private string _text;

    public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService nav)
    {
      _screenReader = screenReader;
      _nav = nav;
      Text = "Click Me!";
    }

    public string Title => "Prism Maui - Intro";

    public DelegateCommand CmdCounter => new DelegateCommand(OnCounter);

    public DelegateCommand CmdNavigate => new DelegateCommand(() =>
    {
      string navTo = $"{nameof(NavigationPage)}/{nameof(MainPage)}/{nameof(Page2View)}";
      _nav.NavigateAsync(navTo);
    });

    public string Text
    {
      get => _text;
      set => SetProperty(ref _text, value);
    }

    private void OnCounter()
    {
      _counter++;

      if (_counter == 1)
        Text = "Clicked one time";
      else
        Text = $"Clicked {_counter} times";

      // Update accessability screen reader. Ref: https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility
      _screenReader.Announce(Text);
    }
  }
}
