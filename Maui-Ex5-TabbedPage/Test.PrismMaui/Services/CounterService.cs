using System.Data;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Test.PrismMaui.Services;

public class CounterService
{
  private readonly IEventAggregator _eventAggregator;
  private Timer _timer;

  public CounterService(IEventAggregator ea)
  {
    _eventAggregator = ea;

    _timer = new(100);
    _timer.Elapsed += OnTimerElapsed;
    _timer.Enabled = false;

    Debug.WriteLine("CounterService - Constructed");
  }

  public int Counter { get; set; }

  public void Reset()
  {
    Counter = 0;
  }

  public void Start()
  {
    _timer.Enabled = true;
  }

  public void Stop()
  {
    _timer.Enabled = true;
  }

  private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
  {
    Counter++;

    _eventAggregator
      .GetEvent<CounterEvent>()
      .Publish(Counter);
  }
}
