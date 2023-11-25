namespace Test.PrismMaui.ViewModels;

public class ChartPageViewModel : ViewModelActiveBase
{
  public ChartPageViewModel(INavigationService nav)
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
