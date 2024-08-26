using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Styling;
using Prism.Commands;
using SampleApp.Services;

namespace SampleApp.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    private readonly INotificationService _notification;

    private int _counter = 0;
    private int _listItemSelected = -1;
    private ObservableCollection<string> _listItems = new();
    private string _listItemText = string.Empty;
    private ThemeVariant _themeSelected = ThemeVariant.Default;

    public DashboardViewModel(INotificationService notifyService)
    {
        _notification = notifyService;

#pragma warning disable CS8601 // Possible null reference assignment.
        ThemeSelected = Application.Current!.RequestedThemeVariant;
#pragma warning restore CS8601 // Possible null reference assignment.
    }

    public DelegateCommand CmdAddItem => new(() =>
    {
        _counter++;

        // Insert items at the top of the list
        ListItems.Insert(0, $"Item Number: {_counter}");

        // Insert at the bottom
        // ListItems.Add($"Item Number: {_counter}");
    });

    public DelegateCommand CmdClearItems => new(ListItems.Clear);

    public DelegateCommand CmdNotification => new(() =>
    {
        _notification.Show("Hello Prism!", "Notification Pop-up Message.");

        // Alternate OnClick action
        ////_notification.Show("Hello Prism!", "Notification Pop-up Message.", () =>
        ////{
        ////    // Action to perform
        ////});
    });

    public int ListItemSelected
    {
        get => _listItemSelected;
        set
        {
            SetProperty(ref _listItemSelected, value);

            if (value == -1)
                return;

            ListItemText = ListItems[ListItemSelected];
        }
    }

    public string ListItemText { get => _listItemText; set => SetProperty(ref _listItemText, value); }

    public ObservableCollection<string> ListItems { get => _listItems; set => SetProperty(ref _listItems, value); }

    public ThemeVariant ThemeSelected
    {
        get => _themeSelected;
        set
        {
            SetProperty(ref _themeSelected, value);
            Application.Current!.RequestedThemeVariant = _themeSelected;
        }
    }

    public List<ThemeVariant> ThemeStyles => new()
    {
        ThemeVariant.Default,
        ThemeVariant.Dark,
        ThemeVariant.Light,
    };
}
