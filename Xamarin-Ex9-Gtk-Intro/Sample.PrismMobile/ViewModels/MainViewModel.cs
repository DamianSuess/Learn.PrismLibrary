using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Sample.PrismMobile.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      Title = "Main Page";
    }

    public DelegateCommand CmdTestButton => new DelegateCommand(async () =>
    {
      await Task.Yield();
    });


  }
}
