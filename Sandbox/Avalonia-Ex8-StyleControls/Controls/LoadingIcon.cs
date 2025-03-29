using Avalonia;
using Avalonia.Controls;

namespace SampleApp.Controls;

public class LoadingIcon : ContentControl
{
  public static readonly StyledProperty<bool> IsLoadingProperty =
    AvaloniaProperty.Register<LoadingIcon, bool>(nameof(IsLoading));

  public bool IsLoading
  {
    get => GetValue(IsLoadingProperty);
    set => SetValue(IsLoadingProperty, value);
  }
}
