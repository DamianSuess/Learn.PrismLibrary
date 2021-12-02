using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Sample.PrismMobile.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    public DashboardViewModel(INavigationService nav)
      : base(nav)
    {
      Title = "Main Page";
    }

    public DelegateCommand CmdTestButton => new DelegateCommand(async () =>
    {
      await Task.Yield();
    });
  }
}