using System.Diagnostics;

namespace Test.PrismMaui.ViewModels;

public class MainTabViewModel : ViewModelActiveBase
{
  public MainTabViewModel(INavigationService nav)
    : base(nav)
  {
    Debug.WriteLine("MainTabViewModel - Constructed");
  }
}
