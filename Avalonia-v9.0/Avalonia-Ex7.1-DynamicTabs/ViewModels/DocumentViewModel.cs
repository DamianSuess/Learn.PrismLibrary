using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation.Regions;

namespace SampleApp.ViewModels;

/// <summary>Document ViewModel.</summary>
public class DocumentViewModel : ViewModelBase, INavigationAware
{
  private string _fileName = string.Empty;

  public DocumentViewModel()
  {
    Title = "Documents Tab*";
    FileName = "NEW";
  }

  public DelegateCommand CmdChangeTitle => new(() =>
  {
    Title = "1235";
    Debug.WriteLine($"Title: {Title}");
  });

  public string FileName { get => _fileName; set => SetProperty(ref _fileName, value); }

  public bool IsNavigationTarget(NavigationContext navigationContext)
  {
    return false;
  }

  public void OnNavigatedFrom(NavigationContext navigationContext)
  {
  }

  public void OnNavigatedTo(NavigationContext navigationContext)
  {
    if (!navigationContext.Parameters.ContainsKey("DocumentIndex"))
      return;

    var ndx = navigationContext.Parameters["DocumentIndex"] as string;
    if (ndx is not null)
    {
      FileName = "NEW";
      Title = $"Doc #{ndx}";
      Debug.WriteLine($"Title: {Title}");
    }
  }
}
