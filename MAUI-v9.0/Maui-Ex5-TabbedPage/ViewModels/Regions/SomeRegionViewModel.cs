using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Prism.Common;
using SkiaSharp;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels.Regions;

public class SomeRegionViewModel : ViewModelRegionBase
{
  private const int MaxValues = 20;
  private static readonly SKColor Blue = new(25, 118, 210);

  private readonly CounterService _counterSvc;
  private readonly IEventAggregator _event;
  private readonly ObservableCollection<ObservableValue> _itemA = new();

  public SomeRegionViewModel(
    INavigationService nav,
    IPageAccessor pageAccessor,
    CounterService cs,
    IEventAggregator ea)
    : base(nav, pageAccessor)
  {
    Debug.WriteLine("SomeRegionViewModel - Constructed");

    _counterSvc = cs;
    _event = ea;

    Title = "Some Region Page";

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

  public SolidColorPaint ChartLegendPaint { get; set; } = new SolidColorPaint
  {
    Color = new SKColor(50, 50, 50),
    SKTypeface = SKTypeface.FromFamilyName("Consolas"),
  };

  public ObservableCollection<ISeries> ChartSeries { get; set; }

  public object ChartSync { get; } = new object();

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
    lock (ChartSync)
    {
      _itemA.Add(new(counter));

      if (_itemA.Count > MaxValues)
        _itemA.RemoveAt(0);
    }
  }
}
