using Learn.PrismWpf.BasicRegions.Views;
using Prism.Commands;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public class SidebarViewModel : ViewModelRegionBase
  {
    public SidebarViewModel(IRegionManager regionManager)
      : base(regionManager)
    {
    }

    /// <summary>Navigate to Dashboard.</summary>
    public DelegateCommand DashboardCommand => new DelegateCommand(() =>
    {
      RegionManager.RequestNavigate(Regions.ContentRegion, nameof(DashboardView));
    });

    public DelegateCommand OptionsCommand => new DelegateCommand(() =>
    {
      RegionManager.RequestNavigate(Regions.ContentRegion, nameof(OptionsView));
    });
  }
}