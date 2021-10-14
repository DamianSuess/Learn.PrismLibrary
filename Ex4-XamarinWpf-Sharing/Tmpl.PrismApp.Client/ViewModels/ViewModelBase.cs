/* Copyright Omnicell, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    ViewModelBase.cs
 * Description:
 *
 */

using Prism.Mvvm;
using Prism.Navigation;

namespace Tmpl.PrismApp.Client.ViewModels
{
  public class ViewModelBase : BindableBase, INavigationAware, IDestructible
  {
    private string _title;

    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    protected INavigationService NavigationService { get; private set; }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    public virtual void OnNavigatingTo(INavigationParameters parameters)
    {
    }

    public virtual void Destroy()
    {
    }
  }
}
