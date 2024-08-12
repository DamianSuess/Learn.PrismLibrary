using System;
using Prism.Regions;

namespace Test.PrismWpf.Core.Mvvm
{
  public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
  {
    public RegionViewModelBase(IRegionManager regionManager)
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
