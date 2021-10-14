using System.Windows;
using Learn.PrismWpf.Client.Views;
using Prism.Ioc;

namespace Learn.PrismWpf.Client
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

    }
  }
}
