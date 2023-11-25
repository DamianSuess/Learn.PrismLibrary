/* Copyright Xeno Innovations, Inc. 2023
 * Date:    2022-12-28
 * Author:  Damian Suess
 * File:    ViewModelActiveBase.cs
 */

namespace Test.PrismMaui.ViewModels;

/// <summary>
///   Base ViewModel for <see cref="IActiveAware"/>.
///   Used for Tab ContentPages.
/// </summary>
public class ViewModelActiveBase : ViewModelBase, IActiveAware
{
  private bool _isActive = false;

  public ViewModelActiveBase(INavigationService nav)
    : base(nav)
  {
  }

  public event EventHandler? IsActiveChanged;

  /// <summary>Gets or sets a value indicating whether the tab is active or not.</summary>
  public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value, OnIsActiveChanged); }

  /// <summary>Called when a tab is changed.</summary>
  public virtual void OnIsActiveChanged()
  {
  }
}
