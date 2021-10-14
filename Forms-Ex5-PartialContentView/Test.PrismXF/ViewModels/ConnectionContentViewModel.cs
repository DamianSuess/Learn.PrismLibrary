using Prism.Commands;
using Prism.Navigation;

namespace Test.PrismXF.ViewModels
{
  public class ConnectionContentViewModel : BaseViewModel
  {
    private string _statusMessage;
    private int _counter;

    public ConnectionContentViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      // https://stackoverflow.com/questions/53393821/how-to-create-a-separate-view-model-for-a-contentview-in-xamarin-forms-having-pr
      // https://github.com/PrismLibrary/Prism/blob/master/Source/Xamarin/Prism.DI.Forms.Tests/Mocks/Views/XamlViewMock.xaml
      // https://github.com/PrismLibrary/Prism/blob/master/Source/Xamarin/Prism.DI.Forms.Tests/Mocks/Views/PartialView.xaml
      // https://github.com/PrismLibrary/Prism/blob/master/Source/Xamarin/Prism.DI.Forms.Tests/Mocks/ViewModels/PartialViewModel.cs

      StatusMessage = "Click the button.";
      _counter = 0;
    }

    public string StatusMessage
    {
      get => _statusMessage;
      set => SetProperty(ref _statusMessage, value);
    }

    public DelegateCommand CmdStatusUpdate => new DelegateCommand(OnStatusUpdate);

    private void OnStatusUpdate()
    {
      _counter++;
      StatusMessage = "Hello Updated! " + _counter;
    }
  }
}
