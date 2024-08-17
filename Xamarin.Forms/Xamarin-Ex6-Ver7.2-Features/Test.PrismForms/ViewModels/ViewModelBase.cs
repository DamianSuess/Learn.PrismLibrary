using Prism.Mvvm;
using Prism.Navigation;

namespace Test.PrismForms.ViewModels
{
  public class ViewModelBase : BindableBase, IDestructible // , INavigationAware
  {
    private string _title;

    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    protected INavigationService NavigationService { get; private set; }

    ////public virtual void OnNavigatedFrom(INavigationParameters parameters)
    ////{
    ////}

    ////public virtual void OnNavigatedTo(INavigationParameters parameters)
    ////{
    ////}

    ////public virtual void OnNavigatingTo(INavigationParameters parameters)
    ////{
    ////}

    public virtual void Destroy()
    {
    }
  }
}
