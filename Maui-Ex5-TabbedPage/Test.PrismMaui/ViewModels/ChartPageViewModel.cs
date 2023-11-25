using System.Diagnostics;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels;

public class ChartPageViewModel : ViewModelActiveBase
{
  private readonly CounterService _counter;

  public ChartPageViewModel(INavigationService nav, CounterService counter)
    : base(nav)
  {
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
    _counter.Stop();
    Debug.WriteLine("ChartPageViewModel - OnDisappearing");
  }

  public override void OnIsActiveChanged()
  {
    Debug.WriteLine("ChartPageViewModel - OnIsActiveChanged");
  }
}
