using Avalonia;
using Avalonia.Markup.Xaml;
using Learn.PrismAvalonia.ViewModels;
using Learn.PrismAvalonia.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Learn.PrismAvalonia
{
  public class App : PrismApplication
  {
    /// <summary>App entry point.</summary>
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
      base.Initialize();
    }

    /// <summary>Prism Module Registration.</summary>
    /// <remarks><![CDATA[https://prismlibrary.com/docs/modules.html]]></remarks>
    /// <param name="moduleCatalog">Module Catalog.</param>
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      base.ConfigureModuleCatalog(moduleCatalog);

      // Wire-up modules for Region Manager
      //// moduleCatalog.AddModule<Common.Modules.LogOutput.LogOutputModule>();
      //// moduleCatalog.AddModule<UserLoginModule>();
    }

    /// <summary>User interface entry point, called after Register and ConfigureModules.</summary>
    /// <returns>Startup View.</returns>
    protected override IAvaloniaObject CreateShell()
    {
      return this.Container.Resolve<ShellWindow>();
    }

    /// <summary>Called after Initialize.</summary>
    protected override void OnInitialized()
    {
      // Register Views to Region it will appear in. Don't register them in the ViewModel.
      var regionManager = Container.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));
      regionManager.RegisterViewWithRegion(RegionNames.SidebarRegion, typeof(SidebarView));
    }

    /// <summary>
    ///   Register views and Services.
    /// </summary>
    /// <param name="containerRegistry">IOC Container.</param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Services
      ////containerRegistry.RegisterSingleton<ILogService, LogService>();
      ////containerRegistry.RegisterSingleton<IJsonService, JsonService>();
      ////containerRegistry.RegisterSingleton<IPreferenceService, PreferenceService>();

      // Views - Generic views
      containerRegistry.Register<ShellWindow>();
      containerRegistry.Register<SidebarView>();

      // Views - Region Navigation
      containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
      ////containerRegistry.RegisterForNavigation<NewsView, NewsViewModel>();
      ////containerRegistry.RegisterForNavigation<NewsArticleView, NewsArticleViewModel>();
      ////containerRegistry.RegisterForNavigation<EventsView, EventsViewModel>();
    }
  }
}
