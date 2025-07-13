using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation.Regions;
using SampleApp.Views;

namespace SampleApp.ViewModels;

/// <summary>Document ViewModel.</summary>
public class DocumentViewModel : ViewModelBase, INavigationAware
{
  private readonly IRegionManager _regionManager;
  private int _documentIndex;
  private string _fileName = string.Empty;
  private IRegionNavigationJournal _journal;

  public DocumentViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;

    Title = "Documents Tab*";
    FileName = "NEW";
  }

  public DelegateCommand CmdChangeTitle => new(() =>
  {
    Title = $"Updated #{_documentIndex}";
    Debug.WriteLine($"Title: {Title}");
  });

  public DelegateCommand<object> CmdClose => new((object tabItem) =>
  {
    Debug.WriteLine("Close - Clicked from X button");
    var items = _regionManager.Regions[RegionNames.DocumentTabRegion];

    // NO!
    // object active = items.ActiveViews.First();

    Debug.WriteLine(tabItem.ToString());

    try
    {
      var view = tabItem as DocumentView;
      if (_regionManager.Regions[RegionNames.DocumentTabRegion].Views.Contains(view))
        _regionManager.Regions[RegionNames.DocumentTabRegion].Remove(view);

      // NOTE: Unique Region "Name" is NULL because TabControlAdapter never sets it.
      ////var view = items.GetView(nameof(DocumentView));
      ////if (view is null)
      ////  return;
      ////
      ////_regionManager.Regions[RegionNames.DocumentTabRegion].Remove(view);
    }
    catch (Exception ex)
    {
      // NOTE: If there are no more views
      Debug.WriteLine($"[CmdClose] Unable to remove Tab from RegionManager. {ex.Message}");
      //// Debugger.Break();
    }
  });

  public DelegateCommand CmdCloseInternal => new(() =>
  {
    Debug.WriteLine("Close - Clicked from internal");

    var items = _regionManager.Regions[RegionNames.DocumentTabRegion];

    var current = _journal.CurrentEntry;
    _journal.GoBack();

    // Find our view
    foreach (var view in items.Views)
    {
      Debug.WriteLine(view.ToString());

      var vm = ((DocumentView)view).DataContext as DocumentViewModel;
      if (vm._documentIndex == _documentIndex)
      {
        _regionManager.Regions[RegionNames.DocumentTabRegion].Remove(view);
      }
    }
  });

  public string FileName { get => _fileName; set => SetProperty(ref _fileName, value); }

  public bool IsNavigationTarget(NavigationContext navigationContext)
  {
    // Determine which instance to use (INavagtionAware.IsNavigationTarget)
    // True - Use existing instance
    // False - Create new instance
    return false;
  }

  public void OnNavigatedFrom(NavigationContext navigationContext)
  {
  }

  public void OnNavigatedTo(NavigationContext navigationContext)
  {
    if (!navigationContext.Parameters.ContainsKey(ParameterNames.DocumentIndex))
      return;

    _journal = navigationContext.NavigationService.Journal;

    var ndx = navigationContext.Parameters[ParameterNames.DocumentIndex] as string;
    if (ndx is not null)
    {
      FileName = "NEW";
      Title = $"Doc #{ndx}";

      // Lets store the index for fun
      if (int.TryParse(ndx, out var intIndex))
        _documentIndex = intIndex;

      Debug.WriteLine($"Title: {Title}");
    }
  }
}
