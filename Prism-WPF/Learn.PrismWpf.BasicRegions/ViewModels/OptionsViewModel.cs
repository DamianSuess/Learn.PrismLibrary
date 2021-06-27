using Prism.Commands;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public class OptionsViewModel : ViewModelRegionBase
  {
    private IRegionNavigationJournal _journal;

    public OptionsViewModel(IRegionManager regionManager)
      : base(regionManager)
    {
    }

    /////// <summary>Use delegate command to call method (action).</summary>
    ////public DelegateCommand GoBackCommand => new DelegateCommand(GoBack);
    ////
    ////public override void OnNavigatedTo(NavigationContext navigationContext)
    ////{
    ////  _journal = navigationContext.NavigationService.Journal;
    ////}
    ////
    ////private void GoBack()
    ////{
    ////  _journal.GoBack();
    ////}
  }
}