namespace Test.PrismMaui.ViewModels
{
  public class MainPageViewModel : BindableBase
  {
    private ISemanticScreenReader _screenReader { get; }
    private int _counter;
    private string _text;

    public MainPageViewModel(ISemanticScreenReader screenReader)
    {
      _screenReader = screenReader;
      Text = "Click Me!";
    }

    public string Title => "Prism Maui - Intro";

    public DelegateCommand CmdCounter => new DelegateCommand(OnCounter);

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

      // this is new...
      _screenReader.Announce(Text);
    }
  }
}
