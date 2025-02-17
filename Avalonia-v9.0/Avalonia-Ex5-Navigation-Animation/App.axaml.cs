using Avalonia;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;

namespace Sample.NavAnimation
{
    public partial class App : PrismApplication
    {
        public App()
        {
            System.Diagnostics.Debug.WriteLine("App.Constructor()");
        }

        public override void Initialize()
        {
            System.Diagnostics.Debug.WriteLine("Initialize()");
            AvaloniaXamlLoader.Load(this);

            base.Initialize();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            System.Diagnostics.Debug.WriteLine("RegisterTypes(...)");

            containerRegistry.RegisterForNavigation<ViewX>();
            containerRegistry.RegisterForNavigation<ViewY>();
        }

        /// <summary>User interface entry point, called after Register and ConfigureModules.</summary>
        /// <returns>Startup View.</returns>
        protected override AvaloniaObject CreateShell()
        {
            System.Diagnostics.Debug.WriteLine("CreateShell()");
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            System.Diagnostics.Debug.WriteLine("OnInitialized()");
        }
    }
}
