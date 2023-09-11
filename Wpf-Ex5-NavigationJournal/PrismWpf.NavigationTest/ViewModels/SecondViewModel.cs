using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using PrismWpf.NavigationTest.Values;
using PrismWpf.NavigationTest.Views;

namespace PrismWpf.NavigationTest.ViewModels;

public class SecondViewModel : ViewModelBase
{
  private IRegionNavigationJournal? _journal = null;
  private ObservableCollection<string> _themeVariants = new();
  private readonly IRegionManager? _regionManager = null;

  public SecondViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;

    ThemeVariants.Add("Dark");
    ThemeVariants.Add("Light");
    ThemeVariants.Add("Default");
  }

  public DelegateCommand GoBackCommand => new(() =>
  {
    if (_journal is { CanGoBack: true })
    {
      _journal.GoBack();
    }
  });

  ObservableCollection<string> ThemeVariants { get => _themeVariants; set => SetProperty(ref _themeVariants, value); }

  public DelegateCommand GoNextCommand => new(() =>
  {
    _regionManager.RequestNavigate(RegionNames.Content, nameof(ThirdView));
  });

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    _journal = navigationContext.NavigationService.Journal;
  }
}
