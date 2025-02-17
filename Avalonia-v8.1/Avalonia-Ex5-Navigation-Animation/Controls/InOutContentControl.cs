using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Sample.NavAnimation.Controls;

namespace Sample.NavAnimation;

/// <summary>
/// Displays <see cref="ContentControl.Content"/> according to an <see cref="IDataTemplate"/>,
/// </summary>
public class InOutContentControl : ContentControl
{
  private ContentPresenter? _oldPresenter;
  private bool _shouldAnimate;

  #region TransitionCompletedEvent

  /// <summary>
  /// Defines the <see cref="TransitionCompleted"/> routed event.
  /// </summary>
  public static readonly RoutedEvent<TransitionCompletedEventArgs> TransitionCompletedEvent =
    RoutedEvent.Register<InOutContentControl, TransitionCompletedEventArgs>(
      nameof(TransitionCompleted),
      RoutingStrategies.Direct);

  /// <summary>
  /// Raised when the old content isn't needed anymore by the control, because the transition has completed.
  /// </summary>
  public event EventHandler<TransitionCompletedEventArgs> TransitionCompleted
  {
    add => AddHandler(TransitionCompletedEvent, value);
    remove => RemoveHandler(TransitionCompletedEvent, value);
  }

  #endregion TransitionCompletedEvent

  protected override Size ArrangeOverride(Size finalSize)
  {
    var result = base.ArrangeOverride(finalSize);

    if (_shouldAnimate)
    {
      Debug.Print("Start Animation.");

      if (_oldPresenter is not null &&
          Presenter is not null)
      {
        _shouldAnimate = false;

        var tasks = new List<Task>();

        // Navigate away animation
        if (_oldPresenter.Content is IInOutAnimation f)
        {
          Debug.Print("oldContent starts the out-animation");

          // If an animation is currently in progress, cancel it
          f.OutCancellationTokenSource?.Cancel();
          f.InCancellationTokenSource?.Cancel();

          var outTask = f.RunOutAnimationAsync();

          if (outTask is not null)
            tasks.Add(outTask);
        }
        else
        {
          Debug.Print("oldContent has no out-animation, so it is hidden directly");
          HideOldPresenter();
        }

        // Navigate in animation
        if (Content is IInOutAnimation f2)
        {
          Debug.Print("Start the in-animation");

          f2.OutCancellationTokenSource?.Cancel();
          f2.InCancellationTokenSource?.Cancel();

          var inTask = f2.RunInAnimationAsync();

          if (inTask is not null)
            tasks.Add(inTask);
        }

        // After the out and in animations are all completed,
        // activate the TransitionCompleted event
        if (tasks.Count != 0)
        {
          Task.WhenAll(tasks).ContinueWith(task =>
          {
            OnTransitionCompleted(new TransitionCompletedEventArgs(
              _oldPresenter.Content,
              Content,
              task.Status == TaskStatus.RanToCompletion
            ));
          }, TaskScheduler.FromCurrentSynchronizationContext());
        }
      }

      _shouldAnimate = false;
    }

    return result;
  }

  protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
  {
    base.OnAttachedToVisualTree(e);
    UpdateContent(false);
  }

  protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
  {
    if (change.Property == ContentProperty)
    {
      UpdateContent(true);
      return;
    }

    base.OnPropertyChanged(change);
  }

  protected override bool RegisterContentPresenter(ContentPresenter presenter)
  {
    // Handled PART_ContentPresenter in the base class
    if (base.RegisterContentPresenter(presenter))
      return true;

    if (presenter is { Name: "PART_ContentPresenter2" })
    {
      _oldPresenter = presenter;
      _oldPresenter.IsVisible = false;
      UpdateContent(false);
      return true;
    }

    return false;
  }

  private void HideOldPresenter()
  {
    if (_oldPresenter is not null)
    {
      _oldPresenter.IsVisible = false;
      _oldPresenter.Content = null;
    }
  }

  private void OldPresenter_OutAnimationCompleted(object? sender, AnimationCompletedEventArgs e)
  {
    // When the animation is complete and no new animation is playing,
    // hide HideOldPresenter
    if (!e.ANewAnimationIsRunning)
      Dispatcher.UIThread.Invoke(HideOldPresenter);
  }

  private void OnTransitionCompleted(TransitionCompletedEventArgs e)
    => RaiseEvent(e);

  private void UpdateContent(bool withTransition)
  {
    if (VisualRoot is null || _oldPresenter is null || Presenter is null)
      return;

    // Put the original content into _presenter2
    var oldContent = Presenter.Content;
    Presenter.Content = null;
    if (oldContent is not null)
    {
      if (_oldPresenter.Content is IInOutAnimation o)
        o.OutAnimationCompleted -= OldPresenter_OutAnimationCompleted;

      _oldPresenter.Content = oldContent;
      if (_oldPresenter.Content is IInOutAnimation o2)
        o2.OutAnimationCompleted += OldPresenter_OutAnimationCompleted;

      _oldPresenter.IsVisible = true;
    }

    // New content is placed in Presenter
    var newContent = Content;
    Presenter.Content = newContent;
    Presenter.IsVisible = true;

    // Regardless of whether the new content is null, the old content needs to be exited
    if (withTransition)
    {
      _shouldAnimate = true;
      InvalidateArrange();
    }
    else
    {
      HideOldPresenter();
      OnTransitionCompleted(new TransitionCompletedEventArgs(oldContent, newContent, false));
    }
  }
}
