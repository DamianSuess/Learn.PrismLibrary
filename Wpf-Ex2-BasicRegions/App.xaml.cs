using System.Windows;
using Learn.PrismWpf.BasicRegions.Views;
using Prism.Ioc;

namespace Learn.PrismWpf.BasicRegions
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
      containerRegistry.Register<Services.INewsService, Services.NewsService>();

      containerRegistry.RegisterForNavigation<DashboardView>();
      containerRegistry.RegisterForNavigation<SidebarView>();
      containerRegistry.RegisterForNavigation<OptionsView>();
    }
  }
}