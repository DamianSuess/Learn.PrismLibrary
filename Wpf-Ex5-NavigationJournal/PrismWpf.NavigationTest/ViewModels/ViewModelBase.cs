using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismWpf.NavigationTest.ViewModels;

public class ViewModelBase : BindableBase, INavigationAware
{
  public virtual void OnNavigatedTo(NavigationContext navigationContext)
{
}

public virtual void OnNavigatedFrom(NavigationContext navigationContext)
{
}

public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
}
