using System;
using Prism;
using Prism.Ioc;
using Test.PrismForms.ViewModels;
using Test.PrismForms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Test.PrismForms
{
  [AutoRegisterForNavigation]
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

      // Navigation to our main page
      // We're using NavigationPage to give us the Push/Pop layering of pages
      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainView)}");
      if (!ret.Success)
      {
        Debug.WriteLine($"Error loading - {ret.Exception.Message}");
      }
   }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // [AutoRegisterForNavigation] removes the need for manual registration 
      ////containerRegistry.RegisterForNavigation<NavigationPage>();
      ////containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
      ////containerRegistry.RegisterForNavigation<Page2View, Page2ViewModel>();
      ////containerRegistry.RegisterForNavigation<Page3View, Page3ViewModel>();
    }

    protected override void OnAppLinkRequestReceived(Uri uri)
    {
      NavigationService.NavigateAsync(uri);
    }
  }
}
