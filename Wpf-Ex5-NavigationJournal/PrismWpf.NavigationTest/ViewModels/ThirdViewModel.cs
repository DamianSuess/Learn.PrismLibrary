using Prism.Commands;
using Prism.Regions;

namespace PrismWpf.NavigationTest.ViewModels;

public class ThirdViewModel : ViewModelBase
{
  private IRegionNavigationJournal? _journal = null;

  private readonly IRegionManager? _regionManager = null;
  private bool _state;
  private string _buttonMessage = string.Empty;

  public ThirdViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;
    State = false;
  }

  public DelegateCommand GoBackCommand => new(() =>
  {
    if (_journal is { CanGoBack: true })
    {
      _journal.GoBack();
    }
  });

  public DelegateCommand NegateStateCommand => new(() =>
  {
    State = !State;
  });

  public bool State
  {
    get => _state;
    set
    {
      SetProperty(ref _state, value);
      ButtonMessage = State.ToString();
    }
  }

  public string ButtonMessage { get => _buttonMessage; set => SetProperty(ref _buttonMessage, value); }

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    _journal = navigationContext.NavigationService.Journal;
  }
}
