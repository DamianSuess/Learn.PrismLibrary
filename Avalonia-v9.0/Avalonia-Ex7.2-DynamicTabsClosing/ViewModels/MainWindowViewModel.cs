using System.Diagnostics;
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

  public DelegateCommand CmdRemoveActiveTab => new(() =>
  {
    var items = _regionManager.Regions[RegionNames.DocumentTabRegion];

    // Find our view
    foreach (var view in items.ActiveViews)
    {
      // Convert to UserControl, as that's whats stored in DocumentTabRegion.
      var uc = view as UserControl;
      if (uc is not null)
      {
        Debug.WriteLine($"Closing View: {uc}");
        _regionManager.Regions[RegionNames.DocumentTabRegion].Remove(view);
      }
    }
  });

  public string Greeting => "Welcome to Prism.Avalonia!";

  public int TabIndexSelected { get => _tabIndexSelected; set => SetProperty(ref _tabIndexSelected, value); }

  public TabItem TabItemSelected { get => _tabItemSelected; set => SetProperty(ref _tabItemSelected, value); }
}
