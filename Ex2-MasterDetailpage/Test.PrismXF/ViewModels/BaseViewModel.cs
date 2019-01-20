using Prism.Mvvm;
using Prism.Navigation;

namespace Test.PrismXF.ViewModels
{
  public class BaseViewModel : BindableBase, INavigationAware, IDestructible
  {
    protected INavigationService NavigationService { get; private set; }

    private string _title;

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public BaseViewModel(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    { // INavigatedAware
      // Navigated away from the page
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    { // INavigatedAware
      // After the page has been pushed onto the stack, and it is now visible
    }

    public virtual void OnNavigatingTo(INavigationParameters parameters)
    { // INavigatedAware
      // Executed before the page is pushed onto the stack
    }

    public virtual void Destroy()
    {
    }
  }
}