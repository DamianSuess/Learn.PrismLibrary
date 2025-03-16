using Avalonia.Controls;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.Regions;
using SampleApp.Views;

namespace SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private readonly IRegionManager _regionManager;

  private int _documentCounter;
  private int _tabIndexSelected;
  private TabItem _tabItemSelected;

  public MainWindowViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;

    Title = "Tab Region Adapter for Prism.Avalonia by Suess Labs!";
  }

  public DelegateCommand CmdAddTab => new(() =>
  {
    _documentCounter++;

    var p = new NavigationParameters
    {
      { ParameterNames.DocumentIndex, _documentCounter.ToString() }
    };

    _regionManager.RequestNavigate(RegionNames.DocumentTabRegion, nameof(DocumentView), p);
  });

  public DelegateCommand CmdRemoveTab => new(() =>
  {
    ;
  });

  public string Greeting => "Welcome to Prism.Avalonia!";

  public int TabIndexSelected { get => _tabIndexSelected; set => SetProperty(ref _tabIndexSelected, value); }

  public TabItem TabItemSelected { get => _tabItemSelected; set => SetProperty(ref _tabItemSelected, value); }
}
