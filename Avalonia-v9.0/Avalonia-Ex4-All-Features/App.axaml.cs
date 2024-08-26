using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Services;
using SampleApp.ViewModels;
using SampleApp.Views;

namespace SampleApp;

public partial class App : PrismApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        // Required when overriding Initialize
        base.Initialize();
    }

    protected override AvaloniaObject CreateShell()
    {
        Debug.WriteLine("CreateShell()");
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        Debug.WriteLine("RegisterTypes()");

        // Note:
        // SidebarView isn't listed, note we're using `AutoWireViewModel` in the View's AXAML.
        // See the line, `prism:ViewModelLocator.AutoWireViewModel="True"`

        // Services
        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();

        // Views - Region Navigation
        containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
        containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        containerRegistry.RegisterForNavigation<SettingsSubView, SettingsSubViewModel>();

        // Dialogs, etc.
    }

    /// <summary>Register optional modules in the catalog.</summary>
    /// <param name="moduleCatalog">Module Catalog.</param>
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        Debug.WriteLine("ConfigureModuleCatalog()");
        base.ConfigureModuleCatalog(moduleCatalog);
    }

    /// <summary>Called after Initialize.</summary>
    protected override void OnInitialized()
    {
        Debug.WriteLine("OnInitialized()");

        // Register Views to the Region it will appear in. Don't register them in the ViewModel.
        var regionManager = Container.Resolve<IRegionManager>();

        // WARNING: Prism v11.0.0-prev4
        // - DataTemplates MUST define a DataType or else an XAML error will be thrown
        // - Error: DataTemplate inside of DataTemplates must have a DataType set
        regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));
        regionManager.RegisterViewWithRegion(RegionNames.SidebarRegion, typeof(SidebarView));

        ////regionManager.RegisterViewWithRegion(RegionNames.DynamicSettingsListRegion, typeof(Setting1View));
        ////regionManager.RegisterViewWithRegion(RegionNames.DynamicSettingsListRegion, typeof(Setting2View));
    }

    /// <summary>Custom region adapter mappings.</summary>
    /// <param name="regionAdapterMappings">Region Adapters.</param>
    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        Debug.WriteLine("ConfigureRegionAdapterMappings()");
        regionAdapterMappings.RegisterMapping<ContentControl, ContentControlRegionAdapter>();
    }
}
