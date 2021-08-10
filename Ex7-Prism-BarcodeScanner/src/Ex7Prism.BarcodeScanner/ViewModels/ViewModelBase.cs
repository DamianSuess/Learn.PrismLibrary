using System;
using System.Threading.Tasks;
using MvvmHelpers;
using Prism;
using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;

namespace Ex7Prism.BarcodeScanner.ViewModels
{
  public class ViewModelBase
    : BaseViewModel,
    IActiveAware,
    // INavigationAware, IConfirmNavigation, IConfirmNavigationAsync,
    IDestructible,    
    IApplicationLifecycleAware, IPageLifecycleAware
  {
    protected IPageDialogService _pageDialogService { get; }

    protected IDeviceService _deviceService { get; }

    protected INavigationService _navigationService { get; }

    public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
    {
      _pageDialogService = pageDialogService;
      _deviceService = deviceService;
      _navigationService = navigationService;
    }

    #region IActiveAware

    public bool IsActive { get; set; }

    public event EventHandler IsActiveChanged;

    private void OnIsActiveChanged()
    {
      IsActiveChanged?.Invoke(this, EventArgs.Empty);

      if (IsActive)
      {
        OnIsActive();
      }
      else
      {
        OnIsNotActive();
      }
    }

    protected virtual void OnIsActive()
    {
    }

    protected virtual void OnIsNotActive()
    {
    }

    #endregion IActiveAware

    #region INavigationAware

    public virtual void OnNavigatingTo(NavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedTo(NavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedFrom(NavigationParameters parameters)
    {
    }

    #endregion INavigationAware

    #region IDestructible

    public virtual void Destroy()
    {
    }

    #endregion IDestructible

    #region IConfirmNavigation

    public virtual bool CanNavigate(NavigationParameters parameters) => true;

    public virtual Task<bool> CanNavigateAsync(NavigationParameters parameters) => Task.FromResult(CanNavigate(parameters));

    #endregion IConfirmNavigation

    #region IApplicationLifecycleAware

    public virtual void OnResume()
    {
    }

    public virtual void OnSleep()
    {
    }

    #endregion IApplicationLifecycleAware

    #region IPageLifecycleAware

    public virtual void OnAppearing()
    {
    }

    public virtual void OnDisappearing()
    {
    }

    #endregion IPageLifecycleAware
  }
}