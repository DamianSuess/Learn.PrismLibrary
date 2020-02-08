using Prism.Mvvm;
using Prism.Navigation;
using Test.PrismXF.Tabs;

namespace Test.PrismXF.ViewModels
{
  public class MainTabbedViewModel : BindableBase, INavigationAware
  {
    private IAppCommands _appCommands;

    public MainTabbedViewModel(IAppCommands appCommands)
    {
      _appCommands = appCommands;
    }

    public IAppCommands AppCommands
    {
      get => _appCommands;
      set
      {
        _appCommands = value;
        RaisePropertyChanged();
      }
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    public void OnNavigatingTo(INavigationParameters parameters)
    {
    }
  }
}