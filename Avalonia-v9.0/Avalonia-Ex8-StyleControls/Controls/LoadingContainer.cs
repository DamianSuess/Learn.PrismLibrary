using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Templates;
using Avalonia.Media;

namespace SampleApp.Controls;

[PseudoClasses(ContainerLoading)]
public class LoadingContainer : ContentControl
{
  public const string ContainerLoading = ":loading";

  public static readonly StyledProperty<object?> IndicatorProperty =
    AvaloniaProperty.Register<LoadingContainer, object?>(nameof(Indicator));

  public static readonly StyledProperty<bool> IsLoadingProperty =
    AvaloniaProperty.Register<LoadingContainer, bool>(nameof(IsLoading));

  public static readonly StyledProperty<object?> LoadingMessageProperty =
    AvaloniaProperty.Register<LoadingContainer, object?>(nameof(LoadingMessage));

  public static readonly StyledProperty<IDataTemplate> LoadingMessageTemplateProperty =
    AvaloniaProperty.Register<LoadingContainer, IDataTemplate>(nameof(LoadingMessageTemplate));

  public static readonly StyledProperty<IBrush?> MessageForegroundProperty =
    AvaloniaProperty.Register<LoadingContainer, IBrush?>(nameof(MessageForeground));

  static LoadingContainer()
  {
    IsLoadingProperty.Changed.AddClassHandler<LoadingContainer>((x, e) => x.OnIsLoadingChanged(e));
  }

  public object? Indicator
  {
    get => GetValue(IndicatorProperty);
    set => SetValue(IndicatorProperty, value);
  }

  public bool IsLoading
  {
    get => GetValue(IsLoadingProperty);
    set => SetValue(IsLoadingProperty, value);
  }

  public object? LoadingMessage
  {
    get => GetValue(LoadingMessageProperty);
    set => SetValue(LoadingMessageProperty, value);
  }

  public IDataTemplate LoadingMessageTemplate
  {
    get => GetValue(LoadingMessageTemplateProperty);
    set => SetValue(LoadingMessageTemplateProperty, value);
  }

  public IBrush? MessageForeground
  {
    get => GetValue(MessageForegroundProperty);
    set => SetValue(MessageForegroundProperty, value);
  }

  private void OnIsLoadingChanged(AvaloniaPropertyChangedEventArgs args)
  {
    bool newValue = args.GetNewValue<bool>();
    PseudoClasses.Set(ContainerLoading, newValue);
  }
}
