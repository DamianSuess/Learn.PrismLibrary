using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Test.PrismWpf.Modules.ModuleName;
using Test.PrismWpf.Services;
using Test.PrismWpf.Services.Interfaces;
using Test.PrismWpf.Views;

namespace Test.PrismWpf
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    protected override Window CreateShell()
    {
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IMessageService, MessageService>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      moduleCatalog.AddModule<ModuleNameModule>();
    }
  }
}
