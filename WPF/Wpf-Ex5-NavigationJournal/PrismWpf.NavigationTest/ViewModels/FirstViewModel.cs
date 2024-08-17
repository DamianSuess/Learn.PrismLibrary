using Prism.Commands;
using Prism.Regions;
using PrismWpf.NavigationTest.Values;
using PrismWpf.NavigationTest.Views;

namespace PrismWpf.NavigationTest.ViewModels;

public class FirstViewModel : ViewModelBase
{
  private readonly IRegionManager _regionManager;
  private IRegionNavigationJournal? _journal;

  public FirstViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }

  public DelegateCommand GoNextCommand => new(() =>
  {
    _regionManager.RequestNavigate(RegionNames.Content, nameof(SecondView));
  });

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    // OnNavigatedTo never gets invoked
    _journal = navigationContext.NavigationService.Journal;
  }

  public bool PersistInHistory() => true;
}
