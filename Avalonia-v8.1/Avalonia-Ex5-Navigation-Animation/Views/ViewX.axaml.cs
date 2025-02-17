using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Sample.NavAnimation.Controls;

namespace Sample.NavAnimation;

public partial class ViewX : UserControl, IInOutAnimation
{
  private readonly Dictionary<Task, CancellationTokenSource> _tc = new();

  private int _inAniId;

  private int _outAniId;

  public ViewX()
  {
    InitializeComponent();
  }

  public event EventHandler<AnimationCompletedEventArgs>? InAnimationCompleted;

  public event EventHandler<AnimationCompletedEventArgs>? OutAnimationCompleted;

  public CancellationTokenSource? InCancellationTokenSource { get; private set; }
  public CancellationTokenSource? OutCancellationTokenSource { get; private set; }

  private Animation InAnimation1 => new()
  {
    Children =
    {
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value = _inAniId <= 1 && _outAniId <= 1
              ? 0
              : StackPanel1.Opacity
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = StackPanel1.RenderTransform?.Value.M32 ?? 100d,
          }
        },
        Cue = new Cue(0d)
      },
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value    = 1d
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = 0d,
          }
        },
        Cue = new Cue(1d)
      },
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400),
    //Easing   = new CubicEaseIn(),
    Easing = new QuarticEaseIn(),
  };

  private Animation InAnimation2 => new()
  {
    Children =
    {
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value = _inAniId <= 1 && _outAniId <= 1
                ? 0
                : Border1.Opacity
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = Border1.RenderTransform?.Value.M32 ?? -300d,
          }
        },
        Cue = new Cue(0d)
      },
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value    = 1d
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = 0d,
          }
        },
        Cue = new Cue(1d)
      },
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400),
    //Easing   = new CubicEaseIn(),
    Easing = new QuarticEaseIn(),
  };

  private Animation OutAnimation1 => new()
  {
    Children =
    {
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value = _inAniId <= 1 && _outAniId <= 1
              ? 1
              : StackPanel1.Opacity
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = StackPanel1.RenderTransform?.Value.M32 ?? 100d,
          }
        },
        Cue = new Cue(0d)
      },
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value    = 0d
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = 100d
          }
        },
        Cue = new Cue(1d)
      }
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400),
    //Easing   = new CubicEaseOut(),
    Easing = new QuarticEaseIn(),
  };

  private Animation OutAnimation2 => new()
  {
    Children =
    {
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value = _inAniId <= 1 && _outAniId <= 1
                ? 1
                : Border1.Opacity
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = Border1.RenderTransform?.Value.M32 ?? 0d,
          }
        },
        Cue = new Cue(0d)
      },
      new KeyFrame()
      {
        Setters =
        {
          new Setter
          {
            Property = OpacityProperty,
            Value    = 0d
          },
          new Setter
          {
            Property = TranslateTransform.YProperty,
            Value    = -300d
          }
        },
        Cue = new Cue(1d)
      }
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400),
    //Easing   = new CubicEaseOut(),
    Easing = new QuarticEaseIn(),
  };

  public Task RunInAnimationAsync()
  {
    _inAniId++;

    var inAniId = _inAniId;

    InCancellationTokenSource = new CancellationTokenSource();

    Debug.Print($"{GetType().Name} in 动画开始");

    var task1 = InAnimation1.RunAsync(StackPanel1, InCancellationTokenSource.Token);
    var task2 = InAnimation2.RunAsync(Border1, InCancellationTokenSource.Token);
    var task = Task.WhenAll(task1, task2);
    _tc.Add(task, InCancellationTokenSource);
    task.ContinueWith(t =>
    {
      var c = _tc[t];
      InAnimationCompleted?.Invoke(
        this,
        new AnimationCompletedEventArgs()
        {
          IsCanceled = c.IsCancellationRequested,
          ANewAnimationIsRunning = inAniId != _inAniId
        });

      Debug.Print($"{GetType().Name} out 动画结束");
      _tc.Remove(t);
    }, InCancellationTokenSource.Token);

    return task;
  }

  public Task RunOutAnimationAsync()
  {
    _outAniId++;

    var outAniId = _outAniId;

    OutCancellationTokenSource = new CancellationTokenSource();

    Debug.Print($"{GetType().Name} start out animation");
    var task1 = OutAnimation1.RunAsync(StackPanel1, OutCancellationTokenSource.Token);
    var task2 = OutAnimation2.RunAsync(Border1, OutCancellationTokenSource.Token);

    var task = Task.WhenAll(task1, task2);

    _tc.Add(task, OutCancellationTokenSource);
    task.ContinueWith(t =>
    {
      var c = _tc[t];

      OutAnimationCompleted?.Invoke(
        this,
        new AnimationCompletedEventArgs()
        {
          IsCanceled = c.IsCancellationRequested,
          ANewAnimationIsRunning = outAniId != _outAniId
        });

      Debug.Print($"{GetType().Name} end out animation");
      _tc.Remove(t);
    }, OutCancellationTokenSource.Token);

    return task;
  }
}
