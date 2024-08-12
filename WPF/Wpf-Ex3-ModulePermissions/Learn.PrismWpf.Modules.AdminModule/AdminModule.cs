using Learn.PrismWpf.Common;
using Modules.Admin.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Modules.Admin
{
  //// [Roles("User,Admin")]
  [Roles(RoleName.User)]
  public class AdminModule : IModule
  {
    private IRegionManager _regionManager;

    public AdminModule(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AdminView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}