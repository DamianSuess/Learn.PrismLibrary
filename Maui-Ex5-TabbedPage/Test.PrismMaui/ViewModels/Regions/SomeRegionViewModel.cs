using System.Collections.ObjectModel;
using System.Diagnostics;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Prism.Common;
using SkiaSharp;

namespace Test.PrismMaui.ViewModels.Regions;

public class SomeRegionViewModel : ViewModelRegionBase
{
  private static readonly SKColor Blue = new(25, 118, 210);
  private static readonly SKColor Red = new(229, 57, 53);
  private static readonly SKColor Yellow = new(198, 167, 0);

  public SomeRegionViewModel(INavigationService nav, IPageAccessor pageAccessor)
    : base(nav, pageAccessor)
  {
    Debug.WriteLine("SomeRegionViewModel - Constructed");
  }

  /*
  public Axis[] AxisX { get; set; } = new Axis[]
  {
      new Axis
      {
        Name = "Time",
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
        Name = "Accelerometer",
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

  public ObservableCollection<ISeries> CounterSeries { get; set; }

  public SolidColorPaint LegendTextPaint { get; set; } = new SolidColorPaint
  {
    Color = new SKColor(50, 50, 50),
    SKTypeface = SKTypeface.FromFamilyName("Consolas"),
  };
  */

  public override void OnAppearing()
  {
    base.OnAppearing();
    Debug.WriteLine("SomeRegionViewModel - OnAppearing");
  }

  public override void OnDisappearing()
  {
    base.OnDisappearing();
    Debug.WriteLine("SomeRegionViewModel - OnDisappearing");
  }

  public override void OnNavigatedFrom(INavigationContext navigationContext)
  {
    base.OnNavigatedFrom(navigationContext);
    Debug.WriteLine("SomeRegionViewModel - OnNavigatedFrom");
  }

  public override void OnNavigatedTo(INavigationContext navigationContext)
  {
    base.OnNavigatedTo(navigationContext);
    Debug.WriteLine("SomeRegionViewModel - OnNavigatedTo");
  }
}
