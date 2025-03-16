using System;
using System.Collections.Specialized;
using System.Linq;
using Avalonia.Controls;
using Prism.Navigation.Regions;

namespace SampleApp.Adapters;

/// <summary>
/// Adapts TabControl's TabItem (content control) to a Prism Region
/// so that you can hook Regions to the TabControl in AXAML.
/// <code><![CDATA[
///   <TabControl prism:RegionManager.RegionName="MailTabRegion" />
/// ]]></code>
///
/// Tab Control Adapter for hooking tabs to regions. a UserControl as a TabItem
///   * Tab Header: UserControl's `Tag` property
/// </summary>
public class TabControlAdapter : RegionAdapterBase<TabControl>
{
  private const int Deactivating = 0;
  private const int Activating = 1;

  public TabControlAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
  {
  }

  protected override void Adapt(IRegion region, TabControl regionTarget)
  {
    if (region == null)
      throw new ArgumentNullException(nameof(region));

    if (regionTarget == null)
      throw new ArgumentNullException(nameof(regionTarget));

    // Detect a Tab Selection Changed
    regionTarget.SelectionChanged += (object s, SelectionChangedEventArgs e) =>
    {
      // The view navigating away from
      foreach (var item in e.RemovedItems)
      {
        // NOTE: The selected item isn't always a TabItem, if the region contains
        //       a ListBox, it's SelectionChange gets picked up.
        TargetSelectionChanged(region, Deactivating, item);
        //// region.Deactivate(item);
      }

      // The view navigating to
      foreach (var item in e.AddedItems)
      {
        TargetSelectionChanged(region, Activating, item);
        ////region.Activate(item);
      }
    };

    // Detect when a TabItem has been added/removed to the TabControl
    region.Views.CollectionChanged += (s, e) =>
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        foreach (UserControl item in e.NewItems)
        {
          var items = regionTarget.Items.Cast<TabItem>().ToList();

          // Set the ViewModel for our tab items
          //// var vm = item.DataContext as ViewModelBase; // NOT NEEDED
          var vm = item.DataContext;

          items.Add(new TabItem
          {
            DataContext = vm,
            // Header = vm.Title, // No need to enforce title. Let AXAML drive Header
            Content = item,
          });

          regionTarget.ItemsSource = items;     // Avalonia v11.x and v0.10.x
          //// regionTarget.Items.Set(items);   // From old preview release
        }
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        foreach (UserControl item in e.OldItems)
        {
          var tabToDelete = regionTarget.Items.OfType<TabItem>().FirstOrDefault(n => n.Content == item);
          // regionTarget.Items.Remove(tabToDelete);  // WPF

          var items = regionTarget.Items.Cast<TabItem>().ToList();
          items.Remove(tabToDelete);
          regionTarget.ItemsSource = items;
          //// regionTarget.Items.Set(items);   // Avalonia v11
        }
      }
    };
  }

  /// <summary>
  ///   AllActiveRegion    - Can have multiple active views at the same time (i.e. multi-window views)
  ///   SingleActiveRegion - There is only one view active at a time. (i.e. Tab)
  /// </summary>
  /// <returns>Region</returns>
  protected override IRegion CreateRegion() => new SingleActiveRegion();

  /// <summary>Handle activating or deactivating the Region.</summary>
  /// <param name="changeAction"></param>
  /// <param name="itemChanged"></param>
  private void TargetSelectionChanged(IRegion region, int changeAction, object itemChanged)
  {
    // The selected item isn't always a TabItem.
    // In some cases, it could be the Region's ListBox item
    TabItem? item = itemChanged as TabItem;
    if (item is null)
      return;

    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (Header):    " + item.Header);
    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (View):      " + item.Content);
    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (ViewModel): " + item.DataContext);

    if (changeAction == Deactivating)
    {
      // region.Deactivate(item);
    }
    else if (changeAction == Activating)
    {
      // region.Activate(item);
    }
  }
}
