/* Copyright Xeno Innovations, Inc. 2023
 * Date:    2022-12-28
 * Author:  Damian Suess
 * File:    ViewModelRegionBase.cs
 * Description:
 *  Base Prism Region ViewModel
 */

using System.Diagnostics;
using Prism.AppModel;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;

namespace Test.PrismMaui.ViewModels;

public class ViewModelRegionBase : ViewModelBase, IRegionAware
{
  private readonly INavigationService _navigation;
  private readonly IPageAccessor _pageAccessor;

  /// <summary>Initializes a new instance of the <see cref="ViewModelRegionBase"/> class.</summary>
  /// <param name="navigation"><see cref="INavigationService"/>.</param>
  /// <param name="pageAccessor"><see cref="IPageAccessor"/>.</param>
  protected ViewModelRegionBase(INavigationService navigation, IPageAccessor pageAccessor)
    : base(navigation)
  {
    _navigation = navigation;
    _pageAccessor = pageAccessor;
  }

  public string? PageName => _pageAccessor.Page?.GetType()?.Name;

  protected string Name => GetType().Name.Replace("ViewModel", string.Empty);

  protected IRegionNavigationService? RegionNavigation { get; private set; }

  /// <inheritdoc />
  /// <remarks>Region Aware is navigation target.</remarks>
  public bool IsNavigationTarget(INavigationContext navigationContext) => navigationContext.NavigatedName() == Name;

  /// <inheritdoc />
  /// <remarks>Region Aware is navigated away from.</remarks>
  public virtual void OnNavigatedFrom(INavigationContext navigationContext)
  {
    Debug.WriteLine($"{Title} - OnNavigatedFrom");
  }

  /// <inheritdoc />
  /// <remarks>Region Aware is navigated into.</remarks>
  public virtual void OnNavigatedTo(INavigationContext navigationContext)
  {
    Debug.WriteLine($"{Title} - OnNavigatedTo");
    RegionNavigation = navigationContext.NavigationService;
  }
}
