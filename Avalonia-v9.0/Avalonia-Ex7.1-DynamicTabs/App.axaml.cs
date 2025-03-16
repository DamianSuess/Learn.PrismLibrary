using System;
using Avalonia;
using Avalonia.Markup.Xaml;
using SampleApp.ViewModels;
using SampleApp.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation.Regions;
using Avalonia.Controls;
using SampleApp.Adapters;

namespace SampleApp;

public partial class App : PrismApplication
{
  public override void Initialize()
  {
    Console.WriteLine("Initialize()");

    AvaloniaXamlLoader.Load(this);

    // Required to initialize Prism.Avalonia - DO NOT REMOVE
    base.Initialize();
  }

  protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
  {
    base.ConfigureRegionAdapterMappings(regionAdapterMappings);

    // Custom adapter mappers
    regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlAdapter>());
  }

  protected override AvaloniaObject CreateShell()
  {
    Console.WriteLine("CreateShell()");

    return Container.Resolve<MainWindow>();
  }

  protected override void OnInitialized()
  {
    base.OnInitialized();

    // Register Views to Region it will appear in. Don't register them in the ViewModel.
    var regionManager = Container.Resolve<IRegionManager>();

    // Force Tabs to display - Remember to wire ViewModels in RegisterTypes()
    ////regionManager.RegisterViewWithRegion(RegionNames.DocumentTabRegion, typeof(DocumentView));
    ////regionManager.RegisterViewWithRegion(RegionNames.DocumentTabRegion, typeof(SettingsView));
  }

  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
    // Add Services and ViewModel registrations here
    Console.WriteLine("RegisterTypes()");

    // Register DocumentView for navigation
    containerRegistry.RegisterForNavigation<DocumentView, DocumentViewModel>();
    containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();

    // -=[ Sample ]=-
    //
    //  // Services
    //  containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
    //
    //  // Views - Region Navigation
    //  containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
  }
}
