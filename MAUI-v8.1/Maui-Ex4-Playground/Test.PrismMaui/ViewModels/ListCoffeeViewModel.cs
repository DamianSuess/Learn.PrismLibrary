using System.Collections.ObjectModel;
using Test.PrismMaui.Models;

namespace Test.PrismMaui.ViewModels
{
  public class ListCoffeeViewModel : ViewModelBase ////, INavigationAware
  {
    private ObservableCollection<CoffeeBean> _coffeeBeans = new();
    private string _statusMessage = string.Empty;

    public ListCoffeeViewModel(INavigationService nav)
      : base(nav)
    {
      Title = "Prism Maui - Subpage View";
      StatusMessage = "Select an item";
    }

    public DelegateCommand CmdNavigateBack => new DelegateCommand(() =>
    {
      NavigationService.GoBackAsync();
    });

    public ObservableCollection<CoffeeBean> CoffeeBeans
    {
      get => _coffeeBeans;
      set => SetProperty(ref _coffeeBeans, value);
    }

    public CoffeeBean SelectedBean
    {
      // Don't highlight the row
      get => null;
      set
      {
        StatusMessage = $"Selected {value.Name}";
      }
    }

    public string StatusMessage
    {
      get => _statusMessage;
      set => SetProperty(ref _statusMessage, value);
    }

    public override void OnAppearing()
    {
      base.OnAppearing();
      CoffeeBeans.Add(new("None"));
      CoffeeBeans.Add(new("Arabica"));
      CoffeeBeans.Add(new("Robusta"));
    }

    // Alternate test with the same results
    ////public void OnNavigatedFrom(INavigationParameters parameters)
    ////{
    ////}
    ////
    ////public void OnNavigatedTo(INavigationParameters parameters)
    ////{
    ////  CoffeeBeans.Add(new("None"));
    ////  CoffeeBeans.Add(new("Arabica"));
    ////  CoffeeBeans.Add(new("Robusta"));
    ////}
  }
}
