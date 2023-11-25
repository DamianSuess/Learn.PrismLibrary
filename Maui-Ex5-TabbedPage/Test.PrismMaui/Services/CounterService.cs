using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Test.PrismMaui.Services;

public class CounterService
{
  private readonly IEventAggregator _eventAggregator;
  private readonly Random _random = new();

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

    _eventAggregator
      .GetEvent<CounterEvent>()
      .Publish(Counter);
  }

  public void Start()
  {
    _timer.Enabled = true;
  }

  public void Stop()
  {
    _timer.Enabled = false;
  }

  private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
  {
    Counter++;

    var rnd = _random.Next(0, 10);

    _eventAggregator
      .GetEvent<CounterEvent>()
      .Publish(rnd);
  }
}
