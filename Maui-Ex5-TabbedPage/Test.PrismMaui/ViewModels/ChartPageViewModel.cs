using System.Collections.ObjectModel;
using System.Diagnostics;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels;

public class ChartPageViewModel : ViewModelActiveBase
{
  private static readonly SKColor Blue = new(25, 118, 210);

  private readonly CounterService _counterSvc;
  private readonly IEventAggregator _event;
  private readonly ObservableCollection<ObservableValue> _itemA = new();

  private int _counter;

  public ChartPageViewModel(INavigationService nav, CounterService counter, IEventAggregator ea)
    : base(nav)
  {
    _counterSvc = counter;
    _event = ea;

    Title = "Counter Page";

    Debug.WriteLine("ChartPageViewModel - Constructed");

    ChartSeries = new()
    {
      new LineSeries<ObservableValue>() { Values = _itemA, Fill = null, Name = "A" },
    };
  }

  public Axis[] AxisX { get; set; } = new Axis[]
  {
    new()
    {
      ////Name = "Time",
      NamePaint = new SolidColorPaint(SKColors.Black),
      LabelsPaint = new SolidColorPaint(SKColors.Blue),
      TextSize = 10,
      SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
    },
  };

  public ICartesianAxis[] AxisY { get; set; } =
  {
    new Axis
    {
      Name = "ItemA",
      //// MaxLimit = MaxValue,   // Don't set the max hight for now.
      //// MinLimit = MinValue,
      NameTextSize = 10,
      NamePaint = new SolidColorPaint(Blue),
      NamePadding = new LiveChartsCore.Drawing.Padding(0, 20),
      Padding = new LiveChartsCore.Drawing.Padding(0, 0, 20, 0),
      TextSize = 10,
      LabelsPaint = new SolidColorPaint(Blue),
      TicksPaint = new SolidColorPaint(Blue),
      SubticksPaint = new SolidColorPaint(Blue),
      DrawTicksPath = true,
    },
  };

  public ObservableCollection<ISeries> ChartSeries { get; set; }

  public object ChartSync { get; } = new object();

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

  public SolidColorPaint LegendTextPaint { get; set; } = new SolidColorPaint
  {
    Color = new SKColor(50, 50, 50),
    SKTypeface = SKTypeface.FromFamilyName("Consolas"),
  };

  public override void OnAppearing()
  {
    base.OnAppearing();
    _event.GetEvent<CounterEvent>().Subscribe(OnCounter);
  }

  public override void OnDisappearing()
  {
    base.OnDisappearing();

    _counterSvc.Stop();
    _event.GetEvent<CounterEvent>().Unsubscribe(OnCounter);
  }

  private void OnCounter(int counter)
  {
    Counter = counter;

    lock (ChartSync)
    {
      _itemA.Add(new(counter));

      if (_itemA.Count > 100)
        _itemA.RemoveAt(0);
    }
  }
}
