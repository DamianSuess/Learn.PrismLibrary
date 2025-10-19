/* Copyright Xeno Innovations, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    App.xaml.cs
 * Description:
 *
 */

using Prism;
using Prism.Ioc;
using Tmpl.PrismApp.Client.ViewModels;
using Tmpl.PrismApp.Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Tmpl.PrismApp.Client
{
  public partial class App
  {
    public App() : this(null)
    {
      //InitializeComponent();
      //MainPage = new MainPage();
    }

    public App(IPlatformInitializer initializer) : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      await NavigationService.NavigateAsync("MainView/NavigationPage/WelcomeView");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
      containerRegistry.RegisterForNavigation<WelcomeView, WelcomeViewModel>();
      containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}