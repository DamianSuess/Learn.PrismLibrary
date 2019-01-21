using System;
using Prism;
using Prism.Ioc;
using Test.PrismXF.ViewModels;
using Test.PrismXF.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Test.PrismXF
{
  public partial class App
  {
    /* 
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor. 
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */
    public App() : this(null) { }

    public App(IPlatformInitializer initializer) : base(initializer) { }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      // Master Detail Nav --------------
      await NavigationService.NavigateAsync("RootMasterDetailPage/NavigationPage/MainPage");

      // DON'T skip the NavigatinPage or else things won't push/pop correctly
      // await NavigationService.NavigateAsync("RootMasterDetailPage/MainPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Use types for View & ViewModel so we don't have a reflection performance hit
      containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
      containerRegistry.RegisterForNavigation<SecondPage, SecondViewModel>();
      containerRegistry.RegisterForNavigation<ThirdPage, ThirdViewModel>();
      containerRegistry.RegisterForNavigation<RootMasterDetailPage, RootMasterDetailViewModel>();
      containerRegistry.RegisterForNavigation<NavigationPage>();

      // Use types for View & ViewModel so we don't have a reflection performance hit
      //containerRegistry.RegisterForNavigation<MainPage, MainViewModel>("MainPage");
      //containerRegistry.RegisterForNavigation<SecondPage, SecondViewModel>("SecondPage");
      //containerRegistry.RegisterForNavigation<ThirdPage, ThirdViewModel>("ThirdPage");

      // Use (slower) reflection to find pages
      //containerRegistry.RegisterForNavigation<MainPage>("MainPage");
      //containerRegistry.RegisterForNavigation<SecondPage>("SecondPage");
      //containerRegistry.RegisterForNavigation<ThirdPage>("ThirdPage");
    }

    protected override void OnAppLinkRequestReceived(Uri uri)
    {
      NavigationService.NavigateAsync(uri);
    }
  }
}
