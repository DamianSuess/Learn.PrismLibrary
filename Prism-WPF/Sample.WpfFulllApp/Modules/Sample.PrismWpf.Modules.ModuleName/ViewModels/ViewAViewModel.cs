using Prism.Regions;
using Test.PrismWpf.Core.Mvvm;
using Test.PrismWpf.Services.Interfaces;

namespace Test.PrismWpf.Modules.ModuleName.ViewModels
{
  public class ViewAViewModel : RegionViewModelBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
        base(regionManager)
    {
      Message = messageService.GetMessage();
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
      //do something
    }
  }
}
