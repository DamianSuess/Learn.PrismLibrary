using System.Diagnostics;
using Prism.Common;

namespace Test.PrismMaui.ViewModels.Regions;

public class SomeRegionViewModel : ViewModelRegionBase
{
  public SomeRegionViewModel(INavigationService nav, IPageAccessor pageAccessor)
    : base(nav, pageAccessor)
  {
    Debug.WriteLine("SomeRegionViewModel - Constructed");
  }

  public override void OnNavigatedTo(INavigationContext navigationContext)
  {
    base.OnNavigatedTo(navigationContext);
    Debug.WriteLine("SomeRegionViewModel - OnNavigatedTo");
  }

  public override void OnNavigatedFrom(INavigationContext navigationContext)
  {
    base.OnNavigatedFrom(navigationContext);
    Debug.WriteLine("SomeRegionViewModel - OnNavigatedFrom");
  }

  public override void OnAppearing()
  {
    base.OnAppearing();
    Debug.WriteLine("SomeRegionViewModel - OnAppearing");
  }

  public override void OnDisappearing()
  {
    base.OnDisappearing();
    Debug.WriteLine("SomeRegionViewModel - OnDisappearing");
  }
}
