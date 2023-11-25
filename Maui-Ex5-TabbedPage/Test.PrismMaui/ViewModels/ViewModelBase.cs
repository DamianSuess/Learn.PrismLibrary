/* Copyright Xeno Innovations, Inc. 2023
 * Date:    2022-12-28
 * Author:  Damian Suess
 * File:    ViewModelBase.cs
 * Description:
 *  Base Prism ViewModel
 */

using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Test.PrismMaui.ViewModels;

public class ViewModelBase : BindableBase, IPageLifecycleAware
{
  private bool _isBusy = false;
  private string _title = string.Empty;

  public ViewModelBase(INavigationService navigation)
  {
    NavigationService = navigation;
  }

  public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }

  public INavigationService NavigationService { get; }

  public string Title { get => _title; set => SetProperty(ref _title, value); }

  /// <summary>Page appearing detected via <see cref="IPageLifecycleAware"/>.</summary>
  public virtual void OnAppearing()
  {
  }

  /// <summary>Page disappearing detected via <see cref="IPageLifecycleAware"/>.</summary>
  public virtual void OnDisappearing()
  {
  }
}
