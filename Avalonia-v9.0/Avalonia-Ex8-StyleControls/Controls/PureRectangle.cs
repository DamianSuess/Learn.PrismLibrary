using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace SampleApp.Controls;

/// <summary>Simplified rectangle, without border and corner radius.</summary>
public class PureRectangle : Control
{
  public static readonly StyledProperty<IBrush?> BackgroundProperty =
    Border.BackgroundProperty.AddOwner<PureRectangle>();

  static PureRectangle()
  {
    AffectsRender<PureRectangle>(BackgroundProperty);
  }

  public IBrush? Background
  {
    get => GetValue(BackgroundProperty);
    set => SetValue(BackgroundProperty, value);
  }

  public override void Render(DrawingContext context)
  {
    base.Render(context);
    context.DrawRectangle(Background, null, new Rect(Bounds.Size));
  }
}
