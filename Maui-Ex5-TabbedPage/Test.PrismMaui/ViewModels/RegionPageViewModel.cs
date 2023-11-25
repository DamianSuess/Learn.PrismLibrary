using System.Diagnostics;
using System.Diagnostics.Metrics;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels;

public class RegionPageViewModel : ViewModelActiveBase
{
  private readonly CounterService _counter;

  public RegionPageViewModel(INavigationService nav, CounterService counter)
    : base(nav)
  {
    Title = "Region Page";
    _counter = counter;

    Debug.WriteLine("ChartPageViewModel - Constructed");
  }

  public DelegateCommand CmdReset => new(() =>
  {
    _counter.Reset();
  });

  public DelegateCommand CmdStart => new(() =>
  {
    _counter.Start();
  });

  public DelegateCommand CmdStop => new(() =>
  {
    _counter.Stop();
  });

  public override void OnAppearing()
  {
    Debug.WriteLine("ChartPageViewModel - OnAppearing");
  }

  public override void OnDisappearing()
  {
    Debug.WriteLine("ChartPageViewModel - OnDisappearing");
  }

  public override void OnIsActiveChanged()
  {
    Debug.WriteLine("ChartPageViewModel - OnIsActiveChanged");
  }
}
