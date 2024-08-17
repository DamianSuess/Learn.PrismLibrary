using Learn.PrismWpf.Common;
using Modules.Generic.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Modules.Generic
{
  [Roles(RoleName.User)]
  public class GenericModule : IModule
  {
    private IRegionManager _regionManager;

    public GenericModule(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(GenericView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}