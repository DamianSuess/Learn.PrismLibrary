using System;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public class ViewModelRegionBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
  {
    public ViewModelRegionBase(IRegionManager regionManager)
    {
      RegionManager = regionManager;
    }

    protected IRegionManager RegionManager { get; private set; }

    public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
      continuationCallback(true);
    }

    public virtual bool IsNavigationTarget(NavigationContext navigationContext)
    {
      return true;
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
  }
}