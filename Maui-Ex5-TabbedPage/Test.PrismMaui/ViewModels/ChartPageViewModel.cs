using System.Diagnostics;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels;

public class ChartPageViewModel : ViewModelActiveBase
{
  private readonly CounterService _counterSvc;
  private readonly IEventAggregator _event;
  private int _counter;

  public ChartPageViewModel(INavigationService nav, CounterService counter, IEventAggregator ea)
    : base(nav)
  {
    _counterSvc = counter;
    _event = ea;

    Debug.WriteLine("ChartPageViewModel - Constructed");
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
    Debug.WriteLine("ChartPageViewModel - OnAppearing");

    _event.GetEvent<CounterEvent>().Subscribe(OnCounter);
  }

  public override void OnDisappearing()
  {
    Debug.WriteLine("ChartPageViewModel - OnDisappearing");

    _counterSvc.Stop();
    _event.GetEvent<CounterEvent>().Unsubscribe(OnCounter);
  }

  public override void OnIsActiveChanged()
  {
    Debug.WriteLine("ChartPageViewModel - OnIsActiveChanged");
  }

  private void OnCounter(int counter)
  {
    Counter = counter;
  }
}
