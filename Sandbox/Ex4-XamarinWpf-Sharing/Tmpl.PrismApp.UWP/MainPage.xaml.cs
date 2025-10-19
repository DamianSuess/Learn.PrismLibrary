/* Copyright Xeno Innovations, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    MainPage.xaml.cs
 * Description:
 *
 */

using Prism;
using Prism.Ioc;

namespace Tmpl.PrismApp.UWP
{
  public sealed partial class MainPage
  {
    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new Tmpl.PrismApp.Client.App(new UwpInitializer()));
    }
  }

  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}
