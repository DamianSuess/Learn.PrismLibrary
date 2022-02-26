using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XamarinHelloBle.Client.ViewModels
{
  public class DeviceListViewModel : ViewModelBase
  {
    public DeviceListViewModel(INavigationService navService)
      : base(navService)
    {
      // .
    }

    public DelegateCommand CmdScanStart => new DelegateCommand(async () =>
    {
      await ScanStartAsync();
    });

    public DelegateCommand CmdScanStop => new DelegateCommand(async () =>
    {
      await Task.Yield();
    });

    public async void DeviceItemTappedAsync()
    {
      await Task.Yield();
    }

    private async Task ScanStartAsync()
    {
      await Task.Yield();
    }
  }
}
