using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Prism.Regions;

namespace Sample.NavAnimation;

public partial class MainWindow : Window
{
  private readonly IRegionManager _regionManager;

  public MainWindow()
  {
    InitializeComponent();
  }

  public MainWindow(IRegionManager regionManager)
  {
    InitializeComponent();
    this.AttachDevTools();

    _regionManager = regionManager;
    _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(ViewX));
  }

  private void ButtonA_OnClick(object sender, RoutedEventArgs e)
  {
    _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(ViewX));
  }

  private void ButtonB_OnClick(object sender, RoutedEventArgs e)
  {
    _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(ViewY));
  }
}
