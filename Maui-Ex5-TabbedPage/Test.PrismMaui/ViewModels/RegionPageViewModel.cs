using System.Diagnostics;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels;

public class RegionPageViewModel : ViewModelActiveBase
{
  private readonly CounterService _counterSvc;
  private int _counter;

  public RegionPageViewModel(INavigationService nav, CounterService counter)
    : base(nav)
  {
    Title = "Region Page";
    _counterSvc = counter;

    Debug.WriteLine("RegionPageViewModel - Constructed");
  }

  public DelegateCommand CmdReset => new(() =>
  {
    _counterSvc.Reset();
  });

  public DelegateCommand CmdStart => new(() =>
  {
    _counterSvc.Start();
  });

  public DelegateCommand CmdStop => new(() =>
  {
    _counterSvc.Stop();
  });

  public int Counter { get => _counter; set => SetProperty(ref _counter, value); }

  public override void OnAppearing()
  {
    Debug.WriteLine("RegionPageViewModel - OnAppearing");
  }

  public override void OnDisappearing()
  {
    Debug.WriteLine("RegionPageViewModel - OnDisappearing");
  }

  public override void OnIsActiveChanged()
  {
    Debug.WriteLine("RegionPageViewModel - OnIsActiveChanged - Tab: " + (IsActive ? "Entered" : "Exited"));
  }
}
