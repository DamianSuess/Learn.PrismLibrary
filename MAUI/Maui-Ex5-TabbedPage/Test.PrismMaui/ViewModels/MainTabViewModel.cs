using System.Diagnostics;

namespace Test.PrismMaui.ViewModels;

public class MainTabViewModel : ViewModelActiveBase
{
  public MainTabViewModel(INavigationService nav)
    : base(nav)
  {
    Title = "MainTab Page";

    Debug.WriteLine("MainTabViewModel - Constructed");
  }
}
