using System;

namespace Sample.NavAnimation.Controls;

public class AnimationCompletedEventArgs : EventArgs
{
  public bool ANewAnimationIsRunning { get; set; }

  public bool IsCanceled { get; set; }
}
