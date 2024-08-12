using System;
using System.Collections.ObjectModel;
using Learn.PrismWpf.BasicRegions.Services;
using Prism.Commands;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public class DashboardViewModel : ViewModelRegionBase
  {
    private Lazy<ILargeMemoryService> _largeMemoryService;
    private INewsService _newsService;
    private string _selectedArticle;

    public DashboardViewModel(IRegionManager regionManager, INewsService newsService, Lazy<ILargeMemoryService> lmService)
      : base(regionManager)
    {
      _newsService = newsService;
      //// _largeMemoryService = lmService;
    }

    /// <summary>Initiate lazy load of LargeMemoryService.</summary>
    public DelegateCommand LargeMemoryCommand => new DelegateCommand(() =>
    {
      var isCreated = _largeMemoryService.IsValueCreated;
      if (isCreated)
      {
        var lm = _largeMemoryService.Value;
        var listItems = lm.GetAll();
      }
    });

    /// <summary>Selected News Article.</summary>
    public string NewsArticle
    {
      get => _selectedArticle;
      set => SetProperty(ref _selectedArticle, value);
    }

    /// <summary>List of news article titles.</summary>
    public ObservableCollection<string> NewsFeed { get; private set; } = new ObservableCollection<string>();

    /// <summary>Get news articles.</summary>
    public DelegateCommand RefreshNewsCommand => new DelegateCommand(OnRefreshNews);

    ////public DelegateCommand ShowOptionsCommand => new DelegateCommand(() =>
    ////{
    ////  var region = RegionManager.Regions[Regions.ContentRegion];
    ////  region.NavigationService.Journal.GoForward();
    ////
    ////  RegionManager.RequestNavigate(Regions.ContentRegion, nameof(Views.OptionsView));
    ////});

    public override void OnNavigatedFrom(NavigationContext navigationContext)
    {
      base.OnNavigatedFrom(navigationContext);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
      OnRefreshNews();
    }

    private void OnRefreshNews()
    {
      // Pro Tip:
      //  Never ever create a 'new ObservableCollection', that can affect the binding
      NewsFeed.Clear();

      var list = _newsService.GetTitles();

      foreach (var item in list)
        NewsFeed.Add(item);
    }
  }
}