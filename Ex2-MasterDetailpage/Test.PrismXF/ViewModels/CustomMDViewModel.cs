using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.PrismXF.ViewModels
{
	public class CustomMDViewModel : BindableBase
	{
    INavigationService _navigationService;

    public CustomMDViewModel(INavigationService navService)
    {
      _navigationService = navService;
    }
	}
}
