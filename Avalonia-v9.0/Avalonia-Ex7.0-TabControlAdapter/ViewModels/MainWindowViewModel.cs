using Avalonia.Controls;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private readonly IRegionManager _regionManager;

  private int _selectedTabIndex;
  private TabItem _selectedTabItem;

  public MainWindowViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;

    Title = "Tab Region Adapter for Prism.Avalonia by Suess Labs!";
  }
  public string Greeting => "Welcome to Prism.Avalonia!";

  public int SelectedTabIndex { get => _selectedTabIndex; set => SetProperty(ref _selectedTabIndex, value); }

  public TabItem SelectedTabItem { get => _selectedTabItem; set => SetProperty(ref _selectedTabItem, value); }
}
