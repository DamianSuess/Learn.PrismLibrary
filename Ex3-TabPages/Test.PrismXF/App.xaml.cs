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

    public App() : this(null)
    {
    }

    public App(IPlatformInitializer initializer) : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      // await NavigationService.NavigateAsync($"{nameof(MainTabbedView)}");
      await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainTabbedView)}");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Use types for View & ViewModel so we don't have a reflection performance hit
      containerRegistry.RegisterForNavigation<Page1View, Page1ViewModel>();
      containerRegistry.RegisterForNavigation<Page2View, Page2ViewModel>();
      containerRegistry.RegisterForNavigation<Page3View, Page3ViewModel>();
      containerRegistry.RegisterForNavigation<MainTabbedView, MainTabbedViewModel>();
      containerRegistry.RegisterForNavigation<NavigationPage>();

      // Use types for View & ViewModel so we don't have a reflection performance hit
      //containerRegistry.RegisterForNavigation<MainPage, MainTabbedViewModel>("MainPage");
      //containerRegistry.RegisterForNavigation<Page1View, Page1ViewModel>("Page1View");
      //containerRegistry.RegisterForNavigation<Page2View, Page2ViewModel>("Page2View");

      // Use (slower) reflection to find pages
      //containerRegistry.RegisterForNavigation<Page1View>("Page1View");
      //containerRegistry.RegisterForNavigation<Page2View>("Page2View");
      //containerRegistry.RegisterForNavigation<Page3View>("Page3View");
    }

    protected override void OnAppLinkRequestReceived(Uri uri)
    {
      NavigationService.NavigateAsync(uri);
    }
  }
}