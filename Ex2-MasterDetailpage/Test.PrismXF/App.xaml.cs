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
      await NavigationService.NavigateAsync("CustomMDPage/MainPage");

      // Simple Navigation --------------
      // NOTICE: "NavigationPage" matches our RegisteredTypes(..) below
      //
      // EX 1: Simple
      // await NavigationService.NavigateAsync("NavigationPage/MainPage");
      //
      // EX 2: Deep linking - starts at 2nd page and click back button for Main Page
      // await NavigationService.NavigateAsync("NavigationPage/MainPage/SecondPage");
      //
      // EX 3: Deep linking and creates a crazy nav stack with params
      // await NavigationService.NavigateAsync("NavigationPage/MainPage/SecondPage/ThirdPage?id=3/MyMasterDetail/MyNavigatinPage/MainPage/ThirdPage/SecondPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Use types for View & ViewModel so we don't have a reflection performance hit
      containerRegistry.RegisterForNavigation<MainPage, MainViewModel>("MainPage");
      containerRegistry.RegisterForNavigation<SecondPage, SecondViewModel>("SecondPage");
      containerRegistry.RegisterForNavigation<ThirdPage, ThirdViewModel>("ThirdPage");

      // Use reflection to find pages
      //containerRegistry.RegisterForNavigation<MainPage>("MainPage");
      //containerRegistry.RegisterForNavigation<SecondPage>("SecondPage");
      //containerRegistry.RegisterForNavigation<ThirdPage>("ThirdPage");
      containerRegistry.RegisterForNavigation<CustomMDPage, CustomMDViewModel>();
      containerRegistry.RegisterForNavigation<NavigationPage>();
    }

    protected override void OnAppLinkRequestReceived(Uri uri)
    {
      NavigationService.NavigateAsync(uri);
    }
  }
}
