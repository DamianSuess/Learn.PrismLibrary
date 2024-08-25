namespace Test.PrismMaui.ViewModels;

public class ViewModelBase : BindableBase, IPageLifecycleAware
{
  private bool _isBusy = false;
  private string _title = string.Empty;

  public ViewModelBase(INavigationService nav)
  {
    NavigationService = nav;
  }

  public bool IsBusy
  {
    get => _isBusy;
    set => SetProperty(ref _isBusy, value);
  }

  public INavigationService NavigationService { get; }

  public string Title
  {
    get => _title;
    set => SetProperty(ref _title, value);
  }

  public virtual void OnAppearing()
  {
  }

  public virtual void OnDisappearing()
  {
  }
}