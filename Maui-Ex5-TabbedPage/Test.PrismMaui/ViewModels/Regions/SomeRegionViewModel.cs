﻿using System.Collections.ObjectModel;
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

      if (_itemA.Count > 100)
        _itemA.RemoveAt(0);
    }
  }
}
