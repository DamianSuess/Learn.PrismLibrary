/* Copyright 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    WelcomeViewModel.cs
 * Description:
 *
 */

using Prism.Navigation;

namespace Tmpl.PrismApp.Client.ViewModels
{
  public class SettingsViewModel : ViewModelBase
  {
    public SettingsViewModel(INavigationService navigationService)
      : base(navigationService)
    {
    }
  }
}