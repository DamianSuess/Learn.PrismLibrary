using System.Diagnostics;
using Prism.Common;

namespace Test.PrismMaui.ViewModels.Regions;

public class ChartRegionViewModel : ViewModelRegionBase
{
  public ChartRegionViewModel(INavigationService nav, IPageAccessor pageAccessor)
    : base(nav, pageAccessor)
  {
    Debug.WriteLine("ChartRegionViewModel - Constructed");
  }
}
