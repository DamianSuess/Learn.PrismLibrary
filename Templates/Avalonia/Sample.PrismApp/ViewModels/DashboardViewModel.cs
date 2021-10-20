using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace Sample.PrismApp.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    private IEventAggregator _eventAggregator;

    public string Greeting => "Welcome to Prism.Avalonia!";

    public DashboardViewModel(IEventAggregator ea)
    {
      _eventAggregator = ea;

      Title = "Sample Prism Avalonia";
    }

    public DelegateCommand CmdTestButton => new DelegateCommand(async () =>
    {
      await Task.Yield();
    });

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
      base.OnNavigatedTo(navigationContext);
    }
  }
}
