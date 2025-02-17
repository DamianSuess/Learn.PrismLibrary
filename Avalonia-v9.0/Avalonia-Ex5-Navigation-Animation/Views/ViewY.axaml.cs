using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Sample.NavAnimation.Controls;

namespace Sample.NavAnimation;

public partial class ViewY : UserControl, IInOutAnimation
{
  private readonly Dictionary<Task, CancellationTokenSource> _tc = new();

  private int _inAniId;

  private int _outAniId;

  public ViewY()
  {
    InitializeComponent();
  }

  public event EventHandler<AnimationCompletedEventArgs>? InAnimationCompleted;

  public event EventHandler<AnimationCompletedEventArgs>? OutAnimationCompleted;

  public CancellationTokenSource? InCancellationTokenSource { get; private set; }

  public bool IsInAnimationRunning { get; private set; }

  public bool IsOutAnimationRunning { get; private set; }

  public CancellationTokenSource? OutCancellationTokenSource { get; private set; }

  private Animation InAnimation => new()
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
              : Opacity
          },
          new Setter
          {
            Property = ScaleTransform.ScaleXProperty,
            Value    = this.RenderTransform?.Value.M11 ?? 6d,
          },
          new Setter
          {
            Property = ScaleTransform.ScaleYProperty,
            Value    = this.RenderTransform?.Value.M22 ?? 6d,
          },
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
            Property = ScaleTransform.ScaleXProperty,
            Value    = 1d
          },
          new Setter
          {
            Property = ScaleTransform.ScaleYProperty,
            Value    = 1d
          },
        },
        Cue = new Cue(1d)
      }
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400)
  };

  private Animation OutAnimation => new()
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
              : Opacity
          },
          new Setter
          {
            Property = ScaleTransform.ScaleXProperty,
            Value    = RenderTransform?.Value.M11 ?? 1d,
          },
          new Setter
          {
            Property = ScaleTransform.ScaleYProperty,
            Value    = RenderTransform?.Value.M22 ?? 1d,
          },
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
            Property = ScaleTransform.ScaleXProperty,
            Value    = 6d
          },
          new Setter
          {
            Property = ScaleTransform.ScaleYProperty,
            Value    = 6d
          },
        },
        Cue = new Cue(1d)
      }
    },
    FillMode = FillMode.Forward,
    Duration = TimeSpan.FromMilliseconds(400)
  };

  public Task RunInAnimationAsync()
  {
    _inAniId++;

    var inAniId = _inAniId;
    InCancellationTokenSource = new CancellationTokenSource();

    IsInAnimationRunning = true;
    Debug.Print($"{GetType().Name} start out animation.  Opacity:{Opacity}");

    var task = InAnimation.RunAsync(this, InCancellationTokenSource.Token);
    _tc.Add(task, InCancellationTokenSource);

    task.ContinueWith(t =>
    {
      var c = _tc[t];

      // Animation interrupted
      if (c.IsCancellationRequested)
      {
        // No new animation instance to run
        if (inAniId == _inAniId)
          IsInAnimationRunning = false;
      }

      InAnimationCompleted?.Invoke(
        this,
        new AnimationCompletedEventArgs()
        {
          IsCanceled = c.IsCancellationRequested,
          ANewAnimationIsRunning = inAniId != _inAniId
        });

      Debug.Print($"{GetType().Name} out end of animation");
      _tc.Remove(t);
    });

    return task;
  }

  public Task RunOutAnimationAsync()
  {
    _outAniId++;

    var outAniId = _outAniId;

    OutCancellationTokenSource = new CancellationTokenSource();

    IsOutAnimationRunning = true;
    Debug.Print($"{GetType().Name} start out animation. Opacity:{Opacity}");

    var task = OutAnimation.RunAsync(this, OutCancellationTokenSource.Token);
    _tc.Add(task, OutCancellationTokenSource);

    task.ContinueWith(t =>
    {
      var c = _tc[t];

      // Animation interrupted
      if (c.IsCancellationRequested)
      {
        // No new animation instance to run
        if (outAniId == _outAniId)
          IsOutAnimationRunning = false;
      }

      OutAnimationCompleted?.Invoke(this,
      new AnimationCompletedEventArgs()
      {
        IsCanceled = c.IsCancellationRequested,
        ANewAnimationIsRunning = outAniId != _outAniId
      });

      Debug.Print($"{GetType().Name} out end of animation");
      _tc.Remove(t);
    });

    return task;
  }
}
