using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using PrismWpf.NavigationTest.Values;
using PrismWpf.NavigationTest.ViewModels;
using PrismWpf.NavigationTest.Views;
using System.Windows;

namespace PrismWpf.NavigationTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
  protected override Window CreateShell()
  {
    return Container.Resolve<MainWindow>();
  }

  protected override void RegisterTypes(IContainerRegistry container)
  {
    container.RegisterForNavigation<FirstView, FirstViewModel>();
    container.RegisterForNavigation<SecondView, SecondViewModel>();
    container.RegisterForNavigation<ThirdView, ThirdViewModel>();
  }

  protected override void OnInitialized()
  {
    base.OnInitialized();
    var regionManager = Container.Resolve<IRegionManager>();
    regionManager.RegisterViewWithRegion(RegionNames.Content, typeof(FirstView));
  }
}
