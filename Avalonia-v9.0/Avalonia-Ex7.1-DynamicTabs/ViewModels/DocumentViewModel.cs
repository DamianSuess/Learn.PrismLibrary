using Prism.Navigation.Regions;

namespace SampleApp.ViewModels;

/// <summary>Document ViewModel.</summary>
public class DocumentViewModel : ViewModelBase, INavigationAware
{
  private string _fileName = string.Empty;

  public DocumentViewModel()
  {
    Title = "Documents Tab";
  }

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

    int? ndx = (int)navigationContext.Parameters["DocumentIndex"];
    if (ndx is not null)
    {
      FileName = "NEW";
      Title = $"Doc #{ndx}";
    }
  }
}
