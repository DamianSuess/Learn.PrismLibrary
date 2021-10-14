using Learn.PrismWpf.BasicRegions.Views;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public class MainWindowViewModel : ViewModelRegionBase
  {
    private string _title = "Prism Application";

    public MainWindowViewModel(IRegionManager regionManager)
      : base(regionManager)
    {
      RegionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(DashboardView));
      //// RegionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(OptionsView));
      RegionManager.RegisterViewWithRegion(Regions.SidebarRegion, typeof(SidebarView));

      // Pro Tip: Don't use RequestNavigate here...
      // RegionManager.RequestNavigate(Regions.ContentRegion, nameof(DashboardView));
      // RegionManager.RequestNavigate(Regions.SidebarRegion, nameof(SidebarView));
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }
  }
}