using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia_Ex4_Test1101.ViewModels;
using Avalonia_Ex4_Test1101.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace Avalonia_Ex4_Test1101
{
  public partial class App : PrismApplication
  {
    public override void Initialize()
    {
      Console.WriteLine("Initialize()");

      AvaloniaXamlLoader.Load(this);

      // Initializes Prism.Avalonia - DO NOT REMOVE
      base.Initialize();
    }

    protected override AvaloniaObject CreateShell()
    {
      Console.WriteLine("CreateShell()");
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      Console.WriteLine("RegisterTypes()");
    }

    /*
    public override void OnFrameworkInitializationCompleted()
    {
      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);
        desktop.MainWindow = new MainWindow
        {
          DataContext = new MainWindowViewModel(),
        };
      }

      base.OnFrameworkInitializationCompleted();
    }
    */
  }
}
