using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.PrismMaui.Views;

namespace Test.PrismMaui.ViewModels
{
  public class SubPageViewModel : BindableBase
  {
    private readonly INavigationService _nav;

    public SubPageViewModel(INavigationService nav)
    {
      _nav = nav;
    }

    public string Title => "Prism Maui - Subpage View";

    public DelegateCommand CmdNavigateBack => new DelegateCommand(() =>
    {
      _nav.GoBackAsync();
    });
  }
}
