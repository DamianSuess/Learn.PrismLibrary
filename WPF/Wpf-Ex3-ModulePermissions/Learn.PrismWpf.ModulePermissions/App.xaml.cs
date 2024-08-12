using System.Security.Principal;
using System.Threading;
using System.Windows;
using Learn.PrismWpf.Common;
using Learn.PrismWpf.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Learn.PrismWpf
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

    protected override void InitializeShell(Window shell)
    {
      base.InitializeShell(shell);

      // Here, you can use your own user role identification (i.e. custom or Active Directory)
      var ident = WindowsIdentity.GetCurrent();

      // User has both "User" and "Admin" permissions
      var p = new GenericPrincipal(ident, new string[] { RoleName.User, RoleName.Admin });

      ////// Client ONLY has "User" permissions
      ////var p = new GenericPrincipal(ident, new string[] { RoleName.User });

      Thread.CurrentPrincipal = p;
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      //// return base.CreateModuleCatalog();  // From Prism 8.0 template. Returns, new ModuleCatalog().

      // Tells Prism to use, App.config file to load the modules.
      return new ConfigurationModuleCatalog();  // returns, new ConfigurationStore();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IModuleInitializer, Common.RoleModuleInitializer>();
    }
  }
}
