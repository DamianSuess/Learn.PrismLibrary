using Test.PrismMaui.Views;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace Test.PrismMaui.ViewModels;

public class MainPageViewModel : ViewModelBase, INavigatedAware
{
  private readonly INavigationService _nav;
  private ISemanticScreenReader _screenReader { get; }
  private int _counter;
  private string _text;

  public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService nav)
    : base(nav)
  {
    _screenReader = screenReader;
    _nav = nav;
    Text = "Click Me!";
    Title = "Prism Maui - Intro";
  }

  public DelegateCommand CmdCounter => new(OnCounter);

  public DelegateCommand CmdNavigateBasic => new(() =>
  {
    _nav.NavigateAsync($"{nameof(Page2View)}");
  });

  public DelegateCommand CmdNavigateParams => new(() =>
  {
    _nav.NavigateAsync($"{nameof(Page2View)}", new NavigationParameters("Key=Value"));
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

    // Update accessibility screen reader. Ref: https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility
    _screenReader.Announce(Text);
  }

  public void OnNavigatedFrom(INavigationParameters parameters)
  {
  }

  public void OnNavigatedTo(INavigationParameters parameters)
  {
    if (parameters.GetNavigationMode() == NavigationMode.Back)
    {
      Text = "Navigated back from sub-page.";
    }
  }
}
