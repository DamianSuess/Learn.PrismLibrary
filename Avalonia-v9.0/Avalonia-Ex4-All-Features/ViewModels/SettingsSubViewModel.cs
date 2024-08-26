using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation.Regions;
using SampleApp.Views;

namespace SampleApp.ViewModels;

public class SettingsSubViewModel : ViewModelBase
{
    private readonly IRegionManager _regionManager;
    private IRegionNavigationJournal? _journal;
    private string? _messageText = string.Empty;
    private string? _messageNumber = string.Empty;

    public SettingsSubViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;

        Title = "Settings - SubView";
    }

    public DelegateCommand CmdNavigateBack => new(() =>
    {
        // Go back to the previous calling page, otherwise, Dashboard.
        if (_journal != null && _journal.CanGoBack)
            _journal.GoBack();
        else
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(DashboardView));
    });

    public string? MessageText { get => _messageText; set => SetProperty(ref _messageText, value); }

    public string? MessageNumber { get => _messageNumber; set => SetProperty(ref _messageNumber, value); }

    /// <summary>Navigation completed successfully.</summary>
    /// <param name="navigationContext">Navigation context.</param>
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        // Used to "Go Back" to parent
        _journal = navigationContext.NavigationService.Journal;

        // Get and display our parameters
        if (navigationContext.Parameters.TryGetValue("key1", out string? value))
            MessageText = value;

        if (navigationContext.Parameters.TryGetValue("key2", out int msgNum))
            MessageNumber = msgNum.ToString();
    }

    public override bool OnNavigatingTo(NavigationContext navigationContext)
    {
        Debug.WriteLine("OnNavigatingTo");

        // Navigation permission sample:
        return navigationContext.Parameters.ContainsKey("key1") &&
               navigationContext.Parameters.ContainsKey("key2");
    }
}
