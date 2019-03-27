/* Copyright 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    MainViewModel.cs
 * Description:
 *
 */

using System;
using Prism.Commands;
using Prism.Navigation;

namespace Tmpl.PrismApp.Client.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    public MainViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
    }

    public DelegateCommand<string> CmdNavigate => new DelegateCommand<string>(OnNavigate);

    private async void OnNavigate(string viewUri)
    {
      await NavigationService.NavigateAsync(new Uri(viewUri, UriKind.Relative));
    }
  }
}
