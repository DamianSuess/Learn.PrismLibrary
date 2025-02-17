using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.NavAnimation.Controls;

public interface IInOutAnimation
{
  public event EventHandler<AnimationCompletedEventArgs>? InAnimationCompleted;

  public event EventHandler<AnimationCompletedEventArgs>? OutAnimationCompleted;

  public CancellationTokenSource? InCancellationTokenSource { get; }
  public CancellationTokenSource? OutCancellationTokenSource { get; }

  public Task? RunInAnimationAsync();

  public Task? RunOutAnimationAsync();
}
