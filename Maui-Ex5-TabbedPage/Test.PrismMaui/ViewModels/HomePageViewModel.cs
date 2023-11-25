using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PrismMaui.ViewModels;

public class HomePageViewModel : ViewModelActiveBase
{
  public HomePageViewModel(INavigationService nav)
    : base(nav)
  {
  }

  public override void OnIsActiveChanged()
  {
    System.Diagnostics.Debug.WriteLine("OnIsActiveChanged");
  }

  public override void OnAppearing()
  {
    System.Diagnostics.Debug.WriteLine("OnAppearing");
  }

  public override void OnDisappearing()
  {
    System.Diagnostics.Debug.WriteLine("OnDisappearing");
  }

}
